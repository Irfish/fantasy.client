Shader "Custom/Draw"
{
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("MainTex", 2D) = "white" {}
		_AlphaScale("Alpha Scale", Range(0, 1)) = 1
		// 在 Properties 中添加要绘制的点位置信息
		_Point1("Point1",vector) = (100,100,0,0)
		_Point2("Point2",vector) = (200,200,0,0)
		//_LineWidth("LineWidth", range(1,20)) = 2.0
	}
	SubShader{
			Tags{ "Queue" = "Transparent" "IngnoreProjector" = "True" "RenderType" = "Transparent" }
			LOD 200

			Pass{
				ZWrite On
				ColorMask 0
			}

			Pass{
				Tags{ "LightMode" = "ForwardBase" }

				ZWrite Off
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag
				#include "Lighting.cginc"

				fixed4 _Color;
				sampler2D _MainTex;
				float4 _MainTex_ST;
				fixed _AlphaScale;


				float4 _Point1;
				float4 _Point2;
				//float _LineWidth;

				struct a2v {
					float4 vertex : POSITION;
					float4 normal : NORMAL;
					float4 texcoord : TEXCOORD0;
				};

				struct v2f {
					float4 position : SV_POSITION;
					float3 worldNormal : TEXCOORD0;
					float3 worldPos : TEXCOORD1;
					float2 uv : TEXCOORD2;
				};

				v2f vert(a2v v)
				{
					v2f f;
					f.position = UnityObjectToClipPos(v.vertex);

					//计算世界空间下的法线
					f.worldNormal = UnityObjectToWorldNormal(v.normal);

					//计算世界空间下的顶点
					f.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

					//计算变换后的纹理坐标
					f.uv = TRANSFORM_TEX(v.texcoord, _MainTex);

					return f;
				}

				fixed4 frag(v2f i) : SV_Target
				{

					//if (pow((i.position.x - _Point2.x),2) + pow((i.position.y - _Point2.y),2) < 100) {
					//	return fixed4(1,0,0,1);
					//}

					//if (pow((i.position.x - _Point2.x-35), 2) + pow((i.position.y - _Point2.y-35), 2) < 100) {
					//	return fixed4(1, 0, 0, 1);
					//}

					//x
					if ((unsigned int)i.position.y == 30 && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 1) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 2) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 3) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 4) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 5) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 6) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 7) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 8) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 9) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 10) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 11) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 12) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 13) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 14) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 15) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 16) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 17) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 18) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 19) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}
					//x
					if ((unsigned int)i.position.y == (30 + 35 * 20) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					{
						return fixed4(_Color);
					}

					
					//y
					if ((unsigned int)i.position.x == 305 && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 1) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 2) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 3) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 4) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 5) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 6) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 7) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 8) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 9) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 10) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 11) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 12) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 13) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 14) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 15) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 16) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 17) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 18) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 19) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}
					//y
					if ((unsigned int)i.position.x == (305 + 35 * 20) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					{
						return fixed4(_Color);
					}


					//if (fmod((unsigned int)i.position.x, 35)>29 && fmod((unsigned int)i.position.x, 35)<31 && (unsigned int)i.position.x> (305 -35 -2) && (unsigned int)i.position.x< (305 + 35 * 20 + (35 + 2)) && (unsigned int)i.position.y<731 && (unsigned int)i.position.y>30)
					//{
					//	return fixed4(_Color);
					//}
					//if (fmod((unsigned int)i.position.y, 35) > 29 && fmod((unsigned int)i.position.y, 35) < 31  && (unsigned int)i.position.y > (30) && (unsigned int)i.position.y < (30 + 35 * 20+(35+2)) && (unsigned int)i.position.x<1005 && (unsigned int)i.position.x>305)
					//{
					//	return fixed4(_Color);
					//}


					//归一
					fixed3 worldNormal = normalize(i.worldNormal);
					fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
					//纹理颜色
					fixed4 textColor = tex2D(_MainTex, i.uv);
					//反射颜色
					fixed3 albedo = textColor.rgb * _Color.rgb;

					//环境光
					fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;

					//漫反射
					fixed3 diffuse = _LightColor0.rgb * albedo * max(0, dot(worldNormal, worldLightDir));

					return fixed4(ambient + diffuse, textColor.a *_AlphaScale);//_AlphaScale);
				}

				ENDCG
			}
	
	}
	FallBack "Diffuse"
}
