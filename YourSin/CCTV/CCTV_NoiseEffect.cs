using UnityEngine;
using UnityEngine.UI;

public class CCTV_NoiseEffect : MonoBehaviour
{
    public RawImage screenImage; // CCTV 화면을 나타낼 RawImage
    public float noiseIntensity = 0.1f; // 노이즈 강도
    public float noiseSpeed = 0.1f; // 노이즈의 움직임 속도

    private Texture2D noiseTexture;
    private Color[] pixels;
    private float time;

    void Start()
    {
        // 텍스처 초기화
        noiseTexture = new Texture2D(256, 256);
        screenImage.texture = noiseTexture;
        pixels = new Color[noiseTexture.width * noiseTexture.height]; // 한 번만 할당
    }

    void Update()
    {
        time += Time.deltaTime * noiseSpeed;

        // PerlinNoise 계산 최적화
        GenerateNoiseTexture(time);

        // SetPixels는 한번만 호출하고, Apply도 한 번만 호출
        noiseTexture.SetPixels(pixels);
        noiseTexture.Apply(); // 최적화된 방식으로 한 프레임에 한번만 호출
    }

    // Perlin Noise를 이용한 노이즈 텍스처 생성
    void GenerateNoiseTexture(float time)
    {
        int index = 0; // 배열 인덱스 미리 정의
        for (int y = 0; y < noiseTexture.height; y++)
        {
            for (int x = 0; x < noiseTexture.width; x++, index++)
            {
                float xCoord = x * noiseIntensity + time;
                float yCoord = y * noiseIntensity + time;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);

                // 색상 범위 확장
                float adjustedSample = Mathf.Clamp01(sample * 2.0f);

                // 색상을 배열에 설정
                pixels[index] = new Color(adjustedSample, adjustedSample, adjustedSample);
            }
        }
    }
}
