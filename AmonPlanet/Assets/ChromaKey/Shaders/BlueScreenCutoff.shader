Shader "ChromaKey/BlueScreenCutoff" 
{
	Properties 
	{
	    _MainTex ("Base (RGB)", 2D) = "white" {}
	    _Cutoff ("Cutoff", Range (0,1)) = 0.5
	}

	SubShader 
	{
		Pass 
		{
			CGPROGRAM

			#pragma exclude_renderers gles
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex; 

			struct v2f 
			{ 
			    float4 pos : POSITION; 
			    float4 uv : TEXCOORD0; 
			}; 

			half4 frag (v2f i) : COLOR 
			{ 
			    half4 color = tex2D(_MainTex, i.uv.xy); 
			    return half4(color.r, color.g, color.b, color.b - ( (color.r * 0.5) + (color.g * 0.5)));
			} 

			ENDCG
			AlphaTest Less [_Cutoff]
		}
	} 
	Fallback "Transparent/Diffuse"
}