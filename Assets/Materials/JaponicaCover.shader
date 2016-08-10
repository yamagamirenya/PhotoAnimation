Shader "Custom/JaponicaCover" {

	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	    _Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Alpha("Alpha",Range(0,1.0)) = 1.0
		_BackMainTex("Albedo (RGB)", 2D) = "white" {}
	}

		SubShader{


		Tags{ "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha

		LOD 200

		Cull Front
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert  alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		//#pragma target 3.0


	struct Input {
		float2 uv_MainTex;
		float3 worldNormal;INTERNAL_DATA
	};

	half _Glossiness;
	half _Metallic;
	fixed4 _Color;
	uniform float _Alpha;
	sampler2D _MainTex;


	void surf(Input IN, inout SurfaceOutput o) {
		// Albedo comes from a texture tinted by color
		half4 c = tex2D(_MainTex, IN.uv_MainTex)*_Color;
		o.Albedo = c.rgb;
		o.Normal =float3(0,0,-1);
		// Metallic and smoothness come from slider variables

		o.Alpha = _Alpha;
	}
	ENDCG

		Cull Back

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Lambert  alpha

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0


	struct Input {
		float2 uv_MainTex;
	};

	half _Glossiness;
	half _Metallic;
	fixed4 _Color;
	uniform float _Alpha;
	sampler2D _BackMainTex;


	void surf(Input IN, inout SurfaceOutput o) {
		// Albedo comes from a texture tinted by color
		half4 c = tex2D(_BackMainTex, IN.uv_MainTex);
		o.Albedo = c.rgb;
		// Metallic and smoothness come from slider variables
		
		o.Alpha = _Alpha;
	}
	ENDCG


		}

		FallBack "Diffuse"
}
