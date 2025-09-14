using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;


public class saveDataText : MonoBehaviour
{
    private TextMeshProUGUI tmpText;
    private TextMeshPro textMeshPro;
    public string saveData;

    void Awake()
    {
        // 이 오브젝트에 붙은 TMP 컴포넌트 바로 가져오기
        tmpText = GetComponent<TextMeshProUGUI>();
        textMeshPro = GetComponent<TextMeshPro>();
    }


    void Start()
    {
        SetText();
    }

    // 텍스트를 바꾸는 공개 메서드
    public void SetText()
    {
        if (tmpText != null)
        {
            tmpText.text = PlayerPrefs.GetString(saveData);
        }
        if (textMeshPro != null)
        {
            textMeshPro.text = PlayerPrefs.GetString(saveData);
        }
    
    }
}