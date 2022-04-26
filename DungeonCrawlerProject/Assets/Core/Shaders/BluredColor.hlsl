void BluredColor_float(float4 Seed, float Min, float Max, float BlurX, float BlurY, out float4 Out) 
{
	//random number
	float randomno = frac(sin(dot(Seed.xy, float2(12.9898, 78.233))) * 43758.5453);

	//create noise from the random
	float noise = lerp(Min, Max, randomno);

	//sin and cos of noise to create two variables for the blur
	float uvx = float(sin(noise)) * BlurX;
	float uvy = float(cos(noise)) * BlurY;

	//add the noise to the UVs to create the blured image
	float4 uvpos = float4(Seed.x + uvx, Seed.y + uvy, Seed.zw);

	//set output
	Out = uvpos;
}