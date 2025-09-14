using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Progress_ui : MonoBehaviour
{

    [Header("진행률 관련 변수")]
    public int level;
    public TextMeshProUGUI myText;
    public GameObject background;
    public Button myButton;

    [SerializeField]
    private Slider hpbar;
    private float maxHp;
    public float curHp = 0;
    private float curHp_Next = 0;
    float imsi;
    string key;
    bool onefunc;
    bool onefunc_trigger;
    

    // Start is called before the first frame update
    void Start()
    {
        // 세이브 데이터 가져오기
        key = "Progress" + level;
        maxHp = PlayerPrefs.GetInt("NumQuestions");
        myText.text = $"{PlayerPrefs.GetInt(key, 0) }/{PlayerPrefs.GetInt("NumQuestions")}";
        // myText.text = $"Lv.{level + 1} - {curHp}/100";
        curHp_Next += PlayerPrefs.GetInt(key, 0);  // 없으면 0

        hpbar.value = (float) curHp / (float) maxHp;


        // 다음 레벨 활성화
        CheckUnlockNextStage();

        // 현재 레벨 활성화
        StartCoroutine(DelayedActivation());
    }




    // Update is called once per frame
    void Update()
    {
        if(!onefunc_trigger) { StartCoroutine(ProgressOnDelayed()); }

        imsi = (float) curHp / (float) maxHp;

        HandleHp();
        // test();
    }


    IEnumerator ProgressOnDelayed()
    {
        onefunc_trigger = true;
        yield return new WaitForSeconds(0.7f);
        progress_on();
    }



    void progress_on()
    {
        if (!onefunc)
        {
            onefunc = true;
            if(curHp <= maxHp) { curHp += PlayerPrefs.GetInt(key, 0); }
            else { curHp = maxHp; }       
        }
    }



    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value , imsi , Time.deltaTime * 10);
    }





    // 현재레벨보다 작고 key 가 0 이라면 비활성화 시켜야 한다.
    public void activation()
    {
        // 현재 레벨을 하나 만든다. 없다면 0으로 그러면 저장되지 않는한 단계에 맞춰서 보일 것이다. 0 부터 시작 주의
        string key = "currentLevel";
        int currentLevel = PlayerPrefs.GetInt(key, 0); // 저장된 값이 없으면 기본값 0 반환

        if (level > currentLevel)
        {
            background.GetComponent<Image>().color = new Color32(0xAB, 0xAB, 0xAB, 0xAB);
            myButton.interactable = false;
        } 
    }


    // 시간차 초기화
    private IEnumerator DelayedActivation()
    {
        yield return null; // 한 프레임 대기
        activation();
    }



    // 다음 단계 - 각 레벨을 다 풀었다면
    private void CheckUnlockNextStage()
    {
        if (curHp_Next >= maxHp)
        {
            string unlockKey = "Unlocked" + level;
            int isUnlocked = PlayerPrefs.GetInt(unlockKey, 0); // 기본값은 잠금 상태

            if (isUnlocked == 0)
            {
                PlayerPrefs.SetInt(unlockKey, 1); // 해금 처리
                
                string currentLevelKey = "currentLevel";
                int currentLevel = PlayerPrefs.GetInt(currentLevelKey, 0);

                PlayerPrefs.SetInt(currentLevelKey, level + 1);
                PlayerPrefs.Save();
            }
        }
    }




    private void test()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(curHp >= 0)
            {
                curHp += 10;
            }
            else
            {
                curHp = 0;
            }       
        }
    }


}