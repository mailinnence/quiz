using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using TMPro;


public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        back_main();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 게임 오버
    void back_main()
    {
        StartCoroutine(ShowGameOverTextWithDelay());
        
    }


    IEnumerator ShowGameOverTextWithDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("2.choice");
    }

}
