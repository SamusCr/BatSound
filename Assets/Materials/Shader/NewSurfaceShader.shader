Shader "Custom/NewSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,0)


		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_MainTex("Base (RGB)", 2D) = "white" {} // Regular object texture 
		_Transparency("Transparency", Range(0.0,0.5)) = 0.25 //Transparency if the object
       _CenterWeave("Center of the weave", vector) = (0,0,0,0) // El lugar done colisiona la bala - Lo modificaremos con el escript CountCenter 
       _RadiousWeave("Visibility Distance", float) = 10.0 // How close does the player have to be to make object visible
	}
	SubShader {
	Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
	 //ZWrite Off
		//Blend SrcAlpha OneMinusSrcAlpha
		//Cull front

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0	
		   
		 sampler2D _MainTex;


		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

	


		half _Glossiness;
		half _Metallic;
		float _Transparency;

		fixed4 _Color;
	
		 float4 _CenterWeave;
		 float _RadiousWeave;
		
		float4  _CentersWeave[50];


		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)


		void surf (Input IN, inout SurfaceOutputStandard o) {


			float3 objPos = mul(unity_WorldToObject, float4(IN.worldPos, 1)).xyz;

			for (int i = 0; i < 49; i++)
			{

				// Calculculamos la distancia desde la posición del jugador
				float dist = distance(IN.worldPos, _CentersWeave[i]);





				// Devuelve el color apropiado mientras dontro del area del radio que le ponemos a la oleada de sonido
				if (dist < _RadiousWeave)

				{
					fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color; //Colo en estado Visible
					o.Albedo = c.rgb;
					// Metallic and smoothness provienen de la barra que saldrá en el material
					o.Metallic = _Metallic;
					o.Smoothness = _Glossiness;
					o.Alpha = c.a;
				}

				else 
				{

				
				//En caso de estar fuera del centro de la explosión no le damos ningún valor para que no se vea ninguna textura


				}
			}


			//// Albedo comes from a texture tinted by color
			////fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			//o.Albedo = tex.rgb;
			//// Metallic and smoothness come from slider variables
			//o.Metallic = _Metallic;
			//o.Smoothness = _Glossiness;
			//o.Alpha = tex.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
