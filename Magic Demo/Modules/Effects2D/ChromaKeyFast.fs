/*{
	"DESCRIPTION": "Creates alpha-channel transparency in its input according to color.\n
		Strength:\nAmount of transparency between 0 (minimum) and 1 (maximum).\n
		Falloff:\nHardness of the transparency edge between 0 (softest edge) and 1 (hardest edge).\n
		Color:\nColor to use for transparency.",
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
		{
			"NAME": "amount",
			"LABEL": "Strength",
			"TYPE": "float",
			"DEFAULT": 0.7,
			"MIN": 0.0,
			"MAX": 1.0
		},
		{
			"NAME": "softness",
			"LABEL": "Falloff",
			"TYPE": "float",
			"DEFAULT": 0.9,
			"MIN": 0.0,
			"MAX": 1.0
		},
		{
			"NAME": "color",
			"TYPE": "long",
			"LABELS": [
				"Green",
				"Blue"
			],
			"DEFAULT": 0
		}
	],
}*/

void main()
{
	vec3 colorToReplace = (color == 0) ? vec3(0., 1., 0.) : vec3(0., 0., 1.); 
	vec4 textureColor = IMG_THIS_PIXEL(inputImage);

	float rDiff = colorToReplace.r - textureColor.r;
	float gDiff = colorToReplace.g - textureColor.g;
	float bDiff = colorToReplace.b - textureColor.b;
		 
	float diff = length(vec3(rDiff, gDiff, bDiff));

	float softnessInv = 1.-softness;
	gl_FragColor = textureColor * clamp(1.-(amount+softnessInv*.5-diff)/softnessInv, 0., 1.);
}