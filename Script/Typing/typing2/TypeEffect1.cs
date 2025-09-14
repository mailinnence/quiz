using System.Collections;
using TMPro;
using UnityEngine;

public class TypeEffect1 : MonoBehaviour
{
    public float CharPerSeconds;
    private string targetMsg;
    public TextMeshProUGUI msgText;
    private int index;
    private float interval;
    private Coroutine typingCoroutine;

    private void Awake()
    {
        if (msgText == null)
            msgText = GetComponent<TextMeshProUGUI>(); // 인스펙터에 할당된 값이 있으면 유지됨
    }


    public void SetMsg(string msg)
    {
        targetMsg = msg;
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        // 타이핑 모드가 on일 때만 효과 실행
        if (PlayerPrefs.GetString("set_typing_mode_save") == "on")
        {
            typingCoroutine = StartCoroutine(EffectingCoroutine());
        }

        else
        {
            // 한 번에 전체 텍스트 출력
            msgText.text = targetMsg;

            StartCoroutine(NextQuizDelay());
        }
    }



    IEnumerator EffectingCoroutine()
    {
        
        msgText.text = "";
        index = 0;
        interval = 1.0f / CharPerSeconds;

        while (index < targetMsg.Length)
        {
            SoundManager.instance.keyboard_sound();
            msgText.text += targetMsg[index++];
            yield return new WaitForSeconds(interval);
        }

        if(!GameManager.instance.next_quiz)
        {
            GameManager.instance.next_quiz = true;
        }
        
    }



    private IEnumerator NextQuizDelay()
    {
        yield return new WaitForSeconds(1f);
        if (!GameManager.instance.next_quiz)
        {
            GameManager.instance.next_quiz = true;
        }
    }

}