using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class button_save : MonoBehaviour
{
    public button_typing_mode typing_mode;
    public button_back_mode back_mode;
    public TextMeshProUGUI plainText; 


    // 버튼에 연결할 함수
    public void SaveSettings()
    {
        SoundManager.instance.scene_2_setting_button.Play();
        // typing_mode 저장
        if (typing_mode.isOn)
            PlayerPrefs.SetString("set_typing_mode_save", "on");
        else
            PlayerPrefs.SetString("set_typing_mode_save", "off");

        // back_mode 저장
        if (back_mode.isOn)
            PlayerPrefs.SetString("set_background_save", "on");
        else
            PlayerPrefs.SetString("set_background_save", "off");

        PlayerPrefs.Save(); // 실제로 디스크에 저장
        plainText.text =  "설정 저장 완료";
    }
}
