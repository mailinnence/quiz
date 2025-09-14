using System.Collections;
using TMPro;
using UnityEngine;

public class TypeEffect : MonoBehaviour
{
    public float CharPerSeconds;
    private string targetMsg;
    public TextMeshProUGUI msgText;
    public TextMeshProUGUI skipText;
    private int index;
    private float interval;
    private Coroutine typingCoroutine;

    private void Awake()
    {
        msgText = GetComponent<TextMeshProUGUI>();
    }



    public void SetMsg(string msg)
    {
        targetMsg = msg;
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(EffectingCoroutine());
    }

    IEnumerator EffectingCoroutine()
    {
        skipText.gameObject.SetActive(false);
        msgText.text = "";
        index = 0;
        interval = 1.0f / CharPerSeconds;

        while (index < targetMsg.Length)
        {
            msgText.text += targetMsg[index++];
            yield return new WaitForSeconds(interval);
        }

        skipText.gameObject.SetActive(true);
    }
}
