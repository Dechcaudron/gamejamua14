Shader "Taronja Studios/Wet Surface/Diffuse" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_FluidTex("Fluid Base (RGB)", 2D) = "white" {}
		_InfoTex("Concentration (R)", 2D) = "white" {}
		_Wetness("Wetness", Range(0,1)) = 1
		}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 300
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _FluidTex;
		sampler2D _InfoTex;
		fixed _Wetness;

		struct Input {
			fixed2 uv_MainTex;
			fixed2 uv_FluidTex;
			fixed2 uv_InfoTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 base = tex2D (_MainTex, IN.uv_MainTex);
			fixed4 fluid = tex2D (_FluidTex, IN.uv_FluidTex);
			fixed4 info = tex2D (_InfoTex, IN.uv_InfoTex);
			o.Albedo = lerp(base.rgb, fluid.rgb, info.r * _Wetness);
			o.Alpha = base.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
