using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace heavyWeapon
{
    class Laser
    {
        public Texture2D laserTexture;

        public Vector2 Position;

        public float angle;

        public Vector2 Velocity;

        public bool Active;

        public bool Shooting;

        public int Damage;

        Viewport ViewPort;

        public Color color;

        public int Width
        {
            get { return laserTexture.Width; }
        }

        public int Height
        {
            get { return laserTexture.Height; }
        }

        public Laser(Texture2D lasertexture,Vector2 pos,Vector2 velocity,float angle,
                     int damage,Color color,Viewport viewport)
        {
            laserTexture = lasertexture;
            Position = pos;
            Velocity = velocity;
            this.angle = angle;
            Damage = damage;
            this.color = color;
            ViewPort = viewport;
            Shooting = false;
            Active = true;

        }
        public void Update()
        {
            Position += Velocity;
            if ((Position.X + laserTexture.Width / 2 - 10 > ViewPort.Width) ||
                (Position.X < -ViewPort.Width) || (Position.Y + laserTexture.Height / 2 > ViewPort.Height)
                || (Position.Y < -ViewPort.Height))
            {
                Active = false;
            }

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(laserTexture, Position, null, color,
                    angle, new Vector2(Width / 2, Height / 2), 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
