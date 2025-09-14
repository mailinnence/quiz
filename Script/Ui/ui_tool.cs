using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_tool : MonoBehaviour
{
    // public tool_inventory tool_inventory;   // 보유중인 아이템 세이브 시스템에서 가져오기
    // public GameObject[] slot;               // slot 의 위치
    // public GameObject[] item;               // item 의 아이콘
    
    // private Dictionary<string, GameObject> itemDict = new Dictionary<string, GameObject>();


    // void Awake()
    // {
    //     itemDict = new Dictionary<string, GameObject>();
    //     itemDict["r1_usb"] = item[0];
    //     itemDict["r1_key"] = item[1];
       
    // }


    // void OnEnable()
    // {
    //     foreach (GameObject s in slot)
    //     {
    //         foreach (Transform child in s.transform)
    //         {
    //             Destroy(child.gameObject); // 이전 아이템 제거
    //         }
    //     }
    //     // 보유한 아이템 순서대로 슬롯에 넣기
    //     for (int i = 0; i < tool_inventory.item_list.Count && i < slot.Length; i++)
    //     {
    //         string itemName = tool_inventory.item_list[i];

    //         if (itemDict.TryGetValue(itemName, out GameObject prefab))
    //         {
    //             GameObject icon = Instantiate(prefab, slot[i].transform.position, Quaternion.identity);
    //             icon.transform.SetParent(slot[i].transform, false);  // 슬롯에 붙이기
    //         }
    //     }
    // }


}
