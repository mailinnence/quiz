using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class TalkManager : MonoBehaviour
{
    public static TalkManager instance;

    public Dictionary<int, string[]> talkData;
 

    void Awake()
    {
        instance = this;
        talkData = new Dictionary<int, string[]>();
    }


    void Start()
    {
        if (SceneManager.GetActiveScene().name == "2.choice")
        {
            GenerateData();
        }
    }

    public void GenerateData_Start()
    {
        talkData.Add(-2, new string[] {PlayerPrefs.GetString("quiz_title")});
       
    }


    public void GenerateData()
    {
        talkData.Add(-1, new string[] {PlayerPrefs.GetString("main")});
    }

    public void GenerateData_doney()
    {
        talkData.Add(-5, new string[] {PlayerPrefs.GetString("gameover")});
        talkData.Add(-4, new string[] {PlayerPrefs.GetString("clear")});
        talkData.Add(-3, new string[] {PlayerPrefs.GetString("all_clear")});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex >= talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

}