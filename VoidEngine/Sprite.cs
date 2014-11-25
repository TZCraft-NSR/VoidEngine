using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace VoidEngine
{
    /// <summary>
    /// The Sprite class for VoidEngine
    /// </summary>
    public class Sprite
    {
        public struct AnimationSet
        {
            public string name;
            public Texture2D texture;
            public Point frameSize;
            public Point sheetSize;
            public int fps;
            public Point startPos;
        }

        public AnimationSet currentAnimation;
        public List<AnimationSet> animationSets = new List<AnimationSet>();

        protected Vector2 position;

        protected Point currentFrame;
        protected int lFTime;

        protected KeyboardState keyboardState, pKeyboardState;

        /// <summary>
        /// Creates the sprite with custom properties
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">the position</param>
        /// <param name="frameWidth">the width of each frame</param>
        /// <param name="frameHeight">the height of each frame</param>
        /// <param name="sheetWidth">the amount of frames, widthwise</param>
        /// <param name="sheetHeight">the ammount of frames, height wise</param>
        /// <param name="fps">the frames per milliseconds</param>
        public Sprite(Vector2 position)
        {
            this.position = position;
            lFTime = 0;
        }

        /// <summary>
        /// Put this in the Update function
        /// </summary>
        /// <param name="gameTime">The main GameTime</param>
        public virtual void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            lFTime += gameTime.ElapsedGameTime.Milliseconds;

            if (lFTime >= currentAnimation.fps)
            {
                currentFrame.X++;

                if (currentFrame.X >= currentAnimation.sheetSize.X)
                {
                    currentFrame.Y++;
                    currentFrame.X = 0;

                    if (currentFrame.Y >= currentAnimation.sheetSize.Y)
                    {
                        currentFrame.Y = 0;
                    }
                }

                lFTime = 0;
            }
        }

        public virtual void Update(GameTime gameTime, Vector2 a, Vector2 b, Vector2 c, Vector2 d)
        {
        }

        /// <summary>
        /// Put inbetween the spriteBatch.Begin and spriteBatch.End
        /// </summary>
        /// <param name="gameTime">The main GameTime</param>
        /// <param name="spriteBatch">The main SpriteBatch</param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentAnimation.texture, this.position, new Rectangle(currentFrame.X * currentAnimation.frameSize.X, currentFrame.Y * currentAnimation.frameSize.Y, currentAnimation.frameSize.X, currentAnimation.frameSize.Y), Color.White);
        }

        public void Addanimation(string name, Texture2D tex, Point frameSize, Point sheetsize, Point startPos, int millisecondsPerFrame)
        {
            AnimationSet tmpAni;
            tmpAni.name = name;
            tmpAni.texture = tex;
            tmpAni.frameSize = frameSize;
            tmpAni.sheetSize = sheetsize;
            tmpAni.startPos = startPos;
            tmpAni.fps = millisecondsPerFrame;
            animationSets.Add(tmpAni);
        }

        public void SetAnimation(string setName)
        {
            if (currentAnimation.name != setName)
            {
                foreach (AnimationSet a in animationSets)
                {
                    if (a.name == setName)
                    {
                        currentAnimation = a;
                        currentFrame = Point.Zero;
                    }
                }
            }
        }

        public virtual void AddAnimations(Texture2D tex)
        { }
    }
}