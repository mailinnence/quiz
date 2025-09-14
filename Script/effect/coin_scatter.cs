using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_scatter : MonoBehaviour
{

    public GameObject[] coins;

    // 초기 위치 저장용 배열
    private Vector3[] initialPositions;

    void OnEnable()
    {
        // 초기 위치 저장
        initialPositions = new Vector3[coins.Length];
        for (int i = 0; i < coins.Length; i++)
        {
            initialPositions[i] = coins[i].transform.localPosition; // 로컬 좌표 기준
        }

        Invoke(nameof(DisableSelf), 1f);
    }

    void DisableSelf()
    {
        // 위치 원래대로 되돌리기
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].transform.localPosition = initialPositions[i];
        }

        gameObject.SetActive(false);
    }
}
