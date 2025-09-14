using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // 씬 이름 확인을 위해 필요



public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; set;}

    [Header("로고 배경음악")]
    public AudioSource scene_1_start_background;

    [Header("텍스트 스케터")]
    public AudioSource glass_sound;
    public AudioSource button_sound;

    [Header("키보드")]
    public AudioSource keyboard;
    public AudioClip key_1; 
    public AudioClip key_2; 
    public AudioClip key_3; 
    public AudioClip key_4;  
    public AudioClip key_5; 


    [Header("캐릭터 파티클")]
    public AudioSource particle_menu;
    public AudioSource particle_solve;


    [Header("카운터 다운")]
    public AudioSource countDown_r;
    public AudioSource countDown_s;


    [Header("정답")]
    public AudioSource answer_collect;
    public AudioSource answer_coin;


    [Header("메뉴 화면")]
    public AudioSource menu_sound;


    [Header("문제 풀이 화면")]
    public AudioSource solve_sound;
    public AudioClip sol_1; 
    public AudioClip sol_2; 
    public AudioClip sol_3; 
    public AudioClip sol_4;  
    public AudioClip sol_5;
    public AudioClip sol_6;
    public AudioClip sol_7;
    public AudioClip sol_8;
    public AudioClip sol_9;


    [Header("버튼 효과음")]
    public AudioSource scene_2_setting_button;
    
    [Header("퀴즈")]
    public AudioSource scene_3_wrong;
    public AudioSource scene_3_jump;
    

    
    [Header("엔딩")]
    public AudioSource scene_4_fail;
    public AudioSource scene_4_clear;
    public AudioSource scene_4_state;
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 이동 시 파괴되지 않음
        }
        else
        {
            Destroy(gameObject); // 중복된 사운드 매니저 제거
        }
    }

// SoundManager.instance.solve_sound_()
// SoundManager.instance.scene_4_ending_background.Stop();




    // 카타나 제로 연출
    public void textScatter()
    {
        StartCoroutine(textScatter_delay());
    }


    IEnumerator textScatter_delay()
    {
        button_sound.Play();
        yield return new WaitForSeconds(0.09f);
        glass_sound.Play();
        
    }





    // 타이핑 
    private bool canPlayKeyboard = true; // 쿨타임 상태

    public void keyboard_sound()
    {
        if (!canPlayKeyboard) return; // 아직 쿨타임이면 재생하지 않음

        AudioClip[] keys = new AudioClip[] { key_1, key_2, key_3, key_4, key_5 };
        int randomIndex = Random.Range(0, keys.Length);
        keyboard.PlayOneShot(keys[randomIndex]);

        // 쿨타임 시작
        StartCoroutine(KeyboardCooldown());
    }

    private IEnumerator KeyboardCooldown()
    {
        canPlayKeyboard = false;
        yield return new WaitForSeconds(0.07f); // 0.2초 쿨타임
        canPlayKeyboard = true;
    }



    // 정답
    public void anser_sound()
    {
        StartCoroutine(anser_sound_delay());
    }


    IEnumerator anser_sound_delay()
    {
        answer_collect.Play();
        yield return new WaitForSeconds(0.1f);
        answer_coin.Play();
        
    }



    // 문제풀이 배경음악
    public void solve_sound_()
    {
        // 9개의 키 소리를 배열에 담기
        AudioClip[] sols = new AudioClip[] { sol_1, sol_2, sol_3, sol_4, sol_5, sol_6, sol_7, sol_8, sol_9 };

        // 랜덤으로 하나 선택
        int randomIndex_ = Random.Range(0, sols.Length);

        // 선택한 클립 지정 후 재생
        solve_sound.clip = sols[randomIndex_];
        solve_sound.Play();
    }


    // 재생 중지
    public void stop_solve_sound()
    {
        if (solve_sound.isPlaying)
        {
            solve_sound.Stop();
        }
    }




// SoundManager.instance.solve_sound_()
// SoundManager.instance.stop_solve_sound()
}
