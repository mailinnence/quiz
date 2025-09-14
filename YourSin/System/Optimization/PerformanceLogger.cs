using UnityEngine;
using TMPro;

public class PerformanceLogger : MonoBehaviour
{
    public TextMeshProUGUI performanceText;  // 에디터에서 UI 텍스트 연결
    private bool Realtime;
    private float timer = 0f;
    public float updateInterval;

    void Awake()
    {
        updateInterval = 3f;
        DontDestroyOnLoad(performanceText.gameObject);
    }


    void Update()
    {
        PerformanceLogger_show();
        PerformanceLogger_speed();
    

    }


    void PerformanceLogger_show()
    {
        if (!Realtime)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                UpdatePerformanceText();
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                Realtime = true;
                timer = 0f;  // 자동 갱신 시작 시 타이머 초기화
            }
        }
        else
        {
            timer += Time.unscaledDeltaTime;
            if (timer >= updateInterval)
            {
                timer = 0f;
                UpdatePerformanceText();
            }
        }
    }

    void PerformanceLogger_speed()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            updateInterval += 0.5f;
            if (updateInterval > 10f) updateInterval = 10f; // 최대값 제한 (필요시 조정)
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            updateInterval -= 0.5f;
            if (updateInterval < 0.1f) updateInterval = 0.1f; // 최소값 제한
        }
    }




    void UpdatePerformanceText()
    {
        if (performanceText == null) return;

        float fps = 1f / Time.unscaledDeltaTime;
        float gpuTimeMs = Time.deltaTime * 1000f;
        string resolution = Screen.width + "x" + Screen.height;

        int batches = 0;
        int savedByBatching = 0;
        int tris = 0;
        int verts = 0;
        long threadMem = 0;
        int setPassCalls = 0;
        int shadowCasters = 0;
        int visibleSkinnedMeshes = 0;

#if UNITY_EDITOR
        batches = UnityEditor.UnityStats.batches;
        savedByBatching = 0;
        tris = UnityEditor.UnityStats.triangles;
        verts = UnityEditor.UnityStats.vertices;
        setPassCalls = UnityEditor.UnityStats.setPassCalls;
        shadowCasters = UnityEditor.UnityStats.shadowCasters;
        visibleSkinnedMeshes = UnityEditor.UnityStats.visibleSkinnedMeshes;
#endif

        performanceText.text =
            $"실행 빈도: {updateInterval}s\n" +
            $"------------------------------------------------------------------\n" +
            $"FPS (초당 프레임 수): {fps:F1}\n" +
            $"GPU (GPU 처리 시간): {gpuTimeMs:F2} ms\n" +
            $"Batches (드로우 콜 배치 수): {batches}\n" +
            $"Saved by batching (배칭으로 절약된 수): {savedByBatching}\n" +
            $"Tris (삼각형 개수): {tris}\n" +
            $"Verts (버텍스 개수): {verts}\n" +
            $"Screen (화면 해상도): {resolution}\n" +
            $"Thread (스레드 메모리 사용량): {threadMem} bytes\n" +
            $"SetPass calls (셰이더 패스 호출 수): {setPassCalls}\n" +
            $"Shadow casters (그림자 생성 객체 수): {shadowCasters}\n" +
            $"Visible skinned meshes (보이는 스킨 메시 수): {visibleSkinnedMeshes}\n" +
            $"------------------------------------------------------------------";
    }
}
