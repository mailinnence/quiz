using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TGenerate : MonoBehaviour
{
    [TextArea(3, 10)]
    public string inputText = "";

    public PoolManager poolManager;               // PoolManager 연결
    public float charSpacing = 1f;                // 기본 글자 간격 (글자 너비에 추가로 더할 간격)
    public float lineSpacing = 1.2f;              // 줄 간격
    public Transform centerPoint;                 // 중앙 기준 위치

    public int maxCharsPerLine = 100;              // 한 줄 최대 글자 수 (필요 시 제한)

    private TextMeshPro tempTMP;                   // 글자 너비 측정을 위한 임시 TMP 오브젝트

    void Start()
    {
        // 임시 TMP 오브젝트 하나만 만들어서 재활용
        GameObject tempObj = poolManager.Get(0);
        tempObj.SetActive(true);
        tempTMP = tempObj.GetComponent<TextMeshPro>();

        // 임시 TMP 오브젝트는 비활성화 처리 (너비 계산 끝났으므로)
        tempObj.SetActive(false);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SpawnTextFromPool();
        }
    }




    void SpawnTextFromPool()
    {
        string[] lines = inputText.Split('\n');

        for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            string line = lines[lineIndex];

            // 글자 수 제한 적용
            if (line.Length > maxCharsPerLine)
                line = line.Substring(0, maxCharsPerLine);

            int charCount = line.Length;

            List<float> charWidths = new List<float>();
            float lineWidth = 0f;

            for (int i = 0; i < charCount; i++)
            {
                // GetPreferredValues 사용으로 ForceMeshUpdate 없이 글자 너비 계산
                Vector2 size = tempTMP.GetPreferredValues(line[i].ToString());
                float charWidth = size.x;
                charWidths.Add(charWidth);

                lineWidth += charWidth;
                if (i < charCount - 1)
                    lineWidth += charSpacing;
            }

            // 중앙 정렬 시작 X 좌표 계산
            float startX = -lineWidth / 2f;
            float currentX = startX;

            for (int i = 0; i < charCount; i++)
            {
                GameObject letterObj = poolManager.Get(0);
                letterObj.SetActive(true);
                TextMeshPro tmp = letterObj.GetComponent<TextMeshPro>();
                tmp.text = line[i].ToString();

                // 부모 설정 & localPosition 지정
                letterObj.transform.SetParent(centerPoint, false);

                float xPos = currentX + (charWidths[i] / 2f);
                float yPos = -lineIndex * lineSpacing;

                letterObj.transform.localPosition = new Vector3(xPos, yPos, 0);

                currentX += charWidths[i] + charSpacing;
            }
        }
    }
}
