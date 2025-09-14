using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using TMPro;


public class MoveUpSlowly : MonoBehaviour
{
    public float speed = 50f; // 올라가는 속도 (픽셀/초)
    private TextMeshProUGUI tmpText;


    RectTransform rectTransform;

    void Start()
    {
        Scene_Fade_black.instance.Fade();
        rectTransform = GetComponent<RectTransform>();
        tmpText = GetComponent<TextMeshProUGUI>();

        if (tmpText != null)
        {
            tmpText.text = PlayerPrefs.GetString("ending_text"); 
        }

        StartCoroutine(moveChoice());
    }

    void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;
    }


   


    private IEnumerator moveChoice()
    {
        yield return new WaitForSeconds(20f);
        Scene_Fade_black.instance.fadeIn_ui_slow();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("2.choice");

    }


}
