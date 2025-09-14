using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AdminMode : MonoBehaviour
{
    public static AdminMode instance;

    public bool isAdminMode = false;
    public TMP_Text logText;

    private string inputBuffer = "";
    private int deleteJsonAttempts = 0; // 삭제 시도 횟수 저장

    private void Awake()
    {
        logText = GetComponent<TMP_Text>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {

        if (isAdminMode && Input.GetKeyDown(KeyCode.A))
        {
            if (logText != null)
            {
                logText.gameObject.SetActive(false); // 텍스트 오브젝트 비활성화
            }
        }

        DetectAdminKeySequence();

        if (!isAdminMode && Input.GetKeyDown(KeyCode.Escape))
        {
            inputBuffer = "";
            ShowLog("입력이 초기화되었습니다. 다시 입력해주세요.");
        }

        if (isAdminMode && Input.GetKeyDown(KeyCode.Q))
        {
            DeleteSystemJson(); // ✅ 수정 완료
        }

        if (isAdminMode && Input.GetKeyDown(KeyCode.W))
        {
            if (SceneManager.GetActiveScene().name == "3.solve")
            {
                SaveManager.instance.CurrentProgress = SaveManager.instance.lastProgress;
                ShowLog($"✅ CurrentLevel이 lastProgress({SaveManager.instance.lastProgress})로 설정되었습니다.");
            }
        }
    }

    // 'donkey' 입력 감지
    void DetectAdminKeySequence()
    {
        foreach (char c in Input.inputString)
        {
            inputBuffer += c;

            if (inputBuffer.Length > 6)
                inputBuffer = inputBuffer.Substring(inputBuffer.Length - 6);

            if (inputBuffer.ToLower() == "donkey")
            {
                isAdminMode = true;
                ShowLog("운영자 모드가 켜졌습니다!");
            }
        }
    }

    public void DeleteSystemJson()
    {
        deleteJsonAttempts++;

        if (deleteJsonAttempts < 3)
        {
            ShowLog($"⚠ 경고: system.json 파일을 삭제하려면 {3 - deleteJsonAttempts}번 더 실행해야 합니다.");
        }
        else
        {
            string path = Path.Combine(Application.persistentDataPath, "system.json");

            if (File.Exists(path))
            {
                File.Delete(path);
                ShowLog("✅ system.json 파일이 삭제되었습니다.");
            }
            else
            {
                ShowLog("❗ system.json 파일이 존재하지 않습니다.");
            }
            // 추가: 모든 PlayerPrefs 데이터 삭제
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            deleteJsonAttempts = 0;
        }
    }

    private void ShowLog(string message)
    {
        if (logText != null)
        {
            logText.text = message;
        }
        else
        {
            Debug.LogWarning("logText가 할당되지 않았습니다!");
            Debug.Log(message);
        }
    }
}
