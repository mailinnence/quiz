using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class r1_Object_search : MonoBehaviour
{ 
    public static r1_Object_search instance;


    public GameObject[] obj;

    public GameObject scanObject;       // 현재 클릭한 대화 오브젝트

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // 중복 객체 방지
        }
    }
 

    public void isEvent(GameObject scanObj)
    {
        // 마우스 처리
        Cursor.visible = false; // 마우스 커서 보이기

        // 클릭한 오브젝트 찾기
        scanObject = scanObj;
        r1_Object_Click ObjData = scanObject.GetComponent<r1_Object_Click>();
            
        // 다른 오브젝트 비활성화
        DisableAllObjects();

        // 시뮤레이션 작동
        Situation.instance.Situation_Funtion(ObjData.scene, ObjData.obj);

    }



    // 오브젝트 활성화
    public void EnableAllObjects()
    {
        foreach (GameObject o in obj)
        {
            o.SetActive(true);
        }
    }



    // 오브젝트 비활성화
    public void DisableAllObjects()
    {
        foreach (GameObject o in obj)
        {
            o.SetActive(false);
        }
    }






}
