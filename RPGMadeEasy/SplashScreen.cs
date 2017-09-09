using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPGMadeEasy
{
    public class SplashScreen : GameScreen
    {
        public Image Image;
        //Texture2D image; //first load constructer, then place values and then you can call everything else
        //[XmlElement("Path")] // with the list you have to name xml element
        //public List<string> path;
        //public string Path;
        //[XmlIgnore] //if I don't wanna serialize Content
        //public ContentManager Content;
        //public Vector2 Position;

        public override void LoadContent()
        {
            base.LoadContent();
            Image.LoadContent();
            Image.FadeEffect.FadeSpeed = 0.5f; // edit in xml
            //image = Content.Load<Texture2D>(Path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.Enter, Keys.Z))
                ScreenManager.Instance.ChangeScreens("TitleScreen");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //spriteBatch.Draw(image, Position, Color.White);
            Image.Draw(spriteBatch);
        }
    }
}
