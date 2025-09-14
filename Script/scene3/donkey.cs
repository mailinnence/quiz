using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using TMPro;


public class donkey : MonoBehaviour
{
    private bool once_var;


    [Header("메세지")]
    public TMP_Text message;  // Text -> TMP_Text 로 변경
    

    void Start()
    {
        StartCoroutine(BackTextWithDelay());
    }


    void Update()
    {
        if(!once_var)
        {
            internet_able();
            once_var = true;
            if(SaveManager.instance.state == "state")
            {
                SoundManager.instance.scene_4_state.Play();
                StartCoroutine(Sequence(4));
            } 
            else if(SaveManager.instance.state == "gameOver")
            {
                SoundManager.instance.scene_4_fail.Play();
                StartCoroutine(Sequence(1));
            }  
            else if(SaveManager.instance.state == "clear")
            {
                SoundManager.instance.scene_4_clear.Play();
                StartCoroutine(Sequence(2));
            }
            else if(SaveManager.instance.state == "all_clear")
            {
                SoundManager.instance.scene_4_clear.Play();
                StartCoroutine(Sequence(3));
            }

        }
    }



    IEnumerator Sequence(int num)
    {
        if(num == 4)
        {
            Situation3.instance.StartEvent(num);
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("2.choice"); 
        }
        else
        {
            Situation3.instance.StartEvent(num);        // 즉시 한 번 실행
            yield return new WaitForSeconds(4f);      // 2초 대기
            SoundManager.instance.scene_4_state.Play();
            Situation3.instance.StartEvent(num);        // 2초 후 한 번 더 실행
            yield return new WaitForSeconds(5f);
            if (num != 3) 
            { 
                SceneManager.LoadScene("2.choice"); 
            }
            else 
            { 
                SceneManager.LoadScene("5.ending");
            }
        }
    }




    void internet_able()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("인터넷이 연결되어 있지 않습니다.");
        }
        else
        {
            Debug.Log("인터넷이 연결되어 있습니다.");
        }
    }


    IEnumerator BackTextWithDelay()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("2.choice");
    }


}
