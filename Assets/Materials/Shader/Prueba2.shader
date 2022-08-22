// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Prueva2" {
    Properties{
        _MainTex("Base (RGB)", 2D) = "white" {} // Regular object texture 

       _CenterWeave("Center of the weave", vector) = (0,0,0,0) // The location of the player - will be set by script

       _RadiousWeave("Visibility Distance", float) = 10.0 // How close does the player have to be to make object visible
    }
        SubShader{
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
            Pass {
            Blend SrcAlpha OneMinusSrcAlpha
            LOD 200

            CGPROGRAM


            #pragma vertex vert
            #pragma fragment frag

            // Access the shaderlab properties
            uniform sampler2D _MainTex;
            uniform float4 _CenterWeave;
            uniform float _RadiousWeave;
            float4  _CentersWeave[50] ;

            // Input to vertex shader
            struct vertexInput {
                float4 vertex : POSITION;
                float4 texcoord : TEXCOORD0;
             };
            // Input to fragment shader
             struct vertexOutput {
                float4 pos : SV_POSITION;
                float4 position_in_world_space : TEXCOORD0;
                float4 tex : TEXCOORD1;
             };

             // VERTEX SHADER
             vertexOutput vert(vertexInput input)
             {
                vertexOutput output;
                output.pos = UnityObjectToClipPos(input.vertex);
                output.position_in_world_space = mul(unity_ObjectToWorld, input.vertex);
                output.tex = input.texcoord;
                return output;
             }

             // FRAGMENT SHADER
            float4 frag(vertexOutput input) : COLOR
            {


                for (int i = 0; i < 49; i++)
                {

                    // Calculate distance to player position
                    float dist = distance(input.position_in_world_space, _CentersWeave[i]);





                    // Return appropriate colour
                    if (dist < _RadiousWeave)

                    {
                        return tex2D(_MainTex, input.tex); // Visible
                    }


                    else {
                        float4 tex = tex2D(_MainTex, input.tex); // Outside visible range
                        tex.a = 0.1;
                        return tex;
                    }


                }

   
        }

       ENDCG
       }
        }
            //FallBack "Diffuse"
}