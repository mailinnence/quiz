using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TalkManager : MonoBehaviour
{
    public static TalkManager instance;

    Dictionary<int, string[]> talkData;

    void Awake()
    {
        instance = this;
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }


    void GenerateData()
    {
        talkData.Add(99, new string[] 
        { "정리해보죠.", 
          "저를 포함한 4분 모두 일어나보니까 이곳이었고\n 어떻게 이곳에 왔는지는 모를는 상황이군요"
          
        });

        talkData.Add(1, new string[] 
        {
    /*1*/    "이쪽문도 잠겨있네요." , 
    /*2*/    "전방에 있던 메모대로 왼쪽방부터 가보는게 좋겠어요." , 
    /*3*/    "아!",
    /*4*/    "아! 수갑...미안해요 ",
    /*5*/    "조심할께요" , 
    /*6*/    "일단 돌아가보죠.",
    /*7*/    "이게 뭐하는 건지"
            
        }
        );

        talkData.Add(2, new string[] {"책장에 낡은 책들이 꽂혀 있다." , "알수 없는 언어로 되어있다.."});
        talkData.Add(3, new string[] {"바닥에 피가 뿌려져있다." , "불쾌한 냄새가 난다."});
        talkData.Add(4, new string[] {"전등이다."});
        talkData.Add(5, new string[] {"책장 사이에 철장이 있다.", "그 안에 빨간색 USB 가 있다!"});
        talkData.Add(6, new string[] {"usb 를 획득했다."});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex >= talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

}

