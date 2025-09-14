using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextShaker : MonoBehaviour
{
    private TMP_Text textComponent;
    private TMP_TextInfo textInfo;

    public float shakeAmount = 2.3f;
    public float shakeSpeed = 50f;


    public static TextShaker instance;

    void Awake()
    {
        instance = this;
        textComponent = GetComponent<TMP_Text>();
    }

 

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
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
