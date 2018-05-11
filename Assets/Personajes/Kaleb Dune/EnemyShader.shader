Shader "MyShaders/EnemyShader" {
	Properties{
		_MainTex("Textura Base", 2D) = "white"{}
	_LuminosityAmount("Luminosidad", Range(0.0,10)) = 1.0
	}
	SubShader{
		Tags{ "RenderType" = "Opaque" }

		Pass
		{
			CGPROGRAM

			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			fixed _LuminosityAmount;

			fixed4 frag(v2f_img i) : COLOR
			{
				fixed4 renderTex = tex2D(_MainTex, i.uv);
				float luminosity = 0.299 * renderTex.r + 0.587 * renderTex.g + 0.114 * renderTex.b;
				fixed4 finalColor = lerp(renderTex, luminosity, _LuminosityAmount);
				return finalColor;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
