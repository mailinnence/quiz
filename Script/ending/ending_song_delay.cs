using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // 씬 이름 확인을 위해 필요


public class ending_song_delay : MonoBehaviour
{

    [Header("로고 배경음악")]
    public AudioSource ending_song;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endng_song();
    }



    // 카타나 제로 연출
    public void endng_song()
    {
        StartCoroutine(endng_song_delay());
    }


    IEnumerator endng_song_delay()
    {
        yield return new WaitForSeconds(1.5f);
        ending_song.Play();
        
    }

}
