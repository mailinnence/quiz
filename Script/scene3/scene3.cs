using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using TMPro;

public class scene3 : MonoBehaviour
{
    public static scene3 instance;

    [Header("카운트 다운")]
    public TMP_Text uiText;  // Text -> TMP_Text 로 변경
    
    [Header("게임 오버")] // 진도를 셀때도 이를 활용한다. 
    public TMP_Text gameOver;
    public GameObject[] gameOver_obj;
    public bool once_gameOver;

    [Header("클리어")] 
    public bool clear;


    public int life;
    public GameObject[] character;
    public ParticleSystem[] particle_;
    public bool textShackeChange;
    public float textShackeInt;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    void Start()
    {
        life = 4;
        StartCoroutine(DelayedStartGame());
   
    }


    void Update()
    {
        if(life <= 0 && !once_gameOver)
        {
            once_gameOver = true;
            gameOver_();
        }
        clear_SetActive();
    }





    // 시작
    IEnumerator DelayedStartGame()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.instance.particle_solve.Play();
        foreach (ParticleSystem ps in particle_) { if (ps != null) ps.Play(); }         // 파티클
        foreach (GameObject cha in character) { if (cha != null) cha.SetActive(true); } // 캐릭터 생성

        SoundManager.instance.solve_sound_();

        yield return new WaitForSeconds(2f);
        GameManager.instance.run = true;
        GameManager.instance.paradox = true;


        StartCoroutine(CountDownCoroutine()); // 카운트 다운
    }




    // 카운트 다운
    void countDownStart()
    {
        StartCoroutine(CountDownCoroutine());
    }



    IEnumerator CountDownCoroutine()
    {
        for (int i = 3; i >= 1; i--)
        {
            SoundManager.instance.countDown_r.Play();
            uiText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        SoundManager.instance.countDown_s.Play();
        uiText.text = "start!";
        yield return new WaitForSeconds(1f);
        uiText.text = "";
        GameManager.instance.first_quiz = true;
    }





    // 문제 정답 시 - 캐릭터 점프 + 동전 scatter
    // 점프
    public void jump4()
    {
        foreach (GameObject cha in character)
        {
            if (cha != null)
            {
                character ch = cha.GetComponent<character>();
                if (ch != null)
                {
                    ch.Jump();
                }
            }
        }
    }






    // 동전 흩뿌리기
    public void coinScatter()
    {
        for (int i = 0; i < 3; i++)
        {
            float ranX = Random.Range(-1.0f, 1.0f);
            float ranY = Random.Range(-4.0f, -1.0f);

            // 7, 8, 9 중 하나를 랜덤으로 선택
            int randomPoolID = Random.Range(7, 10);

            GameObject coinDustEffect = PoolManager.instance.Get(randomPoolID);
            coinDustEffect.transform.position = new Vector3(ranX, ranY, 0f);
        }
    }

    public void coinScatter_()
    {
        StartCoroutine(coinScatter_Coroutine());
    }

    IEnumerator coinScatter_Coroutine()
    {
        coinScatter();
        yield return new WaitForSeconds(0.01f);
        coinScatter();
        yield return new WaitForSeconds(0.01f);
        coinScatter();
    }
    


    // 문제가 틀렸을 경우 - 케릭터 사망
    public void dead()
    {
        if (life <= 0)
            return; // life가 0 이하이면 더 이상 처리하지 않음

        life--; // life 감소

        if (life >= 0 && life < character.Length)
        {
            GameObject cha = character[life];
            if (cha != null)
            {
                character ch = cha.GetComponent<character>();
                if (ch != null)
                {
                    ch.Dead(); // 캐릭터의 dead 함수 호출
                }
            }
        }
        // 모바일일 때만 진동
    #if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
    #endif

    }



    // 게임 오버
    void gameOver_()
    {
        StartCoroutine(ShowGameOverTextWithDelay());
        
        foreach (GameObject obj in gameOver_obj)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }


    IEnumerator ShowGameOverTextWithDelay()
    {
        saveCurrentProgress();
        SaveManager.instance.state = "gameOver";
        gameOver.text = "Game Over...";
        yield return new WaitForSeconds(1f);
        gameOver.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        Scene_Fade_black.instance.fadeIn_ui_slow();
        yield return new WaitForSeconds(2f);
        SoundManager.instance.stop_solve_sound();
        SceneManager.LoadScene("4.state");
    }



    public void answer_SetActive()
    {
        StartCoroutine(ShowAndHideAnswer());
    }


    private IEnumerator ShowAndHideAnswer()
    {
        gameOver.text = $"{SaveManager.instance.CurrentProgress}/{SaveManager.instance.lastProgress + 1}";
        gameOver.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        gameOver.gameObject.SetActive(false);
    }


    public void clear_SetActive()
    {
        if (SaveManager.instance.CurrentProgress > SaveManager.instance.lastProgress && !clear)
        {
            clear = true;
            StartCoroutine(clear_SetActive_delay());
        }
    }


    private IEnumerator clear_SetActive_delay()
    {
        saveCurrentProgress();

        yield return new WaitForSeconds(3f);
        gameOver.text = $"All Clear!";
        gameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Scene_Fade_black.instance.fadeIn_ui_slow();
        yield return new WaitForSeconds(3f);
        SoundManager.instance.stop_solve_sound();
        SceneManager.LoadScene("4.state");

    }


    private void saveCurrentProgress()
    {
        SaveManager.instance.state = "state";
        string key = SaveManager.instance.CurrentLevel;
        int valueToSave = SaveManager.instance.CurrentProgress;

        if (valueToSave > PlayerPrefs.GetInt(key)) 
        {
            // 저장
            PlayerPrefs.SetInt(key, valueToSave);
            PlayerPrefs.Save(); // 변경 사항 확실히 저장

            if(PlayerPrefs.GetInt(key) == PlayerPrefs.GetInt("NumQuestions"))
            {   
                PlayerPrefs.SetInt("play", PlayerPrefs.GetInt("play") + 1);

                if (PlayerPrefs.GetInt("play") < PlayerPrefs.GetInt("NumStages") &&  PlayerPrefs.GetInt("ending") == 0 )
                {
                    SaveManager.instance.state = "clear";
                }
                else
                {   
                    PlayerPrefs.SetInt("ending", 1);
                    SaveManager.instance.state = "all_clear";
                }
                PlayerPrefs.Save();
            }
        }
    }

}

