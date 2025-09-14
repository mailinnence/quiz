using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TalkManager3 : MonoBehaviour
{
    public static TalkManager3 instance;

    public Dictionary<int, string[]> talkData;
 
    public string text;

    void Awake()
    {
        instance = this;
        talkData = new Dictionary<int, string[]>();
    }

    void Start()
    {
        GenerateData();
    }

    public void GenerateData()
    {
        talkData.Add(1, new string[] {PlayerPrefs.GetString("gameover") , PlayerPrefs.GetString("advertisement")});
        talkData.Add(2, new string[] {PlayerPrefs.GetString("clear") , PlayerPrefs.GetString("advertisement")});
        talkData.Add(3, new string[] {PlayerPrefs.GetString("all_clear"), PlayerPrefs.GetString("advertisement")});
        talkData.Add(4, new string[] {PlayerPrefs.GetString("advertisement")});
    
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex >= talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

}