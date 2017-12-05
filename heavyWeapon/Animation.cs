using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace heavyWeapon
{
    class Animation
    {
        Texture2D spriteStrip;

        float scale;

        int frameTime;

        int frameCount;

        int elapseTime;

        int CurrentFrame;

        Color color;

        Rectangle sourceRect = new Rectangle();

        Rectangle destinationRect = new Rectangle();

        public int FrameWidth;

        public int FrameHeight;

        public bool Active;

        public bool Looping;

        public Vector2 Position;

        public Animation(Texture2D spriteStrip, Vector2 pos, int FrameWidth, int FrameHeight,
                         int frameCount, int frameTime, Color color, float scale, bool Looping)
        {
            this.spriteStrip = spriteStrip;
            Position = pos;
            this.FrameWidth = FrameWidth;
            this.FrameHeight = FrameHeight;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.color = color;
            this.scale = scale;
            this.Looping = Looping;

            elapseTime = 0;
            CurrentFrame = 0;
            Active = true;

        }

        public void Update(GameTime gameTime)
        {
            if (!Active)
            {
                return;

            }

            elapseTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapseTime > frameTime)
            {
                CurrentFrame++;
                if (CurrentFrame==frameCount)
                {
                    CurrentFrame = 0;
                    if (!Looping)
                    {
                        Active = false;

                    }
                }
                elapseTime = 0;
            }
            sourceRect = new Rectangle(CurrentFrame * FrameWidth, 0,
                                        FrameWidth, FrameHeight);
            destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale / 2),
                                            (int)Position.Y - (int)(FrameHeight * scale / 2),
                                            (int)(FrameWidth * scale), (int)(FrameHeight * scale));
        }

        public void Draw(SpriteBatch sb)
        {
            if (Active)
            {
                sb.Draw(spriteStrip, destinationRect, sourceRect, color);
            }
        }
    }

}
