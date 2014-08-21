Shader "ChromaKey/CustomColorCutoff" 
{
	Properties 
	{
		_MainTex ("Base (RGBA)", 2D) = "white" {}
		_ColorToReplace ("ColorToReplace", Color) = (0,1,0,1)
		_Cutoff ("Cutoff", Range (0,0.2)) = 0.1
		_Smoothing ("Smoothing", Range (0,1)) = 0.5
	}
	
	SubShader 
	{
		Pass 
		{
			CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles

			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex; 
			float4 _ColorToReplace;
			float _Cutoff;
			float _Smoothing;
			
			struct v2f 
			{ 
			    float4 pos : POSITION; 
			    float4 uv : TEXCOORD0; 
			}; 
			
			
			half4 frag (v2f i) : COLOR 
			{ 
			    half4 color = tex2D(_MainTex, i.uv.xy); 
			    
			    half maskY = 0.2989 * _ColorToReplace.r + 0.5866 * _ColorToReplace.g + 0.1145 * _ColorToReplace.b;
				half maskCr = 0.7132 * (_ColorToReplace.r - maskY);
				half maskCb = 0.5647 * (_ColorToReplace.b - maskY);
				
				half Y = 0.2989 * color.r + 0.5866 * color.g + 0.1145 * color.b;
			    half Cr = 0.7132 * (color.r - Y);
			    half Cb = 0.5647 * (color.b - Y);
			    
			    half blendValue = smoothstep(_Cutoff, _Cutoff + _Smoothing, distance(vec2(Cr, Cb), vec2(maskCr, maskCb)));
			    
			    return half4(color.r, color.g, color.b,1 -  blendValue);
			} 

			ENDCG
			AlphaTest Less [_Cutoff]
		}
	} 
	FallBack "Transparent/Diffuse"
}
