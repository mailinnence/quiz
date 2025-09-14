using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    [Header("상태")]
    public string state;

    [Header("계절")]
    public int season;

    [Header("진도율")]
    public string CurrentLevel;
    public int CurrentProgress;
    public int lastProgress;

    [Header("현재 문제")]
    // ✅ 문제를 그대로 저장
    public QuizData CurrentQuiz;

    // 필요하면 Getter로 노출
    public string question => CurrentQuiz?.question;
    public List<string> options => CurrentQuiz?.options;
    public string answer => CurrentQuiz?.answer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AssignRandomSeason()
    {
        season = Random.Range(0, 4); // 0, 1, 2, 3 중 하나
        Debug.Log($"[SaveManager] 랜덤 시즌 배정됨: {season}");
    }

}
