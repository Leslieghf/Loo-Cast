using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Background
{
    public class Background : MonoBehaviour
    {
        private Vector2 cameraPos;
        private Sprite backgroundSprite;
        private SpriteRenderer[,] backgroundSprites = new SpriteRenderer[3, 3];

        public virtual void Initialize()
        {
            cameraPos = Camera.main.transform.position;
            backgroundSprite = Resources.Load<Sprite>("Sprites/Background");

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    var obj = new GameObject();
                    obj.transform.parent = transform;
                    obj.transform.position = new Vector3(x * 128, y * 72, 10);
                    obj.name = $"Background@y:{x},x:{y}";
                    var renderer = obj.AddComponent<SpriteRenderer>();
                    renderer.sprite = backgroundSprite;
                    backgroundSprites[x + 1, y + 1] = renderer;
                }
            }
        }

        private void Update()
        {
            cameraPos = Camera.main.transform.position;
            Vector2 shift = Vector2.zero;
            if (cameraPos.x > backgroundSprites[1, 1].transform.position.x + 64)
            {
                shift.x = 1;
            }
            else if (cameraPos.x < backgroundSprites[1, 1].transform.position.x - 64)
            {
                shift.x = -1;
            }
            if (cameraPos.y > backgroundSprites[1, 1].transform.position.y + 36)
            {
                shift.y = 1;
            }
            else if (cameraPos.y < backgroundSprites[1, 1].transform.position.y - 36)
            {
                shift.y = -1;
            }

            shift.x *= backgroundSprite.bounds.size.x;
            shift.y *= backgroundSprite.bounds.size.y;

            if (shift.x != 0 || shift.y != 0)
            {
                transform.position = new Vector3(transform.position.x + shift.x, transform.position.y + shift.y, 10);
            }
        }
    } 
}
