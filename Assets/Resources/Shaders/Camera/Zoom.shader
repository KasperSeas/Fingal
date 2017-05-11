Shader "Camera/Zoom"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Mirror("Mirror", Range(0, 1)) = 0
		_Inverse("Inverse", Range(0, 1)) = 0
		_Zoom("Zoom", Range(0, 1)) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			fixed _Mirror;
			fixed _Inverse;
			float _Zoom;

			fixed4 frag (v2f i) : SV_Target
			{
				float u = (1-_Zoom)/2 + (_Zoom*i.uv.x);
				float v = (1-_Zoom)/2 + (_Zoom*i.uv.y);

				if(_Mirror > 0){
					if(i.uv.x > 0.5){
						u = 1-u;
					}
				}

				float2 uv = float2(u, v);

				fixed4 col = tex2D(_MainTex, uv);

				if(_Inverse > 0){
					col = 1 - col;
				}

				return col;
			}
			ENDCG
		}
	}
}
