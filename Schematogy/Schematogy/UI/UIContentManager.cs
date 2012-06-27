using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

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
            textureCache = new Dictionary<string, Texture2D>();
        }

        Dictionary<String, Texture2D> textureCache;

        #region UsesContentManger Members

        public void LoadContents(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            textureCache.Add("rawr", Content.Load<Texture2D>("Mouse_Farewell_by_nJoo"));

            textureCache.Add("ResistorButtonIdle", Content.Load<Texture2D>("Button Resistor regular"));
            textureCache.Add("ResistorButtonHover", Content.Load<Texture2D>("Button Resistor hover over on"));
            textureCache.Add("ResistorButtonPressed", Content.Load<Texture2D>("Button Resistor clicked on"));


        }

        public void UnloadContents(Microsoft.Xna.Framework.Content.ContentManager Content)
        {

        }



        #endregion

        public Texture2D getTexture(String key)
        {
            return textureCache[key];
        }
    }
}
