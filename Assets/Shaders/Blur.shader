Shader "UI/Blur" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Tint Color (RGB)", 2D) = "white" {}
        _Size ("Size", Range(0, 20)) = 1
    }
 
    Category {
 
        // Set it transparent so other objects are drawn before this one.
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        
		Lighting Off
		ZWrite Off
		
        SubShader {
            // Grab screen before horizontal blurring
            GrabPass {                    
                Tags { "LightMode" = "Always" }
            }
            // Horizontal blur
            Pass {
                Tags { "LightMode" = "Always" }
             
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // Select a precision to minimize program execution time.
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"
             
                struct appdata_t {
                    float4 vertex : POSITION;
                    float2 texcoord: TEXCOORD0;
                };
             
                struct v2f {
                    float4 vertex : POSITION;
                    float4 uvgrab : TEXCOORD0;
                };
             
                v2f vert (appdata_t v) {
                    v2f o;
                    // Transforms a point from object space to the camera’s clip space in homogeneous coordinates. 
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    
                    // Flip coordinates if needed.
                    #if UNITY_UV_STARTS_AT_TOP
                    float scale = -1.0;
                    #else
                    float scale = 1.0;
                    #endif
                    
                    // Calculate UV values
                    o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y * scale) + o.vertex.w) * 0.5;
                    o.uvgrab.zw = o.vertex.zw;
                    return o;
                }
             
                sampler2D _GrabTexture;
                float4 _GrabTexture_TexelSize;
                float _Size;
             
                half4 frag( v2f i ) : COLOR {
                 
                    half4 sum = half4(0, 0, 0, 0);
                    
                    #define GRAB_HORIZONTAL(weight, kernelx) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x + _GrabTexture_TexelSize.x * kernelx*_Size, i.uvgrab.y, i.uvgrab.z, i.uvgrab.w))) * weight
                    sum += GRAB_HORIZONTAL(0.333, -1.0);
                    sum += GRAB_HORIZONTAL(0.333,  0.0);
                    sum += GRAB_HORIZONTAL(0.333, +1.0);
                 
                    return sum;
                }
                ENDCG
            }
            
            // Grab screen after horizontal blurring
            GrabPass {                        
                Tags { "LightMode" = "Always" }
            }
            // Vertical blur
            Pass {
                Tags { "LightMode" = "Always" }
             
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // Select a precision to minimize program execution time.
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"
             
                struct appdata_t {
                    float4 vertex : POSITION;
                    float2 texcoord: TEXCOORD0;
                };
             
                struct v2f {
                    float4 vertex : POSITION;
                    float4 uvgrab : TEXCOORD0;
                };
             
                v2f vert (appdata_t v) {
                    v2f o;
                    // Transforms a point from object space to the camera’s clip space in homogeneous coordinates. 
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    
                    // Flip coordinates if needed.
                    #if UNITY_UV_STARTS_AT_TOP
                    float scale = -1.0;
                    #else
                    float scale = 1.0;
                    #endif
                    
                    // Calculate UV values
                    o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y * scale) + o.vertex.w) * 0.5;
                    o.uvgrab.zw = o.vertex.zw;
                    return o;
                }
             
             	fixed4 _Color;
                sampler2D _GrabTexture;
                float4 _GrabTexture_TexelSize;
                float _Size;
             
                half4 frag( v2f i ) : COLOR {
                    half4 sum = half4(0, 0, 0, 0);

                   #define GRAB_VERTICAL(weight, kernely) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x, i.uvgrab.y + _GrabTexture_TexelSize.y * kernely*_Size, i.uvgrab.z, i.uvgrab.w))) * weight
                 
                    sum += GRAB_VERTICAL(0.333, -1.0);
                    sum += GRAB_VERTICAL(0.333,  0.0);
                    sum += GRAB_VERTICAL(0.333, +1.0);
                    
                    return sum * _Color;
                }
                ENDCG
            }
        }
    }
}