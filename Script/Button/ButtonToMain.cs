using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToMain : MonoBehaviour
{

    // Progress0 ~ Progress4
    public string level;
    string key;

    [Header("체크창")]
    public GameObject start;
    public GameObject check;
    
    public Progress_ui progress_ui;


    public void Click()
    {


        // save data 가져오기 --------------------------------------------------------
        // 진행할 레벨
        key = "Progress" + level;
        SaveManager.instance.CurrentLevel = key;

        // 진행할 레벨의 진행률
        if (PlayerPrefs.HasKey(key))
        {
            SaveManager.instance.CurrentProgress = PlayerPrefs.GetInt(key) - 1;
        }
        else
        {
            SaveManager.instance.CurrentProgress = 0;
        }


        // 진행률이 0 이거나 마지막 문제라면 즉 한 문제라도 풀지 않았거나 다 풀었다면 바로 시작
        if (progress_ui.curHp == 0 || SaveManager.instance.CurrentProgress == PlayerPrefs.GetInt("NumQuestions") - 1 )
        {
            // 폭발 연출 다음씬
            SaveManager.instance.CurrentProgress = 0;
            SoundManager.instance.textScatter();
            SoundManager.instance.menu_sound.Stop();
            Scatter.instance.NextScene();  
            SaveManager.instance.AssignRandomSeason(); 
            
        }

        // 진행률에 저장이 되어 있거나 즉 한 문제라도 풀었다면 이어서 할지 초기화할지 선택
        else if (progress_ui.curHp != 0 && SaveManager.instance.CurrentProgress < PlayerPrefs.GetInt("NumQuestions") - 1)
        {
            SoundManager.instance.scene_2_setting_button.Play();
            start.SetActive(false);
            check.SetActive(true);
        }

        Debug.Log($"{SaveManager.instance.CurrentLevel} : {SaveManager.instance.CurrentProgress}");
    }



    // 진행률과 다르게 처음부터 다시 시작하니 진행률을 초기화 한다. 단 save data는 수정하지 않는다.
    public void start_button()
    {
        SaveManager.instance.CurrentProgress = 0;
        SoundManager.instance.textScatter();
        SoundManager.instance.menu_sound.Stop();
        Scatter.instance.NextScene();  
        SaveManager.instance.AssignRandomSeason(); 

    }


    // save data 기준으로 진행
    public void check_button()
    {
        SaveManager.instance.CurrentProgress += 1;
        SoundManager.instance.textScatter();
        SoundManager.instance.menu_sound.Stop();
        Scatter.instance.NextScene();  
        SaveManager.instance.AssignRandomSeason(); 
    }


    // 뒤로 가기
    public void back_button()
    {
        SoundManager.instance.scene_2_setting_button.Play();
        start.SetActive(true);
        check.SetActive(false);
    }


}

