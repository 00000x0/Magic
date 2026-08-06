/*{
	"DESCRIPTION": "Adjusts the transparency of its input.\n
		Amount:\nAmount of transparency between 0 (minimum) and 1 (maximum).",
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "amount",
			"TYPE": "float",
			"DEFAULT": 0.5,
			"MIN": 0.0,
			"MAX": 1.0
		}		
	],
}*/

void main()
{
    gl_FragColor = IMG_THIS_PIXEL(inputImage) * (1.-amount);
}