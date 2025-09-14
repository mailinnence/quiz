// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.UI;
// using UnityEngine;

// public class charater_fade : MonoBehaviour
// {


//     public Image[] charter;

//     float time = 0f;
//     public float F_time = 0.2f;
//     public float fadeDuration = 1.5f; // 페이드 인 지속 시간


//     public static charater_fade instance;


//     void Awake()
//     {
//         instance = this;
//     }


//     // 등장 --------------------------------------------------------------------------------------------------
//     // 캐릭터 등장 - 페이드 인
//     public void FadeIn_event_c_all()
//     {
//         StartCoroutine(FadeIn_event_Coroutine(characters[0]));
//         StartCoroutine(FadeIn_event_Coroutine(characters[1]));
//         StartCoroutine(FadeIn_event_Coroutine(characters[2]));
//         StartCoroutine(FadeIn_event_Coroutine(characters[3]));
//     }


//     // ------------------------------------------------------------------------------------------------------






//     // 대화 --------------------------------------------------------------------------------------------------



//     // ------------------------------------------------------------------------------------------------------






//     // 캐릭터 등장
//     IEnumerator FadeIn_event_Coroutine(SpriteRenderer targetRenderer)
//     {
//         float time = 0f;

//         Color originalColor = targetRenderer.color;
//         Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // 알파 값만 1로 설정

//         while (time < 1f)
//         {
//             time += Time.deltaTime / F_time;
//             targetRenderer.color = Color.Lerp(originalColor, targetColor, time);
//             yield return null;
//         }

//         yield return null;
//     }




// }
