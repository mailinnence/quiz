using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tool_inventory : MonoBehaviour
{

    public static tool_inventory instance;
    public List<string> item_list = new List<string>();             // 소유중인 아이템


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        save_Item_load();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Save Game...");
            SaveItemList();
        }
    }



    // 아이템 정보 로드
    public void save_Item_load()
    {
        string loadData = PlayerPrefs.GetString("ItemList", "");
        if (!string.IsNullOrEmpty(loadData))
        {
            item_list = new List<string>(loadData.Split(','));
        }
    }



    // 보유중인 아이템 리스트 저장 함수
    public void SaveItemList()
    {
        string saveData = string.Join(",", item_list); // 리스트를 ","로 연결
        PlayerPrefs.SetString("ItemList", saveData);
        PlayerPrefs.Save(); // 실제로 저장 (선택사항)
    }



}
