Shader "Custom/FallingPhoto" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	
			_Alpha("Alpha",Range(0,1.0)) = 1.0

	}
		SubShader{
				Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
				Blend SrcAlpha OneMinusSrcAlpha
				LOD 200
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert  alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		uniform float _Alpha;

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			
			o.Alpha = _Alpha;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
