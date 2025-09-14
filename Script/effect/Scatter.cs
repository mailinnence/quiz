using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scatter : MonoBehaviour
{
    public static Scatter instance;

    public GameObject scatter; // 활성화할 UI 오브젝트
    public List<GameObject> etcList;
    public string nestScene;
    
    void Awake()
    {
        instance = this;
    }


    public void NextScene()
    {

        Camera.main.backgroundColor = Color.black;
        scatter.SetActive(true);
        foreach (GameObject obj in etcList)
        {
            if (obj != null)
                obj.SetActive(false);
        }

   
        StartCoroutine(LoadSceneAfterDelay(2f));
        // Scene_Fade_black.instance.SetAlphaTo255();
    }


    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 여기서 "NextSceneName"을 실제 이동할 씬 이름으로 바꿔주세요
        if (nestScene != "")
        {
            SceneManager.LoadScene(nestScene);
        }
    }
}
