using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;



public class saveData_textShaker : MonoBehaviour
{
    public static saveData_textShaker instance;


    [Header("세이브 데이터 가져오기")]
    private TextMeshProUGUI tmpText;
    private TextMeshPro textMeshPro;
    public string saveData;


    [Header("글자 흔들기")]
    private TMP_Text textComponent;
    private TMP_TextInfo textInfo;

    public float shakeAmount = 2.3f;
    public float shakeSpeed = 50f;



    void Awake()
    {
        instance = this;
        
        tmpText = GetComponent<TextMeshProUGUI>();
        textMeshPro = GetComponent<TextMeshPro>();
        textComponent = GetComponent<TMP_Text>();
        
    }


    void Start()
    {
        StartCoroutine(AnimateText());
    }


    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }


    // 텍스트를 바꾸는 공개 메서드
    IEnumerator SetText()
    {
        if (saveData == "main" && PlayerPrefs.GetInt("ending") !=0)
        {
            tmpText.text = "ALL CLEAR!!!";
        }
        else
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
        yield return null;
    }

    IEnumerator AnimateText()
    {
        yield return SetText();
        yield return new WaitForSeconds(1f);
        textComponent.ForceMeshUpdate();
        textInfo = textComponent.textInfo;

        Vector3[][] originalVertices = new Vector3[textInfo.meshInfo.Length][];
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            originalVertices[i] = textInfo.meshInfo[i].vertices.Clone() as Vector3[];
        }

        while (true)
        {
            textComponent.ForceMeshUpdate();
            textInfo = textComponent.textInfo;

            for (int i = 0; i < textInfo.characterCount; i++)
            {
                TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
                if (!charInfo.isVisible) continue;

                int materialIndex = charInfo.materialReferenceIndex;
                int vertexIndex = charInfo.vertexIndex;

                Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

                Vector3 offset = new Vector3(
                    Random.Range(-shakeAmount, shakeAmount),
                    Random.Range(-shakeAmount, shakeAmount),
                    0f);

                for (int j = 0; j < 4; j++)
                {
                    vertices[vertexIndex + j] = originalVertices[materialIndex][vertexIndex + j] + offset;
                }
            }

            // 적용
            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
                textComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
}
