using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [Header("게임 시스템 관련 여부")] 
    public bool click_deable;       // 마우스로 오브텍트 클릭 여부 변수 : false 일때만 클릭 가능 모든 오브젝트를 클릭하지 않아야 할때만 사용 


    [Header("게임 관련 지수 및 상태")]    
    public int GameProgress;              // 게임의 진행도
    public string current__Click_Item;    // 현재 선택된 아이템 



    void Start()
    {
        // Application.targetFrameRate = 60;  
    }


    void Awake()
    {
        instance = this;
    }



}
