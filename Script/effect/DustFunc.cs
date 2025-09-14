using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustFunc : MonoBehaviour
{

    public float speed = 1f; // 이동 속도



    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


    public void deactivate_anim()
    {
        gameObject.SetActive(false); // 현재 오브젝트 비활성
    }
}
