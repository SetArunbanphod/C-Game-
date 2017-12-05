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
    class Cannon
    {
        MouseState CurrentMS;
        MouseState PreviousMS;

        Rectangle RectCannon;
        public Texture2D CannonTexture;

        public Vector2 Position;

        public float angle;

        public float pos_x;

        public float pos_y;

        public int Width
        {
            get { return CannonTexture.Width; }
        }
        public int Height
        {
            get { return CannonTexture.Height; }
        }

        public Cannon(Texture2D cannonTexture,Vector2 pos)
        {
            CannonTexture = cannonTexture;
            Position = pos;

        }
        public void Input()
        {
            double y = CurrentMS.Y - Position.Y;
            double x = CurrentMS.X - Position.X;
            angle = (float)Math.Atan2(y, x);
            pos_x = (float)Math.Cos(angle);
            pos_y = (float)Math.Sin(angle);
        }

        public void Update()
        {
            PreviousMS = CurrentMS;
            CurrentMS = Mouse.GetState();
            Input();
            RectCannon = new Rectangle((int)Position.X - 28, (int)Position.Y - 23, CannonTexture.Width, CannonTexture.Height);
        }
        public bool IsleftPressed()
        {
            if ((CurrentMS.LeftButton == ButtonState.Pressed)) //&& (PreviousMS.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(CannonTexture, RectCannon, null, Color.White,
                    angle, new Vector2(CannonTexture.Width /10.428f, CannonTexture.Height /3.587f),
                     SpriteEffects.None, 0);
        }
    }
}
