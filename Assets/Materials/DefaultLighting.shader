Shader "Custom/DefaultLighting"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_ShadeColor("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
				float3 normal :NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float3 normal:TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			fixed4 _ShadeColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {

				float3 N = normalize(i.normal);
				float3 L = normalize(-_WorldSpaceLightPos0);
				

				float d = dot(N, -L)*0.5 + 0.5;

                fixed4 col = lerp(_ShadeColor,tex2D(_MainTex, i.uv),d);
                return col;


            }
            ENDCG
        }
    }
}
