using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // .. 프리펩들을 보관할 변수
    public GameObject[] prefabs;

    // .. 풀 담당을 하는 리스트들
    private List<GameObject>[] pools;


    public static PoolManager instance;



    void Awake()
    {
        instance = this;
        pools = new List<GameObject>[prefabs.Length]; 


        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }


    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index])
        {
          
            if (!item.activeSelf)
            {
                // ... 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }
        
        if (!select)
        {
      
            select = Instantiate(prefabs[index] , transform);   
            pools[index].Add(select);

        }

        return select;
    }

}

