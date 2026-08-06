/*{
	"DESCRIPTION": "Mixes the first input with the second input using the specified amount.\n
		Amount:\nInput visibility between 0 (first input only) and 1 (second input only).  A value of .5 creates 50% transparency for each input.",
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
			"NAME": "Amount",
			"TYPE": "float",
			"DEFAULT": 0.5,
			"MIN": 0.0,
			"MAX": 1.0
		}		
	],
}*/

void main()
{     
    vec4 col1 = IMG_THIS_PIXEL(inputImage);
    vec4 col2 = IMG_THIS_PIXEL(inputImage2);

    gl_FragColor = col1 * Amount + col2 * (1.-Amount);
}