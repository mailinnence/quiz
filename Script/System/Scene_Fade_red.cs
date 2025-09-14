using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scene_Fade_red : MonoBehaviour
{

    public Image Panel;
    float time = 0f;
    public float F_time = 0.08f;
    public float alpha_red;

    public static Scene_Fade_red instance;

    void Awake()
    {
        instance = this;
    }


    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }



    // 켜졌다가 꺼지는 함수 - 시간 간격이 짧음
    IEnumerator FadeFlow()
    {
        // Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < alpha_red)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, alpha_red, time);
            Panel.color = alpha;
            yield return null;
        }

        time = 0f;

        yield return new WaitForSeconds(0.02f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(alpha_red, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        // Panel.gameObject.SetActive(false);
        yield return null;
    }




}
