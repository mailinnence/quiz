using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("테스트용 변수")]
    public bool temp_save; 
    public int temp_level;
    public int temp_progress;

    [Header("진행도")]
    public int[] Progress = new int[5]; // 실상 필요없음

    [Header("파라독스 관련 컨트롤")]
    public bool paradox;
    public bool run;
    public bool jump;

    [Header("퀴즈 컨트롤러")]
    public bool first_quiz;
    public bool next_quiz;
    
    
    void Awake()
    {
        // 싱글톤 중복 방지
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않게 함
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 있으면 자신은 제거
        }
    }

    void Start()
    {
        Scene_Fade_black.instance.Fade(); 
        if(temp_save)
        {
            SaveProgress();
        }


        // // 2씬만 헤당
        // if (SceneManager.GetActiveScene().name == "2.choice")
        // {
        //     Situation.instance.StartEvent(-1);
        // }



    //    SaveProgress();
    //    LoadProgress();
    }



    // save system ---------------------------------
    // 저장된 값 불러오기
    void LoadProgress()
    {
        for (int i = 0; i < Progress.Length; i++)
        {
            // 키 이름을 "Progress0", "Progress1" ... 이런 식으로 만듦
            string key = "Progress" + i;

            // 저장된 값이 없으면 기본값 0 반환
            Progress[i] = PlayerPrefs.GetInt(key, 0);

            Debug.Log(key + " 불러온 값: " + Progress[i]);
        }
    }



    // 필요하면 저장 함수도 만들어두기
    public void SaveProgress()
    {        
        // for (int i = 0; i < 2; i++)
        // {
        //     string key = "Progress" + i;
        //     PlayerPrefs.SetInt(key, 100);
        // }

        string key = "Progress" + temp_level;
        PlayerPrefs.SetInt(key, temp_progress);

        PlayerPrefs.Save(); // 변경 사항 확실히 저장
        Debug.Log("Progress 값 저장 완료");
    }




    
}
