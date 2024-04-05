Shader "Custom/PointCloudGaussian"
{
    Properties
    {
        _Center ("Center", Vector) = (0,0,0,0)
        _Sigma ("Sigma", Float) = 1.0
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            float4 _Center;
            float _Sigma;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

                float dist = distance(v.vertex, _Center);
                float gaussian = exp(-pow(dist, 2) / (2 * pow(_Sigma, 2)));
                o.color = v.color * gaussian * _Color;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return i.color;
            }
            ENDCG
        }
    }
}
