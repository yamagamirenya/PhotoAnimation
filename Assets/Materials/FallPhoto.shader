﻿Shader "Custom/FallPhoto" {
	Properties{
		_BendScale("Bend Scale", Range(0.0, 1.0)) = 0.1
		_MainTex("Base (RGB)", 2D) = "white" {}
	    _Color("Color",COLOR) = (1,1,1,1)
		_Alpha("Alpha",Range(0,1.0))=1.0
	}
		SubShader{
			Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha
			LOD 200
		Pass{

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#define PI 3.14159
#include "UnityCG.cginc"

		uniform float _BendScale;
	uniform sampler2D _MainTex;
	uniform float4  _Color;
	uniform float _Alpha;

	struct v2f {
		float4 position : SV_POSITION;
		fixed4 color : COLOR;
		float2 uv       : TEXCOORD0;
	};

	v2f vert(appdata_full v) {
		float bend = sin(PI * _Time.x * 1000 / 45 + v.vertex.y + v.vertex.x);
		float x = (sin(v.texcoord.x * PI) - 1.0);
		float y = (sin(v.texcoord.y * PI) - 1.0);
		v.vertex.y += _BendScale * bend * (x + y);

		v2f o;
		o.position = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
		o.color = v.color;
		return o;
	}

	fixed4 frag(v2f i) : COLOR{
		fixed4 tex = tex2D(_MainTex, i.uv);
	tex.rgb *= i.color.rgb;
	tex.a *= _Alpha;
	return tex;
	}
		ENDCG
	}
	}
}