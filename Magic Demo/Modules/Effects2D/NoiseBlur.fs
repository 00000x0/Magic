/*{
	"DESCRIPTION": "Creates a grainy directional blur on its input.\n
		Amount:\nAmount of blur between 0 (minimum) and 1 (maximum).\n
		Angle:\nAngle of blur between 0 (minimum) and 1 (maximum).",
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "amount",
			"TYPE": "float",
			"DEFAULT": 0.2,
			"MIN": 0.0,
			"MAX": 1.0
		},
		{
			"NAME": "angle",
			"TYPE": "float",
			"DEFAULT": 0.5,
			"MIN": 0.0,
			"MAX": 1.0
		}		
	],
}*/

float rand(vec2 co)
{
    return fract(sin(dot(co.xy, vec2(12.9898,78.233))) * 43758.5453);
}

#define TWOPI 6.28318530718

void main()
{
	float x = cos(angle*TWOPI)*RENDERSIZE.y/RENDERSIZE.x;
	float y = sin(angle*TWOPI);
	
    gl_FragColor = IMG_NORM_PIXEL(inputImage, vv_FragNormCoord + amount * (rand(vv_FragNormCoord)-.5) * vec2(x,y));
}