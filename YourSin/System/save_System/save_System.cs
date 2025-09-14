using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_System : MonoBehaviour
{

    public static save_System instance;

    public GameObject[] save_Obj;                                   // 인 게임 오브젝트 씬 정보 저장


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        save_obejctScene_load();    // 오브젝트 씬 정보 로드 

    }

    // 오브젝트 씬 정보 로드 
    public void save_obejctScene_load()
    {
        for (int i = 0; i < save_Obj.Length; i++)
        {
            r1_Object_Click r1Obj = save_Obj[i].GetComponent<r1_Object_Click>();
            int savedScene = PlayerPrefs.GetInt("r1_door", 1); 
            r1Obj.scene = savedScene;
        }
    }

    // r1
    public void save_Scene_r_1_usb()
    {
        r1_Object_Click r1Obj = save_Obj[0].GetComponent<r1_Object_Click>();

        r1Obj.scene += 1; 
        PlayerPrefs.SetInt("r1_door", r1Obj.scene);
    }

}
