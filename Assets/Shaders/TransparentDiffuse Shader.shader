Shader "Custom/TransparentDigguse ZWrite"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _SpecColor ("Spec Color", Color) = (1,1,1,1)
        _Emission ("Emmisive Color", Color) = (0,0,0,0)
         Shininess ("Shininess", Range (0.01,1))= 0.7
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType" = "Transparent"}
        LOD 200

        Pass {
            ZWrite On
            ColorMask 0
           }
        Usepass "Transparent/Diffuse/FORWARD"
        }

        Fallback "Transparent/VertexLit"
     
}
