Shader "Custom/HeartSliceShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        // Add properties for plane position and normal
        _PlanePos ("Plane Position", Vector) = (0,0,0,0)
        _PlaneNorm ("Plane Normal", Vector) = (0,1,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        #include "UnityCG.cginc"

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos; // Needed for slicing logic
        };

        sampler2D _MainTex;
        float4 _PlanePos;
        float3 _PlaneNorm;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Slicing logic
            if (dot(IN.worldPos - _PlanePos.xyz, _PlaneNorm) > 0)
            {
                discard;
            }

            // Regular shader logic
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
