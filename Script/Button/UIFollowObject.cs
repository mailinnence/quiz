using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using TMPro;

public class UIFollowObject : MonoBehaviour
{
    public GameObject plainText;
    public GameObject List;
    public GameObject Check;
    public TextMeshProUGUI SettingText;
    public GameObject Setting;

    public Transform target;
    public RectTransform uiElement;
    public Vector3 offset;
    public ParticleSystem effectToPlay;


    private Button btn;

    void Start()
    {
        if (target == null || uiElement == null) return;

        Camera cam = Camera.main;
        if (cam == null) return;

        Vector3 screenPos = cam.WorldToScreenPoint(target.position + offset);
        uiElement.position = screenPos;

        btn = uiElement.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(TriggerEffect);
        }
    }

    void TriggerEffect()
    {
        if (effectToPlay != null)
        {
            SoundManager.instance.particle_menu.Play();
            effectToPlay.Play();
        }

        if (btn != null)
        {
            btn.interactable = false; // 클릭 잠금
            StartCoroutine(EnableButtonAfterDelay(1f)); // 1초 후 다시 활성화
        }
    }

    IEnumerator EnableButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (btn != null)
        {
            btn.interactable = true;
        }
    }

    // main 
    public void main()
    {
        plainText.SetActive(true);
        List.SetActive(true);
        Check.SetActive(false);
        SettingText.gameObject.SetActive(false);
        Setting.SetActive(false);
    }

    // setting
    public void setting()
    {
        SettingText.text = PlayerPrefs.GetString("set_"); 
        plainText.SetActive(false);
        List.SetActive(false);
        Check.SetActive(false);
        SettingText.gameObject.SetActive(true);
        Setting.SetActive(true);        
    }

    // developer
    public void developer()
    {
        SettingText.text = PlayerPrefs.GetString("develope_team_plainText"); 
        plainText.SetActive(false);
        List.SetActive(false);
        Check.SetActive(false);
        SettingText.gameObject.SetActive(true);
        Setting.SetActive(false);           
    }


    // inquiry
    public void inquiry()
    {
        SettingText.text = PlayerPrefs.GetString("Inquiry_plainText"); 
        plainText.SetActive(false);
        List.SetActive(false);
        Check.SetActive(false);
        SettingText.gameObject.SetActive(true);
        Setting.SetActive(false);    
    }


    

}
