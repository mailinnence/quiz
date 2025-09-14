using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CCTV_Scene_Change : MonoBehaviour
{
    public static CCTV_Scene_Change Instance { get; private set; } // 싱글톤

    [Header("UI")]
    public RawImage screenImage;  // CCTV 화면

    [Header("Noise Settings")]
    public float noiseIntensity = 0.2f;  // 노이즈 강도
    public float noiseSpeed = 0.1f;  // 노이즈 움직임 속도
    public float glitchDuration = 0.2f;  // 지지직 효과 지속 시간
    public float glitchFrequency = 0.1f; // 지지직 발생 빈도

    private Texture2D noiseTexture;
    private Color[] pixels;
    private float time;
    private bool isGlitching = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        noiseTexture = new Texture2D(256, 256);
        pixels = new Color[noiseTexture.width * noiseTexture.height];
        screenImage.texture = noiseTexture;

        StartCoroutine(GlitchRoutine()); // 랜덤한 간격으로 글리치 실행
    }

    void Update()
    {
        if (!isGlitching)
        {
            time += Time.deltaTime * noiseSpeed;
            GenerateNoiseTexture(time);
            noiseTexture.Apply();
        }
    }

    void GenerateNoiseTexture(float time)
    {
        int width = noiseTexture.width;
        int height = noiseTexture.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float sample = Mathf.PerlinNoise(x * noiseIntensity + time, y * noiseIntensity + time);
                float adjustedSample = Mathf.Clamp01(sample * 2.0f);
                pixels[x + y * width] = new Color(adjustedSample, adjustedSample, adjustedSample);
            }
        }

        noiseTexture.SetPixels(pixels);
    }

    public void TriggerGlitchEffect()
    {
        if (!isGlitching) StartCoroutine(GlitchEffect());
    }

    private IEnumerator GlitchEffect()
    {
        isGlitching = true;
        for (int i = 0; i < pixels.Length; i++)
        {
            if (Random.value < 0.1f) pixels[i] = Color.white; // 랜덤한 픽셀을 흰색으로
            if (Random.value < 0.1f) pixels[i] = Color.black; // 랜덤한 픽셀을 검은색으로
        }
        noiseTexture.SetPixels(pixels);
        noiseTexture.Apply();

        yield return new WaitForSeconds(glitchDuration);
        isGlitching = false;
    }

    private IEnumerator GlitchRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 10f)); // 3~10초 사이 랜덤 간격
            TriggerGlitchEffect();
        }
    }
}
