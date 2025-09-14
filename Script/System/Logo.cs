using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Logo : MonoBehaviour
{

    public GameObject Click;    // 활성화할 UI 오브젝트
    private bool click_;
    public GameObject scatter;  // 활성화할 UI 오브젝트
    public List<GameObject> etcList;
    


    void Start()
    {
        StartCoroutine(StartSequence());
    }


    IEnumerator StartSequence()
    {
        yield return loading.instance.FirstPlay();
        TalkManager.instance.GenerateData_Start();
        yield return new WaitForSeconds(0.01f);
        Situation1.instance.StartEvent(1);
        yield return new WaitForSeconds(4f);
        Situation1.instance.deactivate();
        yield return new WaitForSeconds(0.1f);
        SoundManager.instance.scene_1_start_background.loop = true;
        SoundManager.instance.scene_1_start_background.Play();
        yield return new WaitForSeconds(0.5f);
        
        // 모든 씬 해당
        Scene_Fade_black.instance.Fade();
        // SoundManager.instance.scene_1_start_background.Play();

         // Scene_Fade_black.instance.Fade(); 
        StartCoroutine(TextAfterDelay(1f));
        // StartCoroutine(ActivateUIAfterDelay(2f));
    }



    void Update()
    {
        if (click_ && IsInputDown())
        {
            SoundManager.instance.scene_1_start_background.Stop();
            SoundManager.instance.textScatter();
            Camera.main.backgroundColor = Color.black;
            scatter.SetActive(true);
            foreach (GameObject obj in etcList)
            {
                if (obj != null)
                    obj.SetActive(false);
            }

            clickFade();
            StartCoroutine(LoadSceneAfterDelay(2f));
            // Scene_Fade_black.instance.SetAlphaTo255();
        }
    }


    // 제목 텍스트 활성화
    IEnumerator TextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Situation.instance.StartEvent(-2);

        yield return new WaitForSeconds(0.5f);
        Click.SetActive(true); 
        click_ = true;
        
    }



    // 클릭 버튼 활성화
    IEnumerator ActivateUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Click.SetActive(true); 
        click_ = true;
    }


    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 여기서 "NextSceneName"을 실제 이동할 씬 이름으로 바꿔주세요
        SceneManager.LoadScene("2.Choice");
    }



    void clickFade()
    {
        Text uiText = gameObject.GetComponent<Text>();
        if (uiText != null)
        {
            Color c = uiText.color;
            c.a = 0f;
            uiText.color = c;
        }
    }



    // 마우스 클릭 또는 터치 입력 체크
    bool IsInputDown()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        return Input.GetMouseButtonDown(0);
#elif UNITY_IOS || UNITY_ANDROID
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
#else
        return false;
#endif
    }


}
