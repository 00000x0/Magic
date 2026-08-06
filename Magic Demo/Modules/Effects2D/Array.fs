/*{
	"DESCRIPTION": "Creates copies of its input in the x and/or y directions.\n
			X Amount:\nNumber of copies in the x direction.  A higher value is more copies.\n
			X Distance:\nDistance between each copy in the x direction.\n
			Y Amount:\nNumber of copies in the y direction.  A higher value is more copies.\n
			Y Distance:\nDistance between each copy in the y direction.",
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "xIter",
			"LABEL": "X Amount",
			"TYPE": "float",
			"DEFAULT": 0.2,
			"MIN": 0.0
		},
		{
			"NAME": "xDist",
			"LABEL": "X Distance",
			"TYPE": "float",
			"DEFAULT": 0.2,
			"MIN": 0.001
		},	
		{
			"NAME": "yIter",
			"LABEL": "Y Amount",
			"TYPE": "float",
			"DEFAULT": 0.2,
			"MIN": 0.0
		},
		{
			"NAME": "yDist",
			"LABEL": "Y Distance",
			"TYPE": "float",
			"DEFAULT": 0.2,
			"MIN": 0.001
		},	
	],
	"PASSES": [
		{
			"TARGET": "tempBuffer"
		},
		{
		}
	]
}*/

void main()
{
	if (PASSINDEX == 0) {
		vec4 color = IMG_THIS_PIXEL(inputImage);

		float ratio = RENDERSIZE.y/RENDERSIZE.x;
		float curDist = xDist * ratio;
		float iter = 0.;
		while (iter < xIter && curDist < 1.) {
			color += IMG_NORM_PIXEL(inputImage, vec2(vv_FragNormCoord.x+curDist, vv_FragNormCoord.y));
			color += IMG_NORM_PIXEL(inputImage, vec2(vv_FragNormCoord.x-curDist, vv_FragNormCoord.y));
			curDist += xDist * ratio;
			iter += .1;
		}

		gl_FragColor = color;
	}
	else {
		vec4 color = IMG_THIS_PIXEL(tempBuffer);

		float curDist = yDist;
		float iter = 0.;
		while (iter < yIter && curDist < 1.) {
			color += IMG_NORM_PIXEL(tempBuffer, vec2(vv_FragNormCoord.x, vv_FragNormCoord.y+curDist));
			color += IMG_NORM_PIXEL(tempBuffer, vec2(vv_FragNormCoord.x, vv_FragNormCoord.y-curDist));
			curDist += yDist;
			iter += .1;
		}

		gl_FragColor = color;
	}
}