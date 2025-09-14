using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SystemData
{
    public int play;
    public int ending; // ✅ 추가된 필드
    public int NumStages;
    public int NumQuestions;
    public string UIRatioWarning;
    public string team_title;
    public string quiz_title;
    public string main;
    public string quiz_main;
    public string set_;
    public string set_typing_mode_plainText;
    public string set_typing_mode_on;
    public string set_typing_mode_save;
    public string set_background_on;
    public string set_background_save;
    public string set_background_on_plainText;
    public string develope_team;
    public string develope_team_plainText;
    public string Inquiry;
    public string Inquiry_plainText;
    public string gameover;
    public string clear;
    public string all_clear;
    public string advertisement;
    public string ending_text;
}

[System.Serializable]
public class SystemDataWrapper
{
    public List<SystemData> system;
}

public class loading : MonoBehaviour
{
    public static loading instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public IEnumerator FirstPlay()
    {
        if (!PlayerPrefs.HasKey("FirstPlay"))
        {
            LoadSystemJsonFromResources();
            Debug.Log("첫 플레이 시작");
        }
        else
        {
            Debug.Log("[저장된 값 출력]");
            Debug.Log($"play: {PlayerPrefs.GetInt("play")}");
            Debug.Log($"ending: {PlayerPrefs.GetInt("ending")}");
            Debug.Log($"NumStages: {PlayerPrefs.GetInt("NumStages")}");
            Debug.Log($"NumQuestions: {PlayerPrefs.GetInt("NumQuestions")}");
            Debug.Log($"UIRatioWarning: {PlayerPrefs.GetString("UIRatioWarning")}");
            Debug.Log($"team_title: {PlayerPrefs.GetString("team_title")}");
            Debug.Log($"quiz_title: {PlayerPrefs.GetString("quiz_title")}");
            Debug.Log($"main: {PlayerPrefs.GetString("main")}");
            Debug.Log($"quiz_main: {PlayerPrefs.GetString("quiz_main")}");
            Debug.Log($"set_: {PlayerPrefs.GetString("set_")}");
            Debug.Log($"set_typing_mode_plainText: {PlayerPrefs.GetString("set_typing_mode_plainText")}");
            Debug.Log($"set_typing_mode_on: {PlayerPrefs.GetString("set_typing_mode_on")}");
            Debug.Log($"set_typing_mode_save: {PlayerPrefs.GetString("set_typing_mode_save")}");
            Debug.Log($"set_background_on: {PlayerPrefs.GetString("set_background_on")}");
            Debug.Log($"set_background_save: {PlayerPrefs.GetString("set_background_save")}");
            Debug.Log($"set_background_on_plainText: {PlayerPrefs.GetString("set_background_on_plainText")}");
            Debug.Log($"develope_team: {PlayerPrefs.GetString("develope_team")}");
            Debug.Log($"develope_team_plainText: {PlayerPrefs.GetString("develope_team_plainText")}");
            Debug.Log($"Inquiry: {PlayerPrefs.GetString("Inquiry")}");
            Debug.Log($"Inquiry_plainText: {PlayerPrefs.GetString("Inquiry_plainText")}");
            Debug.Log($"gameover: {PlayerPrefs.GetString("gameover")}");
            Debug.Log($"clear: {PlayerPrefs.GetString("clear")}");
            Debug.Log($"all_clear: {PlayerPrefs.GetString("all_clear")}");
        }

        yield return null;
    }

    void LoadSystemJsonFromResources()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("system");
        if (jsonFile == null)
        {
            Debug.LogError("Resources 폴더에 system.json 파일이 없습니다!");
            return;
        }

        string jsonText = jsonFile.text;
        SystemDataWrapper wrapper = JsonUtility.FromJson<SystemDataWrapper>(jsonText);

        if (wrapper == null || wrapper.system == null || wrapper.system.Count == 0)
        {
            Debug.LogError("JSON 파싱 실패 또는 system 항목 없음");
            return;
        }

        SystemData data = wrapper.system[0];

        PlayerPrefs.SetInt("play", data.play);
        PlayerPrefs.SetInt("ending", data.ending); // ✅ 추가된 저장 코드
        PlayerPrefs.SetInt("NumStages", data.NumStages);
        PlayerPrefs.SetInt("NumQuestions", data.NumQuestions);
        PlayerPrefs.SetString("UIRatioWarning", data.UIRatioWarning);
        PlayerPrefs.SetString("team_title", data.team_title);
        PlayerPrefs.SetString("quiz_title", data.quiz_title);
        PlayerPrefs.SetString("main", data.main);
        PlayerPrefs.SetString("quiz_main", data.quiz_main);
        PlayerPrefs.SetString("set_", data.set_);
        PlayerPrefs.SetString("set_typing_mode_plainText", data.set_typing_mode_plainText);
        PlayerPrefs.SetString("set_typing_mode_on", data.set_typing_mode_on);
        PlayerPrefs.SetString("set_typing_mode_save", data.set_typing_mode_save);
        PlayerPrefs.SetString("set_background_on", data.set_background_on);
        PlayerPrefs.SetString("set_background_save", data.set_background_save);
        PlayerPrefs.SetString("set_background_on_plainText", data.set_background_on_plainText);
        PlayerPrefs.SetString("develope_team", data.develope_team);
        PlayerPrefs.SetString("develope_team_plainText", data.develope_team_plainText);
        PlayerPrefs.SetString("Inquiry", data.Inquiry);
        PlayerPrefs.SetString("Inquiry_plainText", data.Inquiry_plainText);
        PlayerPrefs.SetString("gameover", data.gameover);
        PlayerPrefs.SetString("clear", data.clear);
        PlayerPrefs.SetString("all_clear", data.all_clear);
        PlayerPrefs.SetString("advertisement", data.advertisement);
        PlayerPrefs.SetInt("FirstPlay", 1);
        PlayerPrefs.SetString("ending_text", data.ending_text);
        
        PlayerPrefs.Save();

        Debug.Log("Resources에서 시스템 설정을 불러와 저장했습니다.");
    }
}
