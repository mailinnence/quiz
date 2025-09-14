using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r1_Object_Click : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public int scene; 
    public int obj; 


    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (IsInputDown())
        {
            Vector2 inputPos;

            #if UNITY_EDITOR || UNITY_STANDALONE
                inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            #elif UNITY_IOS || UNITY_ANDROID
                inputPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            #endif

            if (boxCollider.OverlapPoint(inputPos) && !GameManager.instance.click_deable && scene != 0)
            {
                r1_Object_search.instance.isEvent(this.gameObject);
            }

        }      
    }



    bool IsInputDown()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE
                return Input.GetMouseButtonDown(0);
        #elif UNITY_IOS || UNITY_ANDROID
                return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        #else
                return false;
        #endif
    }
}


