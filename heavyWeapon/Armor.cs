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
    class Armor
    {
        public Texture2D armorTexture;

        public Vector2 Position;

        public bool Active;
      
        public Color color;

        public TimeSpan ArmorSpanTime;

        public TimeSpan previousSpanTime;

        public int Width
        {
            get { return armorTexture.Width; }
        }

        public int Height
        {
            get { return armorTexture.Height; }
        }

        public Armor(Texture2D Armortexture, Vector2 pos, Color color)
        {
            armorTexture = Armortexture;
            Position = pos;                     
            this.color = color;           
            Active = false;
            ArmorSpanTime = TimeSpan.FromSeconds(10.0);
            previousSpanTime = TimeSpan.Zero;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(armorTexture, Position, null, color,
                    0.0f, new Vector2(Width / 2, Height / 2), 1.0f, SpriteEffects.None, 0f);
        }
    }
}
