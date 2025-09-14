using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonSolve : MonoBehaviour
{

    public TextMeshProUGUI select;
    public string answer;




    // Start is called before the first frame update
    public void Click_()
    {  
        answer = SaveManager.instance.answer;
        if(select.text == answer)
        {
            SoundManager.instance.anser_sound();
            SaveManager.instance.CurrentProgress += 1;
            QuizManager.instance.quizText.text = "";
            QuizManager.instance.quizUI_deactivate();
            QuizManager.instance.quiz_init(1);

            scene3.instance.jump4();
            scene3.instance.coinScatter_();
            scene3.instance.answer_SetActive();
    
        
        } 
        else if(select.text != answer)
        {
            // Debug.Log("오답");
            SoundManager.instance.scene_3_wrong.Play();
            Scene_Fade_red.instance.Fade(); // 화면 잠시 빨간색
            camera_shake.instance.Shake(); // 틀리면 카메라 흔들림
            scene3.instance.dead();

        } 
        
        EventSystem.current.SetSelectedGameObject(null);
    }





}
