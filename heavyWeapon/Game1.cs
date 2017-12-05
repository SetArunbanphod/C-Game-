using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace heavyWeapon
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int W, H;
        int scoreP_1, scoreP_2;
        SpriteFont font;

        KeyboardState currentKS;
        KeyboardState previousKS;

        Texture2D playerTexture_1;
        Animation playerAnimation_1;
        Player player_1;
        Texture2D cannonTexture;
        Cannon cannon;

        Texture2D playerTexture_2;
        Animation playerAnimation_2;
        Player player_2;

        //--------------------------------------------------------------------------------------------background
        Texture2D mainbackground;
        background layer1;
        background layer2;
        background layer3;

        //--------------------------------------------------------------------------------------------Enemy 1
        Texture2D enemyTexture;
        List<Enemy> enemies;
        TimeSpan enemySpanTime;
        TimeSpan previousSpanTime;

        //-------------------------------------------------------------------------------------------laser Enemy type1
        Texture2D laserTexture;
        List<Laser> lasers;
        TimeSpan fireTime;
        TimeSpan previousFireTime;

        //-------------------------------------------------------------------------------------------Enemy 2
        Texture2D enemyTexture2;
        List<Enemy> enemies2;
        TimeSpan enemySpanTime2;
        TimeSpan previousSpanTime2;

        //-------------------------------------------------------------------------------------------laser Enemy2 type1
        Texture2D laserTexture2;
        List<Laser> lasers2;
        TimeSpan fireTime2;
        TimeSpan previousFireTime2;

        //-------------------------------------------------------------------------------------------Enemy 3
        Texture2D enemyTexture3;
        List<Enemy> enemies3;
        TimeSpan enemySpanTime3;
        TimeSpan previousSpanTime3;

        //-------------------------------------------------------------------------------------------laser Enemy3 type1
        Texture2D laserTexture3;
        List<Laser> lasers3;
        TimeSpan fireTime3;
        TimeSpan previousFireTime3;

        //-------------------------------------------------------------------------------------------Enemy Boss
        Texture2D enemyTextureBoss;
        List<Enemy> enemiesBoss;
        TimeSpan enemySpanTimeBoss;
        TimeSpan previousSpanTimeBoss;

        Texture2D laserTextureBoss;
        List<Laser> lasersBoss_1;
        List<Laser> lasersBoss_2;
        TimeSpan fireTimeBoss;
        TimeSpan previousFireTimeBoss;

        //-------------------------------------------------------------------------------------------laserPlayer_1
        List<Laser> laserP_1;
        TimeSpan fireTimeP_1;
        TimeSpan previousFireTimeP_1;

        //------------------------------------------------------------------------------------------laserPlayer_2
        Texture2D laserTextureP_2;
        List<Laser> laserP_2;
        TimeSpan fireTimeP_2;
        TimeSpan previousFireTimeP_2;

        //------------------------------------------------------------------------------------------blast
        Texture2D blastTexture;
        List<Animation> blasts;

        //-------------------------------------------------------------------------------------------Option
        Texture2D OptionTexture;
        List<Enemy> Options;
        TimeSpan OptionSpanTime;
        TimeSpan previousSpanTime_O;

        Texture2D OptionTexture2;
        List<Enemy> Options2;
        TimeSpan OptionSpanTime2;
        TimeSpan previousSpanTime_O2;

        Texture2D OptionTexture3;
        List<Enemy> Options3;
        TimeSpan OptionSpanTime3;
        TimeSpan previousSpanTime_O3;

        //--------------------------------------------------------------------------------------------Armor
        Texture2D ArmorTexture;
        List<Animation> armors;
        TimeSpan armorSpanTime;
        TimeSpan previousSpanTime_A1;
        TimeSpan previousSpanTime_A2;

        Texture2D Pointmouse;

        Random random;
        bool End;
        Texture2D TextureEnd;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()//-------------------------------------------------------------------------------Initialize
        {
            scoreP_1 = 0;
            scoreP_2 = 0;
            End = false;
            //-----------------------------------------------------------enemy1
            enemies = new List<Enemy>();
            previousSpanTime = TimeSpan.Zero;
            enemySpanTime = TimeSpan.FromSeconds(1.0f);

            //-----------------------------------------------------------laser enemy1
            lasers = new List<Laser>();
            previousFireTime = TimeSpan.Zero;
            fireTime = TimeSpan.FromSeconds(0.5f);

            //-----------------------------------------------------------enemy 2
            enemies2 = new List<Enemy>();
            previousSpanTime2 = TimeSpan.FromSeconds(10.0f);
            enemySpanTime2 = TimeSpan.FromSeconds(5.0f);

            //-----------------------------------------------------------laser enemy2
            lasers2 = new List<Laser>();
            previousFireTime2 = TimeSpan.Zero;
            fireTime2 = TimeSpan.FromSeconds(1.0f);

            //-----------------------------------------------------------enemy 3
            enemies3 = new List<Enemy>();
            previousSpanTime3 = TimeSpan.FromSeconds(28.5f);
            enemySpanTime3 = TimeSpan.FromSeconds(5.0f);

            //-----------------------------------------------------------laser enemy3
            lasers3 = new List<Laser>();
            previousFireTime3 = TimeSpan.Zero;
            fireTime3 = TimeSpan.FromSeconds(1.0f);

            //-----------------------------------------------------------enemy Boss
            enemiesBoss = new List<Enemy>();
            previousSpanTimeBoss = TimeSpan.Zero;
            enemySpanTimeBoss = TimeSpan.FromSeconds(30.0f);

            lasersBoss_1 = new List<Laser>();
            lasersBoss_2 = new List<Laser>();
            fireTimeBoss = TimeSpan.FromSeconds(1.0f);
            previousFireTimeBoss = TimeSpan.Zero;

            //-------------------------------------------------------------laser P_1
            laserP_1 = new List<Laser>();
            previousFireTimeP_1 = TimeSpan.Zero;
            fireTimeP_1 = TimeSpan.FromSeconds(0.15f);

            //-------------------------------------------------------------laser P_2
            laserP_2 = new List<Laser>();
            previousFireTimeP_2 = TimeSpan.Zero;
            fireTimeP_2 = TimeSpan.FromSeconds(0.15f);

            //-------------------------------------------------------------blasts
            blasts = new List<Animation>();

            //--------------------------------------------------------------Armor
            armors = new List<Animation>();
            previousSpanTime_A1 = TimeSpan.Zero;
            previousSpanTime_A2 = TimeSpan.Zero;
            armorSpanTime = TimeSpan.FromSeconds(10.0f);

            //--------------------------------------------------------------Option
            Options = new List<Enemy>();
            previousSpanTime_O = TimeSpan.FromSeconds(10.0f);
            OptionSpanTime = TimeSpan.FromSeconds(20.0f);

            Options2 = new List<Enemy>();
            previousSpanTime_O2 = TimeSpan.FromSeconds(30.0f);
            OptionSpanTime2 = TimeSpan.FromSeconds(20.0f);

            Options3 = new List<Enemy>();
            previousSpanTime_O3 = TimeSpan.FromSeconds(20.0f);
            OptionSpanTime3 = TimeSpan.FromSeconds(20.0f);


            random = new Random();

            base.Initialize();
        }

        protected override void LoadContent()//------------------------------------------------------------------------------LoadContent
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            W = GraphicsDevice.Viewport.Width;
            H = GraphicsDevice.Viewport.Height;

            playerTexture_1 = Content.Load<Texture2D>("Hero1");
            playerAnimation_1 = new Animation(playerTexture_1, Vector2.Zero, 70, 125, 3, 100, Color.White,1.0f, true);
            player_1 = new Player(playerAnimation_1, new Vector2(50,H-50));
            cannonTexture = Content.Load<Texture2D>("GunHero1");
            cannon = new Cannon(cannonTexture, new Vector2(50, H - 50));

            mainbackground = Content.Load<Texture2D>("11");
            layer1 = new background(Content,"14", W, -2f);
            layer2 = new background(Content, "ma", W, -1f);
            layer3 = new background(Content, "12", W, -0.25f);

            font = Content.Load<SpriteFont>("gameFont");
            
            playerTexture_2 = Content.Load<Texture2D>("Hero2");
            playerAnimation_2 = new Animation(playerTexture_2, Vector2.Zero, 70, 54, 2, 150, Color.White, 1.2f, true);
            player_2 = new Player(playerAnimation_2, new Vector2(70,150));


            enemyTexture = Content.Load<Texture2D>("enemies1");

            enemyTexture2 = Content.Load<Texture2D>("enemies4");

            enemyTexture3 = Content.Load<Texture2D>("enemies2");

            enemyTextureBoss = Content.Load<Texture2D>("enemies15");

            laserTexture = Content.Load<Texture2D>("bulletEnemies2");

            laserTexture2 = Content.Load<Texture2D>("lgbEdit");

            laserTexture3 = Content.Load<Texture2D>("22");

            laserTextureBoss = Content.Load<Texture2D>("22");

            laserTextureP_2 = Content.Load<Texture2D>("laserP_2");

            TextureEnd = Content.Load<Texture2D>("SelectMap");
            ArmorTexture = Content.Load<Texture2D>("showbaria_1");//------------------------------------------armor

            //-------------------------------------------------------------------------------------------------Option
            OptionTexture = Content.Load<Texture2D>("baria2");
            OptionTexture2 = Content.Load<Texture2D>("nukeicon");
            OptionTexture3 = Content.Load<Texture2D>("Health2");

            blastTexture = Content.Load<Texture2D>("explosion");

            Pointmouse = Content.Load<Texture2D>("pointmouse");



        }        

        //-------------------------------------------------------------------------------------Add & Update Laser P_1
        void AddLaserP_1(Vector2 pos)
        {
            Laser laser = new Laser(laserTextureP_2, pos, new Vector2(cannon.pos_x, cannon.pos_y)* 20,cannon.angle ,10,Color.Yellow, GraphicsDevice.Viewport);
            laserP_1.Add(laser);
        }
        void UpdateLaserP_1()
        {
            for(int i = laserP_1.Count - 1; i >= 0; i--)
            {
                laserP_1[i].Update();
                if (laserP_1[i].Active == false)
                {
                    laserP_1.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update Laser P_2
        void AddLaserP_2(Vector2 pos)
        {
            Laser laser = new Laser(laserTextureP_2, pos, new Vector2(20, 0),0.0f, 10,Color.Yellow, GraphicsDevice.Viewport);
            laserP_2.Add(laser);
        }
        void UpdateLaserP_2()
        {
            for(int i = laserP_2.Count - 1; i >= 0; i--)
            {
                laserP_2[i].Update();
                if (laserP_2[i].Active == false)
                {
                    laserP_2.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update Laser enemy
        void AddLaserE_1(Vector2 pos)
        {
            Laser laserP_2 = new Laser(laserTexture, pos, new Vector2(-5, 3),0.0f, 1,Color.Red, GraphicsDevice.Viewport);
            lasers.Add(laserP_2);
        }
        void UpdateLaser()
        {
            for(int i = lasers.Count - 1; i >= 0; i--)
            {
                lasers[i].Update();
                if (lasers[i].Active == false)
                {
                    AddBlast(lasers[i].Position);
                    lasers.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update Laser enemy 2
        void AddLaserE_2(Vector2 pos)
        {
            Laser laser = new Laser(laserTexture2, pos, new Vector2(-5, 0), 0.0f, 3,Color.White, GraphicsDevice.Viewport);
            lasers2.Add(laser);
        }
        void UpdateLaser2()
        {
            for(int i = lasers2.Count - 1; i >= 0; i--)
            {
                lasers2[i].Update();
                if (lasers2[i].Active == false)
                {
                    AddBlast(lasers2[i].Position);
                    lasers2.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update Laser enemy 3
        void AddLaserE_3(Vector2 pos)
        { 
            Laser laser = new Laser(laserTexture3, pos, new Vector2(player_2.pos_.X,player_2.pos_.Y)*10, player_2.angle, 5, Color.White,GraphicsDevice.Viewport);
            lasers3.Add(laser);
        }
        void UpdateLaser3()
        {
            for (int i = lasers3.Count - 1; i >= 0; i--)
            {
                lasers3[i].Update();
                if (lasers3[i].Active == false)
                {
                    AddBlast(lasers3[i].Position);
                    lasers3.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update Laser Boss
        void AddLaserBoss_1(Vector2 pos)
        {
            Laser laser = new Laser(laserTextureBoss, pos, new Vector2(player_1.pos_.X, player_1.pos_.Y) * 10, player_1.angle, 5, Color.White, GraphicsDevice.Viewport);
            lasersBoss_1.Add(laser);
        }
        void UpdateLaserBoss_1()
        {
            for (int i = lasersBoss_1.Count - 1; i >= 0; i--)
            {
                lasersBoss_1[i].Update();
                if (lasersBoss_1[i].Active == false)
                {
                    AddBlast(lasersBoss_1[i].Position);
                    lasersBoss_1.RemoveAt(i);
                }
            }
        }
        void AddLaserBoss_2(Vector2 pos)
        {
            Laser laser = new Laser(laserTexture3, pos, new Vector2(player_2.pos_.X, player_2.pos_.Y) * 10, player_2.angle, 5, Color.White, GraphicsDevice.Viewport);
            lasersBoss_2.Add(laser);
        }
        void UpdateLaserBoss_2()
        {
            for (int i = lasersBoss_2.Count - 1; i >= 0; i--)
            {
                lasersBoss_2[i].Update();
                if (lasersBoss_2[i].Active == false)
                {
                    AddBlast(lasersBoss_2[i].Position);
                    lasersBoss_2.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update Enemy 1
        void AddEnemy()
        {
            Animation enemyAnimation = new Animation(enemyTexture, Vector2.Zero,
                                                    118, 116,3, 100, Color.White, 0.75f, true);
            Vector2 pos = new Vector2(W + enemyAnimation.FrameWidth, random.Next(20, H-150));
            Enemy enemy = new Enemy(enemyAnimation, pos, new Vector2(-5, 0), 10, 5, 10,1);
            enemies.Add(enemy); 
        }
        void UpdateEnemies(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousSpanTime > enemySpanTime)
            {
                previousSpanTime = gameTime.TotalGameTime;
                AddEnemy();
            }            
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Update(gameTime);
                if (gameTime.TotalGameTime - previousFireTime > fireTime)
                {
                    previousFireTime = gameTime.TotalGameTime;
                    AddLaserE_1(enemies[i].Position);                    
                }
                if (enemies[i].Active == false)
                {
                    AddBlast(enemies[i].Position);
                    enemies.RemoveAt(i);
                }
            }
            
        }

        //-------------------------------------------------------------------------------------Add & Update Enemy 2
        void AddEnemy2()
        {
            Animation enemyAnimation = new Animation(enemyTexture2, Vector2.Zero, 
                                                     54, 56, 3, 50, Color.White, 1.5f, true);
            Vector2 pos = new Vector2(W + enemyAnimation.FrameWidth/2, H - 50);
            Enemy enemy = new Enemy(enemyAnimation, pos, new Vector2(-1, 0), 20, 10,20, 1);
            enemies2.Add(enemy);
        }
        void UpdateEnemies2(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousSpanTime2 > enemySpanTime2)
            {
                previousSpanTime2 = gameTime.TotalGameTime;
                AddEnemy2();
            }
            for(int i = enemies2.Count - 1; i >= 0; i--)
            {
                enemies2[i].Update(gameTime);
                if (gameTime.TotalGameTime - previousFireTime2 > fireTime2)
                {
                    previousFireTime2 = gameTime.TotalGameTime;
                    AddLaserE_2(enemies2[i].Position);
                }
                if (enemies2[i].Active == false)
                {
                    AddBlast(enemies2[i].Position);
                    enemies2.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update Enemy3
        void AddEnemy3()
        {
            Animation enemyAnimation = new Animation(enemyTexture3, Vector2.Zero,
                                                     43, 49, 4, 50, Color.White, 1.25f, true);
            Vector2 pos = new Vector2(W + enemyAnimation.FrameWidth / 2, H - 50);
            Enemy enemy = new Enemy(enemyAnimation, pos, new Vector2(-1, 0), 30, 15, 30, 1);
            enemies3.Add(enemy);
        }
        void UpdateEnemies3(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousSpanTime3 > enemySpanTime3)
            {
                previousSpanTime3 = gameTime.TotalGameTime;
                AddEnemy3();
            }
            for (int i = enemies3.Count - 1; i >= 0; i--)
            {
                enemies3[i].Update(gameTime);

                if (gameTime.TotalGameTime - previousFireTime3 > fireTime3)
                {
                    previousFireTime3 = gameTime.TotalGameTime;

                    AddLaserE_3(enemies3[i].Position - new Vector2(0, enemies3[i].Height / 2));

                    player_2.PositionAngle = enemies3[i].Position;
                }
                if (enemies3[i].Active == false)
                {
                    AddBlast(enemies3[i].Position);
                    enemies3.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update EnemyBoss
        void AddEnemyBoss()
        {
            Animation enemyAnimationBoss = new Animation(enemyTextureBoss, Vector2.Zero,175, 162, 2, 50, Color.White, 1.5f, true);
            Vector2 pos = new Vector2(700, 300);
            Enemy enemyBoss = new Enemy(enemyAnimationBoss, pos, new Vector2(0,-1), 1000, 10, 1000, 2);
            enemiesBoss.Add(enemyBoss); 
        }
        void UpdateEnemiesBoss(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousSpanTimeBoss > enemySpanTimeBoss)
            {
                previousSpanTimeBoss = gameTime.TotalGameTime;
                AddEnemyBoss();              
            }
            for (int i = enemiesBoss.Count - 1; i >= 0; i--)
            {
                enemiesBoss[i].Update(gameTime);

                if (gameTime.TotalGameTime - previousFireTimeBoss > fireTimeBoss)
                {
                    previousFireTimeBoss = gameTime.TotalGameTime;

                    AddLaserBoss_1(enemiesBoss[i].Position + new Vector2(-10, 60));

                    AddLaserBoss_2(enemiesBoss[i].Position + new Vector2(-10, -60));

                    player_1.PositionAngle = enemiesBoss[i].Position;

                    player_2.PositionAngle = enemiesBoss[i].Position;
                }
                if (enemiesBoss[i].Active == false)
                {
                    AddBlast(enemiesBoss[i].Position);
                    enemiesBoss.RemoveAt(i);
                    End = true;
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update Blast
        void AddBlast(Vector2 pos)
        {
            Animation blastAanimation = new Animation(blastTexture, pos,
                                                      134, 134, 12, 50, Color.White, 0.75f, false);
            blasts.Add(blastAanimation);
        }
        void UpdateBlast(GameTime gameTime)
        {
            for(int i = blasts.Count - 1; i >= 0; i--)
            {
                blasts[i].Update(gameTime);
                if (blasts[i].Active == false)
                {
                    blasts.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Option
        void AddOption()
        {
            Animation optionAinmation = new Animation(OptionTexture, Vector2.Zero, 32, 32, 1, 50, Color.White, 1.0f, true);
            Vector2 pos = new Vector2(random.Next(300,W-300), random.Next(100, H - 150));
            Enemy option = new Enemy(optionAinmation, pos, new Vector2(-2, 2), 10, 10, 100, 0);
            Options.Add(option);
        }
        void UpdateOption(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousSpanTime_O > OptionSpanTime)
            {
                previousSpanTime_O = gameTime.TotalGameTime;
                AddOption();
            }
            for (int i = Options.Count - 1; i >= 0; i--)
            {
                Options[i].Update(gameTime);
                if (Options[i].Active == false)
                {                  
                    Options.RemoveAt(i);
                }
            }
        }

        void AddOption2()
        {
            Animation optionAinmation = new Animation(OptionTexture2, Vector2.Zero, 32, 32, 1, 50, Color.White, 1.0f, true);
            Vector2 pos = new Vector2(random.Next(300, W - 300), random.Next(100, H - 150));
            Enemy option = new Enemy(optionAinmation, pos, new Vector2(-2, 2), 10, 10, 100, 0);
            Options2.Add(option);
        }
        void UpdateOption2(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousSpanTime_O2 > OptionSpanTime2)
            {
                previousSpanTime_O2 = gameTime.TotalGameTime;
                AddOption2();
            }
            for (int i = Options2.Count - 1; i >= 0; i--)
            {
                Options2[i].Update(gameTime);
                if (Options2[i].Active == false)
                {
                    Options2.RemoveAt(i);
                }
            }
        }

        void AddOption3()
        {
            Animation optionAinmation = new Animation(OptionTexture3, Vector2.Zero, 32, 32, 1, 50, Color.White, 1.0f, true);
            Vector2 pos = new Vector2(random.Next(300, W - 300), random.Next(100, H - 150));
            Enemy option = new Enemy(optionAinmation, pos, new Vector2(-2, 2), 10, 10, 100, 0);
            Options3.Add(option);
        }
        void UpdateOption3(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousSpanTime_O3 > OptionSpanTime3)
            {
                previousSpanTime_O3 = gameTime.TotalGameTime;
                AddOption3();
            }
            for (int i = Options3.Count - 1; i >= 0; i--)
            {
                Options3[i].Update(gameTime);
                if (Options3[i].Active == false)
                {
                    Options3.RemoveAt(i);
                }
            }
        }

        //-------------------------------------------------------------------------------------Add & Update Armor
        void AddArmor(Vector2 pos)
        {
            Animation armor = new Animation(ArmorTexture, pos,
                                            110, 110, 1, 50, Color.White, 1.0f,false);
            armors.Add(armor);
        }
        void UpdateArmor(GameTime gameTime)
        {
            for (int i = armors.Count - 1; i >= 0; i--)
            {
                armors[i].Update(gameTime);
                if (armors[i].Active == false)
                {
                    armors.RemoveAt(i);
                }
            }
        }

        protected override void UnloadContent()//--------------------------------------------------------------------------------UnLoad
        {
            
        }

        protected override void Update(GameTime gameTime)//----------------------------------------------------------------------Update
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            previousKS = currentKS;
            currentKS = Keyboard.GetState();

            UpdatePlayre_1(gameTime);

            UpdatePlayre_2(gameTime);

            UpdateCollisionPlayer(gameTime);

            UpdateEnemies(gameTime);

            UpdateEnemies2(gameTime);

            UpdateEnemies3(gameTime);

            UpdateEnemiesBoss(gameTime);

            UpdateLaser();

            UpdateLaser2();

            UpdateLaser3();

            UpdateLaserBoss_1();

            UpdateLaserBoss_2();

            UpdateLaserP_1();

            UpdateLaserP_2();

            UpdateCollision(gameTime);

            UpdateBlast(gameTime);

            UpdateArmor(gameTime);

            UpdateOption(gameTime);

            UpdateOption2(gameTime);

            UpdateOption3(gameTime);

            layer1.Update();
            layer2.Update();
            layer3.Update();

            base.Update(gameTime);
        }

        void UpdateCollisionPlayer(GameTime gameTime)
        {
            Rectangle rectPlayer_1;
            Rectangle rectPlayer_2;

            rectPlayer_1 = new Rectangle((int)player_1.position.X, (int)player_1.position.Y,
                                        player_1.Width, player_1.Height);
            rectPlayer_2 = new Rectangle((int)player_2.position.X, (int)player_2.position.Y,
                                        player_2.Width, player_2.Height);

            if (rectPlayer_2.Intersects(rectPlayer_1))
            {
                if (player_2.position.Y < player_1.position.Y)
                {
                    player_2.position.Y = MathHelper.Clamp(player_1.position.Y, 0, player_1.position.Y-player_2.Height);              
                }
                if (player_2.position.X < player_1.position.X)
                {
                    player_2.position.X = MathHelper.Clamp(player_1.position.X, 0, player_1.position.X - player_1.Width);
                }
                if (player_2.position.X > player_1.position.X)
                {
                    player_2.position.X = MathHelper.Clamp(player_1.position.X, player_1.position.X + player_1.Width,W );
                }
            }
            
        }

        void UpdatePlayre_1(GameTime gameTime)
        {
            player_1.Update(gameTime);

            cannon.Update();

            if (cannon.IsleftPressed() == true)
            {
                if (gameTime.TotalGameTime - previousFireTimeP_1 > fireTimeP_1)
                {
                    previousFireTimeP_1 = gameTime.TotalGameTime;
                    AddLaserP_1(player_1.position + new Vector2(cannon.pos_x, cannon.pos_y) * (cannon.Width * 3 / 4));
                }
            }
            if (currentKS.IsKeyDown(Keys.Left))
            {
                player_1.position.X = player_1.position.X - player_1.speed;
            }
            if (currentKS.IsKeyDown(Keys.Right))
            {
                player_1.position.X = player_1.position.X + player_1.speed;
            }
            //------------------------------------------------------------------------------------------------jump
            if (currentKS.IsKeyDown(Keys.Up) && player_1.jump == false)
            {
                player_1.position.Y -= 10f;
                player_1.Velocity.Y = -5f;
                player_1.jump = true;
            }

            if (player_1.jump == true)
            {
                float i = 1.5f;
                player_1.Velocity.Y += 0.15f * i;
            }

            if (player_1.position.Y >= H-50)
                player_1.jump = false;


            if (player_1.jump == false)
                player_1.Velocity.Y = 0f;

            //-----------------------------------------------------------------------------------------------
            if (currentKS.IsKeyDown(Keys.Down))
            {
                player_1.position.Y = player_1.position.Y + player_1.speed;
            }
            if (player_1.Armor == true)
            {
                AddArmor(player_1.position);
                if (gameTime.TotalGameTime - previousSpanTime_A1 > armorSpanTime)
                {
                    player_1.Armor = false;
                }                
            }
           
            cannon.Position = player_1.position;

            player_1.position.X = MathHelper.Clamp(player_1.position.X, 0, W);
            player_1.position.Y = MathHelper.Clamp(player_1.position.Y, 0, H-50);
        }

        void UpdatePlayre_2(GameTime gameTime)
        {
            player_2.Update(gameTime);
            if (currentKS.IsKeyDown(Keys.Space))
            {
                if (gameTime.TotalGameTime - previousFireTimeP_2 > fireTimeP_2)
                {
                    previousFireTimeP_2 = gameTime.TotalGameTime;
                    AddLaserP_2(player_2.position + new Vector2(player_2.Width / 2, 17));
                }
            }
            if (currentKS.IsKeyDown(Keys.A))
            {
                player_2.position.X = player_2.position.X - player_2.speed;
            }
            if (currentKS.IsKeyDown(Keys.D))
            {
                player_2.position.X = player_2.position.X + player_2.speed;
            }
            if (currentKS.IsKeyDown(Keys.W))
            {
                player_2.position.Y = player_2.position.Y - player_2.speed;
            }
            if (currentKS.IsKeyDown(Keys.S))
            {
                player_2.position.Y = player_2.position.Y + player_2.speed;
            }
            if (player_2.Armor == true)
            {
                AddArmor(player_2.position);
                if (gameTime.TotalGameTime - previousSpanTime_A2 > armorSpanTime)
                {
                    player_2.Armor = false;
                }

            }


            player_2.position.X = MathHelper.Clamp(player_2.position.X, 0, W);
            player_2.position.Y = MathHelper.Clamp(player_2.position.Y, 0, H);

        }

        void Nuclears(List<Enemy> Eenemy , List<Laser> Llaser)
        {
            Rectangle rectNuclear;
            Rectangle rectEnemy;
            Rectangle rectLasers;

            rectNuclear = new Rectangle(0, 0, W, H);
            for (int i = 0; i < Eenemy.Count; i++)
            {
                for(int j = 0; j < Llaser.Count; j++)
                {
                    rectEnemy = new Rectangle((int)Eenemy[i].Position.X,
                                            (int)Eenemy[i].Position.Y,
                                            Eenemy[i].Width, Eenemy[i].Height);

                    rectLasers = new Rectangle((int)Llaser[j].Position.X,
                                             (int)Llaser[j].Position.Y,
                                             Llaser[j].Width, Llaser[j].Height);
                    if (rectNuclear.Intersects(rectEnemy)||rectNuclear.Intersects(rectLasers))
                    {
                        Eenemy[i].Health = 0;
                        Llaser[j].Active = false;
                    }
                }
            }
        }

        void Nuclear()
        {
            if (player_1.nuclear == true || player_2.nuclear == true)
            {
                Nuclears(enemies, lasers);
                Nuclears(enemies2, lasers2);
                Nuclears(enemies3, lasers3);
            }
            player_1.nuclear = false;
            player_2.nuclear = false;

        }

        void Option(GameTime gameTime ,List<Enemy> Options,int typeOption)
        {
            Rectangle rectPlayer_1;
            Rectangle rectPlayer_2;           
            Rectangle rectOption;

            rectPlayer_1 = new Rectangle((int)player_1.position.X, (int)player_1.position.Y,
                                        player_1.Width / 2, player_1.Height / 2);

            rectPlayer_2 = new Rectangle((int)player_2.position.X, (int)player_2.position.Y,
                                        player_2.Width / 2, player_2.Height / 2);

            //----------------------------------------------------------------------------------------------------------Option
            for (int i = 0; i < Options.Count; i++)
            {
                rectOption = new Rectangle((int)Options[i].Position.X,
                                         (int)Options[i].Position.Y,
                                         Options[i].Width, Options[i].Height);

                if (rectPlayer_1.Intersects(rectOption))
                {
                    if (typeOption == 1)
                    {
                        previousSpanTime_A1 = gameTime.TotalGameTime;
                        player_1.Armor = true;
                        Options[i].Active = false;                       
                    }
                    if (typeOption == 2)
                    {
                        player_1.nuclear = true;
                        Options[i].Active = false;
                    }
                    if (typeOption == 3)
                    {
                        player_1.Health = player_1.Health + 50;
                        Options[i].Active = false;
                    }
                }
                if (rectPlayer_2.Intersects(rectOption))
                {
                    if (typeOption == 1)
                    {
                        previousSpanTime_A2 = gameTime.TotalGameTime;
                        player_2.Armor = true;
                        Options[i].Active = false;
                    }
                    if (typeOption == 2)
                    {
                        player_2.nuclear = true;
                        Options[i].Active = false;
                    }
                    if (typeOption == 3)
                    {
                        player_2.Health = player_2.Health + 50;
                        Options[i].Active = false;
                    }
                }
            }
        }

        void Collision(GameTime gameTime,List<Enemy> e, List<Laser> l, List<Laser> l_P, int score)
        {

            Rectangle rectPlayer_1;
            Rectangle rectPlayer_2;
            Rectangle rectLaserP;
            Rectangle rectEnemy;
            Rectangle rectLasers;

            rectPlayer_1 = new Rectangle((int)player_1.position.X, (int)player_1.position.Y,
                                        player_1.Width / 2, player_1.Height / 2);

            rectPlayer_2 = new Rectangle((int)player_2.position.X, (int)player_2.position.Y,
                                        player_2.Width / 2, player_2.Height / 2);

            Option(gameTime, Options, 1);
            Option(gameTime, Options2, 2);
            Option(gameTime, Options3, 3);

            //-------------------------------------------------------------------------------------------------------------Player
            for (int j = 0; j < e.Count; j++)
            {
                for (int k = 0; k < l.Count; k++)
                {
                    rectEnemy = new Rectangle((int)e[j].Position.X,
                                            (int)e[j].Position.Y,
                                            e[j].Width, e[j].Height);

                    rectLasers = new Rectangle((int)l[k].Position.X,
                                             (int)l[k].Position.Y,
                                             l[k].Width, l[k].Height);

                    if (player_1.Armor == false)
                    {
                        if (rectPlayer_1.Intersects(rectEnemy))
                        {
                            player_1.Health -= e[j].Damage;
                            e[j].Health = 0;
                        }
                        if (rectPlayer_1.Intersects(rectLasers))
                        {
                            player_1.Health -= l[k].Damage;
                            l[k].Active = false;
                        }
                    }
                    if(player_1.Armor == true)
                    {
                        if (rectPlayer_1.Intersects(rectEnemy))
                        {
                            e[j].Health = 0;
                        }
                        if (rectPlayer_1.Intersects(rectLasers))
                        {
                            l[k].Active = false;
                        }
                    }

                    if (player_2.Armor == false)
                    {
                        if (rectPlayer_2.Intersects(rectEnemy))
                        {
                            player_2.Health -= e[j].Damage;
                            e[j].Health = 0;
                        }
                        if (rectPlayer_2.Intersects(rectLasers))
                        {
                            player_2.Health -= l[k].Damage;
                            l[k].Active = false;
                        }
                    }
                    if (player_2.Armor == true)
                    {
                        if (rectPlayer_2.Intersects(rectEnemy))
                        {
                            e[j].Health = 0;
                        }
                        if (rectPlayer_2.Intersects(rectLasers))
                        {
                            l[k].Active = false;
                        }
                    }
                }
            }
            //--------------------------------------------------------------------------------------------------------------laser p 
            for (int i = 0; i < l_P.Count; i++)
            {
                rectLaserP = new Rectangle((int)l_P[i].Position.X,
                                             (int)l_P[i].Position.Y,
                                             l_P[i].Width, l_P[i].Height);
                //--------------------------------------------------------------------------------Enemy
                for (int j = 0; j < e.Count; j++)
                {
                    for (int k = 0; k < l.Count; k++)
                    {
                        rectEnemy = new Rectangle((int)e[j].Position.X,
                                                (int)e[j].Position.Y,
                                                e[j].Width, e[j].Height);

                        rectLasers = new Rectangle((int)l[k].Position.X,
                                                 (int)l[k].Position.Y,
                                                 l[k].Width, l[k].Height);

                        if (rectLaserP.Intersects(rectEnemy))
                        {
                            e[j].Health -= l_P[i].Damage;
                            l_P[i].Active = false;
                            if (score == 1)
                            {
                                scoreP_1 += e[j].Value;
                            }
                            if (score == 2)
                            {
                                scoreP_2 += e[j].Value;
                            }
                        }
                        if (rectLaserP.Intersects(rectLasers))
                        {
                            l_P[i].Active = false;
                            l[k].Active = false;
                        }                       
                    }
                }
            }
        }

        void UpdateCollision(GameTime gameTime)
        {
            Nuclear();
            //player 1
            Collision(gameTime, enemies, lasers, laserP_1,1);

            //-----------------------------------------------------------------------------------------Collision E_2
            Collision(gameTime, enemies2, lasers2, laserP_1,1);

            //------------------------------------------------------------------------------------------Collision E_3
            Collision(gameTime, enemies3, lasers3, laserP_1,1);

            //------------------------------------------------------------------------------------------Boss
            Collision(gameTime, enemiesBoss, lasersBoss_1, laserP_1, 1);
            Collision(gameTime, enemiesBoss, lasersBoss_2, laserP_1, 1);

            //Player 2
            //-----------------------------------------------------------------------------------------Collision E_1
            Collision(gameTime, enemies, lasers, laserP_2,2);

            //-----------------------------------------------------------------------------------------Collision E_2
            Collision(gameTime, enemies2, lasers2, laserP_2,2);

            //------------------------------------------------------------------------------------------Collision E_3
            Collision(gameTime, enemies3, lasers3, laserP_2,2);

            //------------------------------------------------------------------------------------------Boss
            Collision(gameTime, enemiesBoss, lasersBoss_1, laserP_2, 2);
            Collision(gameTime, enemiesBoss, lasersBoss_2, laserP_2, 2);

        }

        protected override void Draw(GameTime gameTime)//------------------------------------------------------------------------Draw
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(mainbackground, Vector2.Zero, Color.White);
            layer3.Draw(spriteBatch);
            layer2.Draw(spriteBatch);
            layer1.Draw(spriteBatch);

            

            for (int i = 0; i < laserP_1.Count; i++)
            {
                laserP_1[i].Draw(spriteBatch);
            }

            player_1.Draw(spriteBatch);

            for (int i = 0; i < laserP_2.Count; i++)
            {
                laserP_2[i].Draw(spriteBatch);
            }
            cannon.Draw(spriteBatch);
            player_2.Draw(spriteBatch);

            //------------------------------------------------------------enemylaser
            for (int i = 0; i < lasers.Count; i++)
            {
                lasers[i].Draw(spriteBatch);
            }

            for (int i = 0; i < lasers2.Count; i++)
            {
                lasers2[i].Draw(spriteBatch);
            }

            for (int i = 0; i < lasers3.Count; i++)
            {
                lasers3[i].Draw(spriteBatch);
            }

            for (int i = 0; i < lasersBoss_1.Count; i++)
            {
                lasersBoss_1[i].Draw(spriteBatch);
            }
            for (int i = 0; i < lasersBoss_2.Count; i++)
            {
                lasersBoss_2[i].Draw(spriteBatch);
            }

            //---------------------------------------------------------------enemy
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(spriteBatch);
            }

            for(int i = 0; i < enemies2.Count; i++)
            {
                enemies2[i].Draw(spriteBatch);
            }

            for (int i = 0; i < enemies3.Count; i++)
            {
                enemies3[i].Draw(spriteBatch);
            }

            for (int i = 0; i < enemiesBoss.Count; i++)
            {
                enemiesBoss[i].Draw(spriteBatch);
            }
            //--------------------------------------------------------------------Option
            for (int i = 0; i < Options.Count; i++)
            {
                Options[i].Draw(spriteBatch);

            }

            for (int i = 0; i < Options2.Count; i++)
            {
                Options2[i].Draw(spriteBatch);
            }

            for (int i = 0; i < Options3.Count; i++)
            {
                Options3[i].Draw(spriteBatch);
            }


            for (int i = 0; i < armors.Count; i++)
            {
                armors[i].Draw(spriteBatch);
            }

            for (int i = 0; i < blasts.Count; i++)
            {
                blasts[i].Draw(spriteBatch);
            }

            //-----------------------------------------------------------------------------Score
            spriteBatch.DrawString(font, "SCORE PLAYER 1 : " + scoreP_1, new Vector2(10, 10), 
                                   Color.Black,0.0f,new Vector2(0,0),0.5f,SpriteEffects.None,0.0f);

            spriteBatch.DrawString(font, "SCORE PLAYER 2 : " + scoreP_2, new Vector2(W-150, 10),
                                   Color.Black, 0.0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0.0f);

            //-------------------------------------------------------------------------------health
            spriteBatch.DrawString(font, "HEALTH PLAYER 1 : " + player_1.Health, new Vector2(10, 30),
                                   Color.Black, 0.0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(font, "HEALTH PLAYER 2 : " + player_2.Health, new Vector2(W-150, 30),
                                   Color.Black, 0.0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0.0f);

            if (player_1.Armor == true)
            {
                spriteBatch.DrawString(font, "PLAYER 1 : ARMOR " , new Vector2(10, 50),
                                   Color.Red, 0.0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0.0f);
            }
            if (player_2.Armor == true)
            {
                spriteBatch.DrawString(font, "PLAYER 2 : ARMOR ", new Vector2(W-150, 50),
                                   Color.Red, 0.0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0.0f);
            }
            if (End)
            {
                
                spriteBatch.Draw(TextureEnd, Vector2.Zero, Color.White);
                spriteBatch.DrawString(font, "WINNER ", new Vector2(350, 200),
                                   Color.Red, 0.0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0.0f);
            }
            spriteBatch.Draw(Pointmouse, new Vector2(Mouse.GetState().X-Pointmouse.Width/2, Mouse.GetState().Y - Pointmouse.Height / 2));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
