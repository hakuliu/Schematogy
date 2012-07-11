using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Schematogy.Util
{
    class Sprite
    {
        private enum SpriteState
        {
            Stopped,
            Playing
        }
        private int currentFrame;
        private SpriteContent content;
        private TimeSpan playTime;
        private bool loop;
        private SpriteState state;
        private double framerate;

        public Sprite(SpriteContent content, bool loopable, double framerate)
        {
            this.content = content;
            this.loop = loopable;
            this.framerate = framerate;
        }
        public void Play(GameTime gameTime)
        {
            this.playTime = gameTime.TotalGameTime;
            this.state = SpriteState.Playing;
        }

        public void Stop()
        {
            this.state = SpriteState.Stopped;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Rectangle destRect)
        {
            Rectangle sourceRect = new Rectangle(0, 0, content.Texture.Width, content.Texture.Height); ;
            if (content.Type == Schematogy.Util.SpriteContent.SpriteType.SimpleTexture)
            {
                sourceRect = new Rectangle(0, 0, content.Texture.Width, content.Texture.Height);
            }
            else if (content.Type == Schematogy.Util.SpriteContent.SpriteType.GridSpriteSheet)
            {
                if (state == SpriteState.Playing)
                {
                    TimeSpan diff = gameTime.TotalGameTime.Subtract(playTime);
                    double totalFrame = diff.TotalMilliseconds / this.framerate;
                    currentFrame = ((int)totalFrame) % content.FrameCount;
                    if (!loop && totalFrame >= content.FrameCount)
                    {
                        currentFrame = content.FrameCount - 1;
                    }
                }

                sourceRect = (content.AnimationFrames[currentFrame]);
            }



            spriteBatch.Draw(content.Texture, destRect, sourceRect, Color.White);
        }
    }
}
