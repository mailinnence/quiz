Shader "Custom/CCTVNoiseShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseIntensity ("Noise Intensity", Range(0, 1)) = 0.1
        _NoiseTime ("Noise Time", Float) = 0
        _Alpha ("Transparency", Range(0, 1)) = 1.0  // 투명도 속성 추가
    }
    
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }  // 태그 변경
        LOD 100
        
        ZWrite Off  // 투명도 처리를 위해 ZWrite 끄기
        Blend SrcAlpha OneMinusSrcAlpha  // 알파 블렌딩 모드 설정
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _MainTex;
            float _NoiseIntensity;
            float _NoiseTime;
            float _Alpha;  // 투명도 변수 추가
            
            // 해시 기반 노이즈 함수
            float hash(float2 p)
            {
                return frac(sin(dot(p, float2(12.9898, 78.233))) * 43758.5453);
            }
            
            // 2D Perlin 노이즈 근사치 
            float perlinNoise(float2 p)
            {
                float2 i = floor(p);
                float2 f = frac(p);
                
                float a = hash(i);
                float b = hash(i + float2(1.0, 0.0));
                float c = hash(i + float2(0.0, 1.0));
                float d = hash(i + float2(1.0, 1.0));
                
                float2 u = f * f * (3.0 - 2.0 * f);
                
                return lerp(lerp(a, b, u.x), lerp(c, d, u.x), u.y);
            }
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                
                // 노이즈 계산
                float2 noiseUV = uv * 10.0;
                float noise = 0.0;
                
                // 여러 주파수의 노이즈 더하기
                noise += perlinNoise(noiseUV + _NoiseTime) * 0.5;
                noise += perlinNoise(noiseUV * 2.0 + _NoiseTime) * 0.25;
                noise += perlinNoise(noiseUV * 4.0 + _NoiseTime) * 0.125;
                
                // 노이즈 강도 조절
                noise = noise * _NoiseIntensity * 2.0;
                
                // 기본 텍스처와 노이즈 합성
                fixed4 col = tex2D(_MainTex, uv);
                col.rgb += noise;
                col.a = _Alpha;  // 알파 값 적용
                
                return col;
            }
            ENDCG
        }
    }
}