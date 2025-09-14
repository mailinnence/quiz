using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layerSetting : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject character_1;
    public GameObject character_2;
    public GameObject character_3;
    public GameObject character_4;
 

    public static layerSetting instance;
    
    void Awake()
    {
        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void Layer_init()
    {
        character_1.GetComponent<SpriteRenderer>().sortingOrder = 12;
        character_2.GetComponent<SpriteRenderer>().sortingOrder = 11;
        character_3.GetComponent<SpriteRenderer>().sortingOrder = 10;
        character_4.GetComponent<SpriteRenderer>().sortingOrder = 9;
    }



    public void Layer_15_cha_0()
    {
        character_1.GetComponent<SpriteRenderer>().sortingOrder = 15;
    }


    public void Layer_15_cha_1()
    {
        character_2.GetComponent<SpriteRenderer>().sortingOrder = 15;
    }
    
    public void Layer_15_cha_2()
    {
        character_3.GetComponent<SpriteRenderer>().sortingOrder = 15;
    }

    
    public void Layer_15_cha_3()
    {
        character_4.GetComponent<SpriteRenderer>().sortingOrder = 15;
    }


 

}


