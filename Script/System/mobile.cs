using UnityEngine;

public class mobile : MonoBehaviour
{
    void Awake()
    {
        Camera cam = Camera.main;

        // 모바일 플랫폼이거나 에디터에서 세로형 해상도일 때만 실행
        bool isMobile = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
        
#if UNITY_EDITOR
        // 에디터에서 세로형 해상도 (모바일 시뮬레이터)인지 확인
        bool isSimulator = (float)Screen.width / (float)Screen.height < 1.0f;
#else
        bool isSimulator = false;
#endif

        if (isMobile || isSimulator)
        {
            cam.orthographicSize = 7f;
            cam.transform.position = new Vector3(cam.transform.position.x, 2f, cam.transform.position.z);
        }



        // Application.targetFrameRate = 60;  
#if UNITY_ANDROID || UNITY_IOS
        float targetAspect = 1080f / 1920f; // 기준 비율 (세로형)
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleWidth = targetAspect / windowAspect;

        if (scaleWidth > 1f)
        {
            cam.orthographicSize *= scaleWidth; // 가로 폭이 줄어들면 시야 확대
        }
#endif
    }
}
