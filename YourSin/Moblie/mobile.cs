using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aspect : MonoBehaviour
{
    // 원하는 비율 (세로형은 9f / 16f, 가로형은 16f / 9f 등)
    public float targetAspect = 16f / 9f;

    void Start()
    {
        SetFixedAspect();
    }


    void Update()
    {
        SetFixedAspect();
    
    }

    void SetFixedAspect()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera cam = Camera.main;

        if (scaleHeight < 1.0f)
        {
            // Letterbox (위아래 검은 여백)
            Rect rect = new Rect(0, (1.0f - scaleHeight) / 2f, 1.0f, scaleHeight);
            cam.rect = rect;
        }
        else
        {
            // Pillarbox (좌우 검은 여백)
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = new Rect((1.0f - scaleWidth) / 2f, 0, scaleWidth, 1.0f);
            cam.rect = rect;
        }
    }

}
