/*{
	"DESCRIPTION": "Creates a pixelation effect on its input.\n
		Amount:\nAmount of pixelation between 0 (minimum) and 1 (maximum).",
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "amount",
			"TYPE": "float",
			"DEFAULT": 0.15,
			"MIN": 0.0,
			"MAX": 1.0
		}		
	],
}*/

void main()
{
    vec2 pixelLocation = vv_FragNormCoord;
	
	float size = amount*amount;

    float cellSizeInPixels = 1. + (RENDERSIZE.x-1.) * size;
	float numPixels = RENDERSIZE.x/cellSizeInPixels;

    pixelLocation *= numPixels;
    pixelLocation  = floor(pixelLocation);
    pixelLocation /= numPixels;

    vec4 color = IMG_NORM_PIXEL(inputImage, pixelLocation+.5*size);

    gl_FragColor = color;
}