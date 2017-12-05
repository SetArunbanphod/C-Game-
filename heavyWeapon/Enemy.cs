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
    class Enemy
    {
        public Animation enemyAnimation;

        public Vector2 Velocity;

        public Vector2 Position;

        public bool Active;

        public int Health;

        public int Damage;

        public int TypeEnemy;

        public int Value;

        public int Width
        {
            get { return enemyAnimation.FrameWidth; }
        }
        public int Height
        {
            get { return enemyAnimation.FrameHeight; }
        }

        public Enemy(Animation animation,Vector2 pos,Vector2 velocity,
                     int health,int damage,int value,int typeEnemy)
        {
            enemyAnimation = animation;
            Position = pos;
            Velocity = velocity;
            Health = health;
            Damage = damage;
            TypeEnemy = typeEnemy;
            Value = value;
            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity;
            enemyAnimation.Position = Position;
            enemyAnimation.Update(gameTime);

            if (TypeEnemy == 1)
            {
                if (Position.X < -Width || Health <= 0)
                {
                    Active = false;
                }
            }
            if (TypeEnemy == 2)
            {
                if (Position.Y <= 70 || Position.Y >= 400)
                {
                    Velocity.Y = -Velocity.Y;
                    Velocity.X = 1;
                }
                if (Position.X <= 500 || Position.X >= 750)
                {
                    Velocity.X = -Velocity.X;
                }
                if (Health <= 0)
                {
                    Active = false;
                }
            }
            if (TypeEnemy == 0)
            {
                if (Position.Y <= 30 || Position.Y >= 450)
                {
                    Velocity.Y = -Velocity.Y;
                }
                if(Position.X<=200 || Position.X >= 700)
                {
                    Velocity.X = -Velocity.X;
                }
            }
        }
        public void Draw(SpriteBatch sb)
        {
            enemyAnimation.Draw(sb);
        }
    }
}
