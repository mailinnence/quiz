using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r1_event_funtion : MonoBehaviour
{ 
    public static r1_event_funtion instance;

    void Awake()
    {
        instance = this;
    }


    // 주의 
    // Situation.instance.isEvent는 TalkManager 보다 그 수가 하나 더 많아야 한다.
    // s_1 정면 문
    public void scene_1_obj_1()
    {
        // 누를 수 있게 되서 이벤트 가능
        Situation.instance.click();
        if (Situation.instance.step ==0 ) 
        { 
            Situation.instance.step = 1; 
            fade_Object.instance.FadeSystem_init(); // 반드시 시작전에 색에 대한 초기화를 해주어야 한다.
        }
        if (Situation.instance.step == 1)
        {   // "이쪽문도 잠겨있네요."
            fade_Object.instance.FadeIn_event_c_3();
            fade_Object.instance.FadeOut_dialog_c_0();
            fade_Object.instance.FadeOut_dialog_c_1();
            fade_Object.instance.FadeOut_dialog_c_2();
            layerSetting.instance.Layer_15_cha_3();
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 3) 
        {   // "전방에 있던 메모대로 왼쪽방부터 가보는게 좋겠어요." , 
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum); 
        }
        if (Situation.instance.step == 5) 
        {   // "아!",
            layerSetting.instance.Layer_init();
            fade_Object.instance.FadeIn_dialog_c_1();
            fade_Object.instance.FadeOut_dialog_c_0();
            fade_Object.instance.FadeOut_dialog_c_2();
            fade_Object.instance.FadeOut_dialog_c_3();
            layerSetting.instance.Layer_15_cha_1();
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum); 
        }
        if (Situation.instance.step == 7)
        {   // "아! 수갑...미안해요 ",
            layerSetting.instance.Layer_init();
            fade_Object.instance.FadeIn_dialog_c_0();
            fade_Object.instance.FadeOut_dialog_c_1();
            fade_Object.instance.FadeOut_dialog_c_2();
            fade_Object.instance.FadeOut_dialog_c_3();
            layerSetting.instance.Layer_15_cha_0();
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 9)
        {   // "조심할께요" , 
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 11)
        {   // "일단 돌아가보죠.",
            layerSetting.instance.Layer_init();
            fade_Object.instance.FadeIn_dialog_c_2();
            fade_Object.instance.FadeOut_dialog_c_0();
            fade_Object.instance.FadeOut_dialog_c_1();
            fade_Object.instance.FadeOut_dialog_c_3();
            layerSetting.instance.Layer_15_cha_2();
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 13)
        {   // "이게 뭐하는 건지"
            fade_Object.instance.FadeOut_event_c_all();
            layerSetting.instance.Layer_init();
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 15)
        {
            
            Situation.instance.isEvent(Situation.instance.eventNum);
            Situation.instance.init();
        }

    }

    // 책장
    public void scene_1_obj_2()
    {
        Situation.instance.click();
        if (Situation.instance.step ==0 ) { Situation.instance.step = 1;}
        if (Situation.instance.step == 1)
        {
            Situation.instance.step++; 
            Scene_Fade_black.instance.SetAlphaTo255(); // 중앙 대화창을 위해서 어두워짐
            
            Situation.instance.isEvent_Mid(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 3)
        {
            Situation.instance.step++; 
            Situation.instance.isEvent_Mid(Situation.instance.eventNum);
        }
        if(Situation.instance.step == 5)
        {
            Scene_Fade_black.instance.SetAlphaTo0(); // 중앙 대화창을 다하여 밝아짐
            
            Situation.instance.isEvent_Mid(Situation.instance.eventNum);
            Situation.instance.init();
        }
    }

    // 바닥의 피
    public void scene_1_obj_3()
    {
        Situation.instance.click();
        if (Situation.instance.step ==0 ) { Situation.instance.step = 1;}
        if (Situation.instance.step == 1)
        {
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 3)
        {
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if(Situation.instance.step == 5)
        {
            
            Situation.instance.isEvent(Situation.instance.eventNum);
            Situation.instance.init();
        }
    }

    // 전등
    public void scene_1_obj_4()
    {
        Situation.instance.click();
        if (Situation.instance.step ==0 ) { Situation.instance.step = 1;}
        if (Situation.instance.step == 1)
        {
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 3)
        {
            
            Situation.instance.isEvent(Situation.instance.eventNum);
            Situation.instance.init();
        }
    }

    // 철장
    public void scene_1_obj_5()
    {
        Situation.instance.click();
        if (Situation.instance.step ==0 ) { Situation.instance.step = 1;}
        if (Situation.instance.step == 1)
        {
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 3)
        {
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if(Situation.instance.step == 5)
        {
            
            Situation.instance.isEvent(Situation.instance.eventNum);
            Situation.instance.init();
        }
    }


    // usb 
    public void scene_1_obj_6()
    {
        Situation.instance.click();
        if (Situation.instance.step ==0 ) { Situation.instance.step = 1;}
        if (Situation.instance.step == 1)
        {
            tool_inventory.instance.item_list.Add("r1_usb"); // 저장
            // save_System.instance.save_Scene_r_1_usb();
            Situation.instance.step++; 
            Situation.instance.isEvent(Situation.instance.eventNum);
        }
        if (Situation.instance.step == 3)
        {
            
            Situation.instance.isEvent(Situation.instance.eventNum);
            Situation.instance.init();
        }
    }



}
