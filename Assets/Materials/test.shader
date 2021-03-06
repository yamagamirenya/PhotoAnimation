﻿Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	    _Range ("Range",Range(0.0001,1))=0.01

	}
		SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 100

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
		// make fog work
#pragma multi_compile_fog

#include "UnityCG.cginc"

		sampler2D _MainTex;
		float _Range;


		float peek(float x, float y)
	{
		return tex2D(_MainTex, float2(x, y)).r;
	}

	const float dx = 0.001953125;
	const float dy = 0.001953125;

	half _Glossiness;
	half _Metallic;
	fixed4 _Color;

		struct appdata
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct v2f
	{
		float2 uv : TEXCOORD0;
		UNITY_FOG_COORDS(1)
			float4 vertex : SV_POSITION;
	};

	float4 _MainTex_ST;

	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = TRANSFORM_TEX(v.uv, _MainTex);
		UNITY_TRANSFER_FOG(o,o.vertex);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		float x = i.uv.x;
	    float y = i.uv.y;

		/*
	float3x3 m = float3x3(
		peek(x - dx, y - dy), peek(x, y - dy), peek(x + dx, y - dy),
		peek(x - dx, y), peek(x, y), peek(x + dx, y),
		peek(x - dx, y + dy), peek(x, y + dy), peek(x + dx, y + dy)
		);
		*/

		float3x3 m = float3x3(
			peek(x - _Range, y - _Range), peek(x, y - _Range), peek(x + _Range, y - _Range),
			peek(x - _Range, y), peek(x, y), peek(x + _Range, y),
			peek(x - _Range, y + _Range), peek(x, y + _Range), peek(x + _Range, y + _Range)
			);

	float4 h = float4
		(
			m[0][0] - m[0][2] + (m[1][0] - m[1][2]) * 2 + m[2][0] - m[2][2],		
			m[0][0] - m[2][0] + (m[0][1] - m[2][1]) *2   + m[0][2] - m[2][2],
			2*m[0][0] - m[0][2] + (m[1][0] - m[1][2]) + m[2][0] - 2*m[2][2],
			m[0][0] - 2*m[2][0] + (m[0][1] - m[2][1])  + 2*m[0][2] - m[2][2]
			);
		// sample the texture
	float d = length(h);
	return float4(d, d,d, 1.0);
	}
		ENDCG
	}
	}
}