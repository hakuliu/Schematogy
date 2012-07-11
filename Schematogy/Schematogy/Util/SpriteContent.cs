using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Schematogy.Util
{
    class SpriteContent
    {
        public enum SpriteType
        {
            SimpleTexture,
            GridSpriteSheet,
            DynamicSpriteSheet
        }
        
        private Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
        }
        private SpriteType spriteType;
        public SpriteType Type
        {
            get { return spriteType; }
        }
        private Rectangle[] animationSrcs;
        public Rectangle[] AnimationFrames
        {
            get { return animationSrcs; }
        }
        private int framesCount;
        public int FrameCount
        {
            get { return framesCount; }
        }
        
        
        
        
        public SpriteContent(Texture2D texture)
        {
            this.texture = texture;
        }
        public SpriteContent(Texture2D texture, Rectangle gridSize, int frames, int gridWidth, int gridHeight) : this(texture)
        {
            this.texture = texture;
            this.framesCount = frames;
            this.spriteType = SpriteType.GridSpriteSheet;
            
            
            initializeGridSpriteRects(gridSize, frames, gridWidth, gridHeight);
        }
        //goes horizontally
        private void initializeGridSpriteRects(Rectangle cellSize, int frameCount, int gridWidth, int gridHeight)
        {
            animationSrcs = new Rectangle[frameCount];
            int i = 0;
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (i >= framesCount)
                    {
                        break;
                    }
                    animationSrcs[i] = new Rectangle(cellSize.Width * x, cellSize.Height * y, cellSize.Width, cellSize.Height);
                    i++;
                }
            }
        }
        
        public int Width
        {
            get { return texture.Width; }
        }
        public int Height
        {
            get { return texture.Height; }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Rectangle destRect)
        {
            Rectangle sourceRect = new Rectangle(0, 0, texture.Width, texture.Height); ;
            if (spriteType == SpriteType.SimpleTexture)
            {
                sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            }
            

            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }
    }
}
