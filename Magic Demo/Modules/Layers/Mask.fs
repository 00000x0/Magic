/*{
	"DESCRIPTION": "Creates transparency in the first input by using the second input as a mask.\n\nUse Alpha:\nWhen enabled (default), the transparent region is created by using the alpha channel of the mask. Otherwise, the color channels are used.",
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "inputImage2",
			"TYPE": "image"
		},
		{
			"LABEL": "Use Alpha",
			"NAME": "alpha",
			"TYPE": "bool",
			"DEFAULT": 1.0
		}
	],
}*/

void main()
{
	vec4 maskCol = IMG_THIS_PIXEL(inputImage2);
    gl_FragColor = IMG_THIS_PIXEL(inputImage) * ((alpha==true) ? maskCol : maskCol.rrrr);
}