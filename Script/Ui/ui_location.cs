using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ui_location : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Image image1;
    public Image image2;
    public float fadeDuration = 1f;
    public float displayDuration = 1f;
    public GameObject[] objects; // ui 시 접근 불가능


    void Start()
    {
        alert();
        object_Off(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            alert();
        }
    }


    public void alert()
    {
        StartCoroutine(FadeInOutSequence());
    }


    IEnumerator FadeInOutSequence()
    {
        // 게임 일시정지
        Time.timeScale = 0f;

        // 알파 초기화
        SetAlpha(0f, 0f);

        // 페이드 인
        yield return StartCoroutine(Fade(0f, 1f, 0f, 105f / 255f));

        // 표시 유지 시간 (실시간 기준)
        yield return new WaitForSecondsRealtime(displayDuration);

        // 페이드 아웃
        yield return StartCoroutine(Fade(1f, 0f, 105f / 255f, 0f));

        // 게임 재개
        Time.timeScale = 1f;
        object_On();
        
    }


    IEnumerator Fade(float startAlpha1, float endAlpha1, float startAlpha2, float endAlpha2)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float t = elapsedTime / fadeDuration;
            float alpha1 = Mathf.Lerp(startAlpha1, endAlpha1, t);
            float alpha2 = Mathf.Lerp(startAlpha2, endAlpha2, t);
            SetAlpha(alpha1, alpha2);
            yield return null;
        }

        SetAlpha(endAlpha1, endAlpha2);
    }

    void SetAlpha(float alpha1, float alpha2)
    {
        textMesh.alpha = alpha1;
        image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, alpha1);
        image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, alpha2);
    }


    // 오브젝트 활성화
    void object_On()
    {
        
        for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].SetActive(true);
                }
            }
    }


    // 오브젝트 비활성화
    void object_Off()
    {
        
        for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].SetActive(false);
                }
            }
    }

}
