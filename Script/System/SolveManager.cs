using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SolveManager : MonoBehaviour
{
    public static SolveManager instance;

    // [Header("텍스트")]
    // public TextMeshProUGUI quiz;
    // public TextMeshProUGUI[] quizTexts = new TextMeshProUGUI[4];
    // public TextMeshProUGUI answer;


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


}
