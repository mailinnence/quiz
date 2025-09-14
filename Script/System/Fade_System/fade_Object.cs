using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class fade_Object : MonoBehaviour
{
    public SpriteRenderer[] characters; // SpriteRenderer 배열로 변경

    float time = 0f;
    public float F_time = 0.2f;
    public float fadeDuration = 1.5f; // 페이드 인 지속 시간 


    public static fade_Object instance;


    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            FadeSystem_init();
        }
    }
    // 초기화
    public void FadeSystem_init()
    {
        FadeSystem_init_(characters[0]);
        FadeSystem_init_(characters[1]);
        FadeSystem_init_(characters[2]);
        FadeSystem_init_(characters[3]);
    }





    // 등장 --------------------------------------------------------------------------------------------------
    
    // 캐릭터 등장 - 캐릭터가 밝은 상태로 나타남
    public void FadeIn_event_c_0() { StartCoroutine(FadeIn_event_Coroutine(characters[0])); }
    public void FadeIn_event_c_1() { StartCoroutine(FadeIn_event_Coroutine(characters[1])); }
    public void FadeIn_event_c_2() { StartCoroutine(FadeIn_event_Coroutine(characters[2])); }
    public void FadeIn_event_c_3() { StartCoroutine(FadeIn_event_Coroutine(characters[3])); }


    // 캐릭터가 사라짐
    public void FadeOut_event_c_0() { StartCoroutine(FadeOut_event_Coroutine(characters[0])); }
    public void FadeOut_event_c_1() { StartCoroutine(FadeOut_event_Coroutine(characters[1])); }
    public void FadeOut_event_c_2() { StartCoroutine(FadeOut_event_Coroutine(characters[2])); }
    public void FadeOut_event_c_3() { StartCoroutine(FadeOut_event_Coroutine(characters[3])); }



    public void FadeIn_event_c_all()
    {
        StartCoroutine(FadeIn_event_Coroutine(characters[0]));
        StartCoroutine(FadeIn_event_Coroutine(characters[1]));
        StartCoroutine(FadeIn_event_Coroutine(characters[2]));
        StartCoroutine(FadeIn_event_Coroutine(characters[3]));
    }


    // 캐릭터 아웃 - 페이드 아웃
    public void FadeOut_event_c_all()
    {
        StartCoroutine(FadeOut_event_Coroutine(characters[0]));
        StartCoroutine(FadeOut_event_Coroutine(characters[1]));
        StartCoroutine(FadeOut_event_Coroutine(characters[2]));
        StartCoroutine(FadeOut_event_Coroutine(characters[3]));
    }

    // ------------------------------------------------------------------------------------------------------






    // 대화 --------------------------------------------------------------------------------------------------
    // 캐릭터 대화 - 캐릭터 어두워지면서 나타남
    public void FadeOut_dialog_c_0() { FadeOut_dialog(characters[0]); }
    public void FadeOut_dialog_c_1() { FadeOut_dialog(characters[1]); }
    public void FadeOut_dialog_c_2() { FadeOut_dialog(characters[2]); }
    public void FadeOut_dialog_c_3() { FadeOut_dialog(characters[3]); }


    // 캐릭터 대화 - 캐릭터 밝아짐 나타나진 않음음
    public void FadeIn_dialog_c_0() { FadeIn_dialog(characters[0]); }
    public void FadeIn_dialog_c_1() { FadeIn_dialog(characters[1]); }
    public void FadeIn_dialog_c_2() { FadeIn_dialog(characters[2]); }
    public void FadeIn_dialog_c_3() { FadeIn_dialog(characters[3]); }

    /*
    layerSetting.instance.Layer_init();
    layerSetting.instance.Layer_15_cha_0();
    layerSetting.instance.Layer_15_cha_1();
    layerSetting.instance.Layer_15_cha_2();
    layerSetting.instance.Layer_15_cha_3();
    */


    // 캐릭터 대화 - 캐릭터 밝아짐
    public void FadeIn_dialog_c_all()
    {
        layerSetting.instance.Layer_init();
        FadeIn_dialog(characters[0]);
        FadeIn_dialog(characters[1]);
        FadeIn_dialog(characters[2]);
        FadeIn_dialog(characters[3]);
    }
    // ------------------------------------------------------------------------------------------------------













    // 대화중 페이드 아웃 관련 함수 
    // 밝아짐
    public void FadeIn_dialog(SpriteRenderer targetCharacter)
    {
        StartCoroutine(FadeIn_dialog_Coroutine(targetCharacter));
    }

    // 어두워짐
    public void FadeOut_dialog(SpriteRenderer targetCharacter)
    {
        StartCoroutine(FadeOut_dialog_Coroutine(targetCharacter));
    }








    // 캐릭터 등장 관련 코루틴
    IEnumerator FadeIn_event_Coroutine(SpriteRenderer targetRenderer)
    {
        float time = 0f;

        Color originalColor = targetRenderer.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // 알파 값만 1로 설정

        while (time < 1f)
        {
            time += Time.deltaTime / F_time;
            targetRenderer.color = Color.Lerp(originalColor, targetColor, time);
            yield return null;
        }

        yield return null;
    }

    // 캐릭터 등장 아웃 관련 코루틴
    IEnumerator FadeOut_event_Coroutine(SpriteRenderer targetRenderer)
    {
        float time = 0f;

        Color originalColor = targetRenderer.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // 알파 값만 0으로 설정

        while (time < 1f)
        {
            time += Time.deltaTime / F_time;
            targetRenderer.color = Color.Lerp(originalColor, targetColor, time);
            yield return null;
        }

        yield return null;
    }


    // 캐릭터 대화 - 어두워짐
    IEnumerator FadeOut_dialog_Coroutine(SpriteRenderer targetRenderer)
    {
        time = 0f;

        Color originalColor = targetRenderer.color;
        Color targetColor = new Color(130f / 255f, 130f / 255f, 130f / 255f, 255f / 255f); // A4A1A1

        while (time < 1f)
        {
            time += Time.deltaTime / F_time;
            targetRenderer.color = Color.Lerp(originalColor, targetColor, time);
            yield return null;
        }

        yield return null;
    }

    // // 캐릭터 대화 - 밝아짐
    IEnumerator FadeIn_dialog_Coroutine(SpriteRenderer targetRenderer)
    {
        time = 0f;

        Color startColor = new Color(130f / 255f, 130f / 255f, 130f / 255f,  targetRenderer.color.a); // A4A1A1
        Color endColor = new Color(1f, 1f, 1f, targetRenderer.color.a); // FFFFFF

        while (time < 1f)
        {
            time += Time.deltaTime / F_time;
            targetRenderer.color = Color.Lerp(startColor, endColor, time);
            yield return null;
        }

        yield return null;
    }



    // 초기화 메서드 - 타겟의 색을 완전히 투명한 흰색으로 변경
    public void FadeSystem_init_(SpriteRenderer targetRenderer)
    {
        targetRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

}
