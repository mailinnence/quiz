using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TalkManager1 : MonoBehaviour
{
    public static TalkManager1 instance;

    public Dictionary<int, string[]> talkData;
 
    public string text;

    void Awake()
    {
        instance = this;
        talkData = new Dictionary<int, string[]>();
    }

    void Start()
    {
        text = PlayerPrefs.GetString("UIRatioWarning");
        GenerateData();
    }

    public void GenerateData()
    {
        talkData.Add(1, new string[] { text});
        talkData.Add(2, new string[] { });
        talkData.Add(3, new string[] {});

        // talkData.Add(2, new string[] {"책장에 낡은 책들이 꽂혀 있다." , "알수 없는 언어로 되어있다.."});
        // talkData.Add(3, new string[] {"바닥에 피가 뿌려져있다." , "불쾌한 냄새가 난다."});
        // talkData.Add(4, new string[] {"전등이다."});
        // talkData.Add(5, new string[] {"책장 사이에 철장이 있다.", "그 안에 빨간색 USB 가 있다!"});
        // talkData.Add(6, new string[] {"usb 를 획득했다."});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex >= talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

}