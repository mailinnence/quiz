using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;



public class button_typing_mode : MonoBehaviour
{
    public Button toggleButton;               // 연결할 UI 버튼
    public TextMeshProUGUI buttonText;        // 버튼에 표시할 텍스트 (선택사항)
    public TextMeshProUGUI plainText;        // 버튼에 표시할 텍스트 (선택사항)


    public bool isOn = false; // 현재 상태 저장


    void Start()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(UpdateVisual); // 클릭 이벤트 연결
        }
    }

    void OnEnable()
    {
        ToggleState(); // 오브젝트가 활성화될 때 상태 반영
    }

    void ToggleState()
    {
        if(PlayerPrefs.GetString("set_typing_mode_save") == "on")
        {
            buttonText.text = PlayerPrefs.GetString("set_typing_mode_on") + " " +"ON";
            isOn = true;
        } 
        else
        {   buttonText.text = PlayerPrefs.GetString("set_typing_mode_on") + " " +"OFF";
            isOn = false;
        }
    }

    void UpdateVisual()
    {
        SoundManager.instance.scene_2_setting_button.Play();
        plainText.text = PlayerPrefs.GetString("set_typing_mode_plainText");
        if(isOn)
        {
            isOn = false;
            buttonText.text = PlayerPrefs.GetString("set_typing_mode_on") + " " +"OFF";
        }
        else
        {
            isOn = true;
            buttonText.text = PlayerPrefs.GetString("set_typing_mode_on") + " " +"ON";
        }
    }
}
