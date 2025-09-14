using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class timer : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    private float maxHp = 100;
    public float curHp = 100;
    float imsi;
    public float time;
    public List<TextShaker> textShakers;



    // Start is called before the first frame update
    void Start()
    {
        hpbar.value = (float) curHp / (float) maxHp;
    
    }


    // Update is called once per frame
    void Update()
    {

        if(curHp >= 0)
        {
            curHp -= time * Time.deltaTime;
        }
        else if (curHp <= 0)
        {
            curHp = 100;
            hpbar.value = 1f; // 즉시 슬라이더도 꽉 채움
            ChangeShakeAmountFunc(0f);
            Scene_Fade_red.instance.Fade(); // 화면 잠시 빨간색
            camera_shake.instance.Shake(); // 틀리면 카메라 흔들림
            scene3.instance.dead();
        }
        imsi = (float) curHp / (float) maxHp;
        HandleHp();             
        ChangeShakeAmount();

    }


    void OnEnable()
    {
        curHp = 100;
        hpbar.value = 1f; // 즉시 슬라이더도 꽉 채움
    }


    void OnDisable()
    {
        ChangeShakeAmountFunc(0f);
    }


    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value , imsi , Time.deltaTime * 10);
    }



    void ChangeShakeAmount()
    {
        if(curHp <= 80) { ChangeShakeAmountFunc(2.0f); }
        if(curHp <= 60) { ChangeShakeAmountFunc(2.5f); }
        if(curHp <= 40) { ChangeShakeAmountFunc(3.5f); }
        if(curHp <= 20) { ChangeShakeAmountFunc(4.0f); }
    }



    public void ChangeShakeAmountFunc(float newAmount)
    {
        foreach (var shaker in textShakers)
        {
            shaker.shakeAmount = newAmount;
        }
    }


}