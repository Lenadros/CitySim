using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CitySim
{
    class Display
    {
        public Game1 aaGame;
        public AssetLoader aaAssetLoader;
        public Camera aaCamera;
        public Cursor aaCursor;

        public List<DisplayObject> mDisplayList;
        public List<UIElement> mUIList;

        public Display(Game1 pGame)
        {
            aaGame = pGame;
            aaAssetLoader = new AssetLoader(aaGame.Content);
            mDisplayList = new List<DisplayObject>();
            mUIList = new List<UIElement>();
            aaCamera = new Camera(this,0,32);
        }

        public void CreateUIElements()
        {
            aaCursor = new Cursor(aaGame, this, aaGame.aaInput, aaGame.aaGameWorld.aaWorldMap);
        }

        public void AddToDisplayList(DisplayObject pDisplayObject)
        {
            mDisplayList.Add(pDisplayObject);
        }

        public void RemoveFromDisplayList(DisplayObject pDisplayObject)
        {
            mDisplayList.Remove(pDisplayObject);
        }

        public void AddToUIList(UIElement pUIElement)
        {
            mUIList.Add(pUIElement);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, null, null, null, aaCamera.GetTransform());

            foreach (DisplayObject d in mDisplayList)
            {
                spriteBatch.Draw(aaAssetLoader.GetAsset(d.mAssetName), d.mPosition, d.mSrcRectangle, Color.White, 0, new Vector2(0,0), 1, SpriteEffects.None, d.mDepth);
            }

            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(1));
            foreach (UIElement u in mUIList)
            {
                u.Draw(spriteBatch);
            }

            //aaCursor.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
