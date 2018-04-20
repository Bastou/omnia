Shader  "Custom/omnia/Torchlight Effect" {
    Properties
    {
        _MainTex ("Texture", 2D) = "black" {}
        _CenterX ("Center X", Range(0.0, 0.5)) = 0.25
        _CenterY ("Center Y", Range(0.0, 0.5)) = 0.25
        _Radius ("Radius", Range(0.0, 0.5)) = 0.25
        _Sharpness ("Sharpness", Range(1, 20)) = 1
        _Rotation ("Rotation", Range(0,4)) = 1.5
        _Transparency ("Transparency", Range(0,1)) = 1

    }

	
    SubShader
    {
    
        Tags {"Queue" = "Transparent" "RenderType" = "Transparent" }
        
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
		    
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"
           
            sampler2D _MainTex;
            float _CenterX, _CenterY;
            float _Radius;
            float _Sharpness;
            float _Rotation;          
            float _Transparency;
            
            fixed4 frag (v2f_img i) : SV_Target
            {
                float dist = distance( float2(_CenterX, _CenterY*_Rotation), float2(ComputeScreenPos(i.pos).x/_Rotation, (ComputeScreenPos(i.pos).y)) / _ScreenParams.x*_Rotation);
                
                //Défini la zone d'action sur tout le modele ciblé
                fixed4 col = tex2D(_MainTex, i.uv);
                col.a =  _Transparency * (1 - pow(dist / _Radius, _Sharpness));
 
                float a = 1.0 - col.r ; // make white transparent
                
                // Defini le mask. Pour 1px (col) => On défini ca valeur ( 1 - 0 = 1 = visible ; 1 - 1 = 0 = caché = noir)
                return col;
            }
 
            ENDCG
        }
    }
}

