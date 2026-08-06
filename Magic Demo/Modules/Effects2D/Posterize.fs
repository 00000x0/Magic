/*{
	"DESCRIPTION": "Creates a posterization effect on its input.\n
		Amount:\nAmount of posterization between 0 (minimum) and 1 (maximum).",
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "amount",
			"TYPE": "float",
			"DEFAULT": 0.85,
			"MIN": 0.0,
			"MAX": 1.0
		}		
	],
}*/

void main()
{
    vec4 color = IMG_THIS_PIXEL(inputImage);
	
	float invAmt = 1.-amount;
	float size = invAmt*invAmt;
	
    float numColors = 1. + 255.*(size);

    color.rgb *= numColors;
    color.rgb = floor(color.rgb);
    color.rgb /= numColors;

    gl_FragColor = color;
}