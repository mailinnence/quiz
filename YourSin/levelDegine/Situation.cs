using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System; 


public class Situation : MonoBehaviour
{

    [Header("ui 관련 변수")]    
    public static Situation instance;
    public GameObject button;
    public TalkManager talkManager;
    public TypeEffect talk;
    public TextMeshProUGUI talkText;  
    public int talkIndex;

    public TypeEffect talk_Mid;
    public TextMeshProUGUI talkText_Mid;  
    public int talkIndex_Mid;

    [Header("현재 상황 관련 변수")]
    public int event_scene;
    public int event_obj;
    public int step;
    public int eventNum;


    void Awake()
    {
        instance = this;
    }



    // 상황 초기화 함수
    public void Situation_Funtion(int scene, int obj)
    {
        event_scene = scene; event_obj = obj; step = 0;
        // if(scene == 1 && obj == 1) { event_scene = scene; event_obj = obj; step = 0;}
    }



    private Dictionary<(int, int), Action> eventMap = new();

    void Start()
    {
        eventMap.Add((1, 1), r1_event_funtion.instance.scene_1_obj_1);
        eventMap.Add((1, 2), r1_event_funtion.instance.scene_1_obj_2);
        eventMap.Add((1, 3), r1_event_funtion.instance.scene_1_obj_3);
        eventMap.Add((1, 4), r1_event_funtion.instance.scene_1_obj_4);
        eventMap.Add((1, 5), r1_event_funtion.instance.scene_1_obj_5);
        eventMap.Add((1, 6), r1_event_funtion.instance.scene_1_obj_6);
    }

    void Update()
    {
        var key = (event_scene, event_obj);
        if (eventMap.ContainsKey(key))
        {
            eventNum = event_obj;
            eventMap[key].Invoke();
        }
    }

    // 초기화
    public void init()
    {
        step = 0;
        event_scene = 0; 
        event_obj = 0;

        r1_Object_search.instance.EnableAllObjects();
        fade_Object.instance.FadeOut_event_c_all();
        layerSetting.instance.Layer_init();
        
    }


    // 하단 대화창
    public void isEvent(int obj)
    {
        // ui 변경
        talkText.gameObject.SetActive(true);
        talkText_Mid.gameObject.SetActive(false);
        button.SetActive(false);

        // 오브젝트의 정보 가지고 오기
        Talk(obj);
    }


    public void Talk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            talkText.gameObject.SetActive(false);
            button.SetActive(true);
            talkIndex = 0;

            // 마우스 처리 해체
            Cursor.visible = true;

            return;
        }

        talk.SetMsg(talkData);
        // talkText.text = talkData;
        talkIndex++;
    }


    // 중단 대화창
    public void isEvent_Mid(int obj)
    {
        // ui 변경
        talkText.gameObject.SetActive(false);
        talkText_Mid.gameObject.SetActive(true);
        button.SetActive(false);

        // 오브젝트의 정보 가지고 오기
        Talk_Mid(obj);
    }


    public void Talk_Mid(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            talkText_Mid.gameObject.SetActive(false);
            button.SetActive(true);
            talkIndex = 0;

            // 마우스 처리 해체
            Cursor.visible = true;

            return;
        }

        talk_Mid.SetMsg(talkData);
        // talkText.text = talkData;
        talkIndex++;
    }



    public void click()
    {
        if (IsInputDown() || Input.GetButtonDown("click"))
        {
            Vector2 inputPos;

            #if UNITY_EDITOR || UNITY_STANDALONE
                inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            #elif UNITY_IOS || UNITY_ANDROID
                inputPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            #endif

            step++;
        }    

    }




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



/*
    // 각 상황에 대한 반응
    void Update()
    {
        // room_1
        if(event_scene == 1 && event_obj == 1) { eventNum = event_obj; r1_event_funtion.instance.scene_1_obj_1(); }
        if(event_scene == 1 && event_obj == 2) { eventNum = event_obj; r1_event_funtion.instance.scene_1_obj_2(); }
        if(event_scene == 1 && event_obj == 3) { eventNum = event_obj; r1_event_funtion.instance.scene_1_obj_3(); }
        if(event_scene == 1 && event_obj == 4) { eventNum = event_obj; r1_event_funtion.instance.scene_1_obj_4(); }
        if(event_scene == 1 && event_obj == 5) { eventNum = event_obj; r1_event_funtion.instance.scene_1_obj_5(); }
        if(event_scene == 1 && event_obj == 6) { eventNum = event_obj; r1_event_funtion.instance.scene_1_obj_6(); }
    }



*/