using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPGMadeEasy
{
    public class Layer // different layers within that map
    {
        public class TileMap // the reason to create a class inside a class is we don't want to access TileMap from other classes
        {
            [XmlElement("Row")]
            public List<string> Row; // so if we want to call tilemap we have to call layer

            public TileMap()
            {
                Row = new List<string>();
            }
        }

        [XmlElement("TileMap")]
        public TileMap Tile;
        public Image Image;
        List<Tile> tiles;

        public Layer()
        {
            Image = new Image(); // initialized MY ASS
            tiles = new List<Tile>();

        }

        public void LoadContent(Vector2 tileDimensions)
        {
            Image.LoadContent();
            Vector2 position = -tileDimensions;

            foreach (string row in Tile.Row)
            {
                string[] split = row.Split(']');
                position.X = -tileDimensions.X;
                position.Y += tileDimensions.Y;
                foreach (string s in split)
                {
                    if (s != String.Empty)
                    {
                        position.X += tileDimensions.X; // specify position of our tile
                        tiles.Add(new Tile()); // yay we've got a brand new tile

                        string str = s.Replace("[", String.Empty);
                        int value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        int value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));

                        tiles[tiles.Count - 1].LoadContent(position, new Rectangle( // we stored the position of the current tile
                            value1 * (int)tileDimensions.X, value2 * (int)tileDimensions.Y, // and the sourcerect
                            (int)tileDimensions.X, (int)tileDimensions.Y)); 
                    }
                }
            }
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
            {
                Image.Position = tile.Position; // set the position! and sourcerect! and dRAW!
                Image.SourceRect = tile.SourceRect;
                Image.Draw(spriteBatch);
            }
        }
    }
}
