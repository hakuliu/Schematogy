using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Schematogy.UI;
using Microsoft.Xna.Framework;

namespace Schematogy.Util.Factories
{
    class ButtonFactory
    {
        public static void initAllResources(ContentManager Content, Dictionary<string, SpriteContent> spriteCache)
        {
            spriteCache.Add("ResistorButtonIdle", new SpriteContent(Content.Load<Texture2D>("Buttons/Button Resistor regular")));
            spriteCache.Add("ResistorButtonHover", new SpriteContent(Content.Load<Texture2D>("Buttons/Button Resistor hover")));
            spriteCache.Add("ResistorButtonPressed", new SpriteContent(Content.Load<Texture2D>("Buttons/Button Resistor clicked")));
            spriteCache.Add("ResistorButtonDisabled", new SpriteContent(Content.Load<Texture2D>("Buttons/Button Resistor disabled")));


        }
        public static Button getResistorButton(Rectangle initialLocation)
        {
            Button result = new Button();
            result.IdleTexture = "ResistorButtonIdle";
            result.HoverTexture = "ResisteoButtonHover";
            result.PressedTexture = "ResistorButtonPressed";
            result.DisabledTexture = "ResistorButtonDisabled";
            result.HoverEnabled = true;
            result.PressDownEnabled = true;
            result.Enabled = true;
            result.Bound = initialLocation;
            

            return result;
        }
    }
}
