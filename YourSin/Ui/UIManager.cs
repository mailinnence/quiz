using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI 관련 변수")]    
    public GameObject tool;
    public GameObject discussion;
    public GameObject think;
    public GameObject map;
    public GameObject menu;
    public GameObject ingame_objcet;

    private List<GameObject> allUIElements;

    void Awake()
    {
        // UI 리스트 초기화
        allUIElements = new List<GameObject> { tool, discussion, think, map, menu };
    }

    // UI 하나만 켜고 나머지 끄는 함수
    public void ToggleExclusiveUI(GameObject target)
    {
        bool willActivate = !target.activeSelf;

        // 모두 끄기
        foreach (GameObject ui in allUIElements)
        {
            if (ui != null)
                ui.SetActive(false);
        }

        // 선택된 것만 켜기 (만약 비활성화 상태였다면)
        if (willActivate && target != null)
        {
            target.SetActive(true);
            GameManager.instance.click_deable = true;
        }
        else
        {
            // 모두 꺼졌다면 시스템 다시 활성화
            GameManager.instance.click_deable = false;
        }
    }

    // 버튼 연결용 함수들
    public void ToggleToolUI() => ToggleExclusiveUI(tool);
    public void ToggleDiscussionUI() => ToggleExclusiveUI(discussion);
    public void ToggleThinkUI() => ToggleExclusiveUI(think);
    public void ToggleMapUI() => ToggleExclusiveUI(map);
    public void ToggleMenuUI() => ToggleExclusiveUI(menu);
}
