using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Logo : MonoBehaviour
{
    [Header("Start Logo")]
    public TextMeshProUGUI[] textMesh_studio;
    public TextMeshProUGUI[] textMesh_gameName;   

    [Header("Start ui button")]
    public GameObject button;

    [Header("전환할 다음 씬 이름")]
    public string nextSceneName;

    [Header("Fade Settings")]
    public float fadeDuration = 1f;
    public float displayDuration = 1f;
    private float progress;

    void Start()
    {
        alert();
    }

    void Awake()
    {
        progress = 0;
    }


    public void alert()
    {
        StartCoroutine(FadeInOutSequence());
    }

    IEnumerator FadeInOutSequence()
    {

        // 알파 초기화
        SetAlpha(0f);

        // 페이드 인
        yield return StartCoroutine(Fade(0f, 1f));

        // 표시 유지 시간 (실시간 기준)
        yield return new WaitForSecondsRealtime(displayDuration);

        // 페이드 아웃
        yield return StartCoroutine(Fade(1f, 0f));

        progress = 1;

        // 페이드 인
        yield return StartCoroutine(Fade(0f, 1f));

        // 표시 유지 시간 (실시간 기준)
        yield return new WaitForSecondsRealtime(displayDuration);

        // 페이드 아웃
        yield return StartCoroutine(Fade(1f, 0f));

        // yield return new WaitForSecondsRealtime(0.05f);
        button.SetActive(true);
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float t = elapsedTime / fadeDuration;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(endAlpha);
    }

    void SetAlpha(float alpha)
    {
        if (progress == 0)
        {
            for (int i = 0; i < textMesh_studio.Length; i++)
            {
                if (textMesh_studio[i] != null)
                {
                    Color c = textMesh_studio[i].color;
                    c.a = alpha;
                    textMesh_studio[i].color = c;
                }
            }
        }
        else
        {
            for (int i = 0; i < textMesh_gameName.Length; i++)
            {
                if (textMesh_gameName[i] != null)
                {
                    Color c = textMesh_gameName[i].color;
                    c.a = alpha;
                    textMesh_gameName[i].color = c;
                }
            }
        }
    }



    // 버튼에 이 함수를 연결하세요
    public void Load_Scene()
    {
        // 0.버튼 비활성화
        button.SetActive(false);

        // 1. 씬 전환
        SceneManager.LoadScene(nextSceneName);

        // 2. 메모리 정리 요청
        // StartCoroutine(CleanupMemory());
    }

    private System.Collections.IEnumerator CleanupMemory()
    {
        // 1프레임 기다려 씬 로딩 후 실행
        yield return null;

        // 2. 참조가 끊긴 리소스 제거
        yield return Resources.UnloadUnusedAssets();

        // 3. 가비지 컬렉션 실행 (주의: 무조건 필요하진 않음)
        GC.Collect();
    }

}
