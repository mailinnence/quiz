using System.Collections;
using UnityEngine;
using TMPro;

public class Situation1 : MonoBehaviour
{
    public static Situation1 instance;

    [Header("UI 요소")]
    // public GameObject button; // 대화 종료 후 나타날 버튼
    public TalkManager1 talkManager;
    public TypeEffect1 talk;
    public TextMeshProUGUI talkText;
    public int talkIndex;


    void Awake()
    {
        instance = this;
    }


    // 외부에서 호출하는 대화 시작 함수
    public void StartEvent(int objId)
    {
        talkText.gameObject.SetActive(true);
        // button.SetActive(false);
        ShowTalk(objId);
    }


    void ShowTalk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            // 대화 종료 처리
            talkText.gameObject.SetActive(false);
            // button.SetActive(true);
            talkIndex = 0;
            Cursor.visible = true;
            return;
        }

       
        talk.SetMsg(talkData); // 타자기 효과 실행
        talkIndex++;
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }
}
