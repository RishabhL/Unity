using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int MapWidth, int MapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] Noisemap = new float[MapWidth, MapHeight];

        System.Random prng = new System.Random(seed);
        Vector2[] octaveoffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveoffsets[i] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;


        float halfwidth = MapWidth / 2f;
        float halfheight = MapHeight / 2f;
        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float NoiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float SampleX = (x - halfwidth) / scale * frequency + octaveoffsets[i].x;
                    float SampleY = (y - halfheight) / scale * frequency + octaveoffsets[i].y;

                    float PerlinValue = Mathf.PerlinNoise(SampleX, SampleY * 2 - 1);
                    NoiseHeight += PerlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
                if (NoiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = NoiseHeight;
                }
                else if (NoiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = NoiseHeight;
                }
                Noisemap[x, y] = NoiseHeight;
            }
        }
        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                Noisemap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, Noisemap[x, y]);
            }
        }
        return Noisemap;
    }
}
