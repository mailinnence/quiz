using UnityEngine;

public class season : MonoBehaviour
{

    public GameObject[] seasonObject;

    void Start()
    {
        Camera cam = Camera.main; // 캐시
        if (cam == null) return;

        if (PlayerPrefs.GetString("set_background_save") == "on")
        {
            cam.backgroundColor = new Color(167f / 255f, 195f / 255f, 255f / 255f);
            for (int i = 0; i < seasonObject.Length; i++)
            {
                seasonObject[i].SetActive(i == SaveManager.instance.season);
            }
        }
        else
        {
            cam.backgroundColor = new Color(207f / 255f, 207f / 255f, 207f / 255f);
        }
    }

}
