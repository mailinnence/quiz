using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extention_ui : MonoBehaviour
{
    public GameObject[] stageObjects; // 인스펙터에서 오브젝트들을 넣어주세요

    void Start()
    {
        SoundManager.instance.menu_sound.Play();

        for (int i = 0; i < stageObjects.Length; i++)
        {
            if (stageObjects[i] != null)
            {
                // NumStages보다 작으면 활성화, 아니면 비활성화
                stageObjects[i].SetActive(i < PlayerPrefs.GetInt("NumStages"));
            }
        }
    }
}
