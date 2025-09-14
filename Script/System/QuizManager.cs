using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;

    private QuizLevelData quizLevelData;
    private Dictionary<int, QuizData> quizDict = new Dictionary<int, QuizData>();
    private string data;

    [Header("문제풀이 관련 변수")]
    public TextMeshProUGUI quizText;
    public TextMeshProUGUI[] quizChoices = new TextMeshProUGUI[4];
    public GameObject quizUI;
    public GameObject timerUI;
    public int num;


    void Awake()
    {
        // 싱글톤 설정
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    void Start()
    {
        LoadQuizData(); // 이제 SaveManager.instance는 null 아님
        // SendAllQuestionsToTalkManager();
    }

    void Update()
    {
        if (GameManager.instance.first_quiz)
        {
            GameManager.instance.first_quiz = false;
            quiz_init();
        }

        if(GameManager.instance.next_quiz)
        {
            quizUI_activate();
        }


        // 마지막 문제까지 다 풀었으면 해제
        if (SaveManager.instance.CurrentProgress == quizDict.Count)
        {
            ClearQuizData();
        }
    }




    // 선택지 복사 없이 참조만 전달
    public void quiz_init(int first = 0)
    {
        
        QuizData quiz = GetCurrentQuiz();
        if (quiz != null)
        {
            Situation.instance.talkIndex = 0;
            
            // 선택지 텍스트 세팅
            quizChoices[0].text = quiz.options[0];
            quizChoices[1].text = quiz.options[1];
            quizChoices[2].text = quiz.options[2];
            quizChoices[3].text = quiz.options[3];

            // 정답 저장
            SaveManager.instance.CurrentQuiz = quiz;

            num = quiz.number;
            // 0.5초 뒤에 퀴즈 시작
            if(first == 0) { StartCoroutine(NextQuizEventWithDelay(0f));; }
            else { StartCoroutine(NextQuizEventWithDelay(1f)); }
        }
    }

    // 코루틴 함수 추가
    private IEnumerator StartQuizEventWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Situation.instance.StartEvent(num); // 퀴즈
    }

    private IEnumerator NextQuizEventWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Situation.instance.StartEvent(num); // 퀴즈
    }



    public void quizUI_activate()
    {
        GameManager.instance.next_quiz = false;
        quizUI.SetActive(true);
        timerUI.SetActive(true);
    }


    public void quizUI_deactivate()
    {
        quizUI.SetActive(false);
        timerUI.SetActive(false);
    }





    void LoadQuizData()
    {
        data = SaveManager.instance.CurrentLevel; // 예: "Progress0"

        TextAsset json = Resources.Load<TextAsset>(data);
        if (json != null)
        {
            quizLevelData = JsonUtility.FromJson<QuizLevelData>(json.text);
            Debug.Log("퀴즈 JSON 자동 로드 성공");

            // 퀴즈 캐싱
            BuildQuizDictionary();
        }
        else
        {
            Debug.LogError("Resources 폴더에서 퀴즈 JSON 파일을 찾을 수 없습니다: " + data);
        }
    }

    void BuildQuizDictionary()
    {
        quizDict.Clear();
        int lastNum = -1;

        for (int i = 0; i < quizLevelData.quizList.Count; i++)
        {
            var quiz = quizLevelData.quizList[i];

            if (!quizDict.ContainsKey(quiz.number))
            {
                quizDict.Add(quiz.number, quiz);
                TalkManager.instance.talkData[i] = new string[] { quiz.question };
                lastNum += 1;
            }
            else
            {
                Debug.LogWarning($"중복된 퀴즈 번호가 존재합니다: {quiz.number}");
            }
        }

        SaveManager.instance.lastProgress = lastNum;
    }

    public QuizData GetCurrentQuiz()
    {
        if (quizLevelData == null)
        {
            Debug.LogWarning("퀴즈 데이터가 로드되지 않았습니다.");
            return null;
        }
        
        if (quizDict.TryGetValue(SaveManager.instance.CurrentProgress, out QuizData quiz))
        {
            return quiz;
        }

        Debug.LogWarning($"진행도 {SaveManager.instance.CurrentProgress}에 해당하는 퀴즈를 찾을 수 없습니다.");
        return null;
    }

    public void ClearQuizData()
    {
        quizDict.Clear();
        quizLevelData = null;
        Debug.Log("퀴즈 데이터 해제 완료");
    }






}

#region 퀴즈 데이터 구조 정의

[System.Serializable]
public class QuizData
{
    public int number;
    public string question;
    public List<string> options;
    public string answer;
}

[System.Serializable]
public class QuizLevelData
{
    public string level;
    public List<QuizData> quizList;
}

#endregion
