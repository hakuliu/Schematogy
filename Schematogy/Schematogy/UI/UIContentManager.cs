using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Schematogy.Util;
using Microsoft.Xna.Framework;

namespace Schematogy.UI
{
    /// <summary>
    /// This is a singleton class that holds all the resources that UI might use.
    /// </summary>
    class UIContentManager : Util.IsAContentManager
    {
        private static UIContentManager instance;
        public static UIContentManager getInstance()
        {
            if (instance == null)
            {
                instance = new UIContentManager();
            }
            return instance;
        }
        public UIContentManager()
        {
            spriteCache = new Dictionary<string, SpriteContent>();
        }

        public Dictionary<String, SpriteContent> spriteCache;

        #region UsesContentManger Members

        public void LoadContents(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            spriteCache.Add("rawr", new SpriteContent(Content.Load<Texture2D>("UI/Mouse_Farewell_by_nJoo")));
            spriteCache.Add("mouse", new SpriteContent(Content.Load<Texture2D>("UI/Cursor mouse")));


            spriteCache.Add("CornerChunkUpperLeft", new SpriteContent(Content.Load<Texture2D>("UI/Corner Chunk up right")));
            spriteCache.Add("CornerChunkUpperRight", new SpriteContent(Content.Load<Texture2D>("UI/Corner Chunk upper right")));
            spriteCache.Add("CornerChunkLowerLeft", new SpriteContent(Content.Load<Texture2D>("UI/Corner Chunk lower left4")));
            spriteCache.Add("CornerChunkLowerRight", new SpriteContent(Content.Load<Texture2D>("UI/Corner Chunk lower right")));

            spriteCache.Add("BorderChunkBottom", new SpriteContent(Content.Load<Texture2D>("UI/Border Chunk bottom")));
            spriteCache.Add("BorderChunkLeft", new SpriteContent(Content.Load<Texture2D>("UI/Border Chunk Left")));
            spriteCache.Add("BorderChunkRight", new SpriteContent(Content.Load<Texture2D>("UI/Border Chunk Right")));
            spriteCache.Add("BorderChunkTop", new SpriteContent(Content.Load<Texture2D>("UI/Border Chunk top")));

            spriteCache.Add("BigChunk", new SpriteContent(Content.Load<Texture2D>("UI/BIG CHUNK")));

            spriteCache.Add("MissingImageButton", new SpriteContent(Content.Load<Texture2D>("UI/NO BUTTON PAUL")));


            spriteCache.Add("GridIdle", new SpriteContent(Content.Load<Texture2D>("grid")));

            Util.Factories.ButtonFactory.initAllResources(Content, spriteCache);
        }

        public void UnloadContents(Microsoft.Xna.Framework.Content.ContentManager Content)
        {

        }



        #endregion

        public SpriteContent getTexture(String key)
        {
            return spriteCache[key];
        }
    }
}
