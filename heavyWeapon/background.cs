using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace heavyWeapon
{
    class background
    {
        Texture2D texture;

        Vector2[] position;
        float speed;


        public background(ContentManager Content, string TextName,
            int ScreenWidth, float speed)
        {
            texture = Content.Load<Texture2D>(TextName);
            this.speed = speed;
            position = new Vector2[ScreenWidth / texture.Width + 1];

            for (int i = 0; i < position.Length; i++)
            {
                position[i] = new Vector2(i * texture.Width, 0);
            }

        }

        public void Update()
        {
            for (int i = 0; i < position.Length; i++)
            {
                position[i].X += speed;

                if (speed <= 0)
                {
                    if (position[i].X <= -texture.Width)
                    {
                        position[i].X = texture.Width * (position.Length - 1);
                    }
                }
                else
                {
                    if (position[i].X >= texture.Width * (position.Length - 1))
                    {
                        position[i].X = -texture.Width;
                    }
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < position.Length; i++)
            {
                sb.Draw(texture, position[i], Color.White);
            }
        }
    }
}
