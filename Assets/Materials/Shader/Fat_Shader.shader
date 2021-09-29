Shader "Zaka/Normal Fat Shader" {

    Properties{
      _MainTex("Texture", 2D) = "white" {}
      _Color("Color", Color) = (0,0,0,0)
      _Amount("Extrusion Amount", Range(-1,1)) = 0.5
      _BumpMap("Bumpmap", 2D) = "bump" {}
      _RimColor("Rim Color", Color) = (0.26,0.19,0.16,0.0)
      _RimPower("Rim Power", Range(0.5,8.0)) = 3.0
    }
        SubShader{
          Tags { "RenderType" = "Opaque" }
          CGPROGRAM

          #pragma surface surf Lambert vertex:vert

          struct Input {
              float2 uv_MainTex;
              float2 uv_BumpMap;
              float3 viewDir;
          };

          fixed4 _Color;
          float _Amount;
          sampler2D _MainTex;
          sampler2D _BumpMap;

          //Lighting
          float4 _RimColor;
          float _RimPower;

          void vert(inout appdata_full v) {
              v.vertex.xyz += v.normal * _Amount;
          }

          void surf(Input IN, inout SurfaceOutput o) {

              //standard texture
              o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _Color;

              //normals
              o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

              //Lighting
              half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
              o.Emission = _RimColor.rgb * pow(rim, _RimPower);
          }
          ENDCG
      }
          Fallback "Diffuse"
}
