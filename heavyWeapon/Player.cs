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
    class Player
    {
        public Animation playerAnimation;

        public Vector2 position;

        public int Health;
        
        public bool Active;

        public float speed;

        public Vector2 Velocity;

        public Vector2 PositionAngle;

        public Vector2 pos_;

        public float angle;

        public bool nuclear;

        public bool Armor;

        public bool jump;

        public Player(Animation animation,Vector2 pos)
        {
            playerAnimation = animation;
          
            position = pos;
            Active = true;
            Health = 1000;
            Armor = false;
            speed = 5.0f;
            Velocity = Vector2.Zero;
            nuclear = false;
            jump = true;
        }

        public int Width
        {
            get { return playerAnimation.FrameWidth; }
        }
        public int Height
        {
            get { return playerAnimation.FrameHeight; }
        }

        public void Update(GameTime gameTime)
        {
            position += Velocity;

            playerAnimation.Position = position;
            playerAnimation.Update(gameTime);

            double x = position.X + Width/2 - PositionAngle.X;
            double y = position.Y + Height/2 - PositionAngle.Y;

            angle = (float)Math.Atan2(y, x);
            pos_.X = (float)Math.Cos(angle);
            pos_.Y = (float)Math.Sin(angle);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            playerAnimation.Draw(spriteBatch);
        }
    }
}
