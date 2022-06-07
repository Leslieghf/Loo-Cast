using UnityEngine;

namespace LooCast.Noise
{
    public class PerlinNoise
    {
        public int width = 256;
        public int height = 256;

        public float scale = 20.0f;

        public float offsetX = 100.0f;
        public float offsetY = 100.0f;

        public PerlinNoise(int width, int height, float scale, float offsetX, float offsetY)
        {
            this.width = width;
            this.height = height;

            this.scale = scale;

            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }

        public float Evaluate(int x, int y)
        {
            float xCoord = (float)x / width * scale + offsetX;
            float yCoord = (float)y / height * scale + offsetY;

            return Mathf.PerlinNoise(xCoord, yCoord);
        }
    } 
}
