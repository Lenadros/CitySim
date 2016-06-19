using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CitySim
{
    class UIElement
    {
        public Game1 aaGame;
        public AssetLoader aaAssetLoader;

        public float mDepth = 0;

        public UIElement(Game1 pGame)
        {
            aaGame = pGame;
            aaAssetLoader = aaGame.aaDisplay.aaAssetLoader;
            aaGame.aaDisplay.AddToUIList(this);
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

        public void Destroy()
        {
            aaGame.aaDisplay.mUIList.Remove(this);
        }
    }

    class UIElement_InfoBoxBlock : UIElement
    {
        public AssetKit mAssetKit;
        public Vector2 mPosition;

        public UIElement_InfoBoxBlock(Game1 pGame, Vector2 pPosition, float pDepth)
            : base(pGame)
        {
            mPosition = pPosition;
            mAssetKit = new AssetKit_UI_InfoBoxBlock();
            mDepth = pDepth;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aaAssetLoader.GetAsset(mAssetKit.ASSET_NAME), mPosition, mAssetKit.SRC_RECTANGLE, Color.White, 0.0f, mAssetKit.ORIGIN, 2.0f, SpriteEffects.None, Constants.UI_DEPTH + mDepth);
        }
    }

    class UIElement_InfoBoxBuilding : UIElement
    {
        public AssetKit mAssetKit;
        public Vector2 mPosition;
        public bool isActive;

        public UIElement_InfoBoxBuilding(Game1 pGame, Vector2 pPosition, float pDepth)
            : base(pGame)
        {
            mPosition = pPosition;
            mAssetKit = new AssetKit_UI_InfoBoxBuilding();
            mDepth = pDepth;
            isActive = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(isActive)
                spriteBatch.Draw(aaAssetLoader.GetAsset(mAssetKit.ASSET_NAME), mPosition, mAssetKit.SRC_RECTANGLE, Color.White, 0.0f, mAssetKit.ORIGIN, 2.0f, SpriteEffects.None, Constants.UI_DEPTH + mDepth);
        }
    }

    class UIElement_BaseBuildPanel : UIElement
    {
        public AssetKit mAssetKit;
        public Vector2 mPosition;

        public UIElement_BaseBuildPanel(Game1 pGame, Vector2 pPosition)
            : base(pGame)
        {
            mPosition = pPosition;
            mAssetKit = new AssetKit_UI_BaseBuildPanel();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aaAssetLoader.GetAsset(mAssetKit.ASSET_NAME), mPosition, mAssetKit.SRC_RECTANGLE, Color.White, 0.0f, mAssetKit.ORIGIN, 2.0f, SpriteEffects.None, Constants.UI_DEPTH + 0.01f);
        }
    }

    class UIElement_BuildPanel : UIElement
    {
        public AssetKit mAssetKit;
        public Vector2 mPosition;

        public UIElement_BuildPanel(Game1 pGame, Vector2 pPosition)
            : base(pGame)
        {
            mPosition = pPosition;
            mAssetKit = new AssetKit_UI_BuildPanel();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aaAssetLoader.GetAsset(mAssetKit.ASSET_NAME), mPosition, mAssetKit.SRC_RECTANGLE, Color.White, 0.0f, mAssetKit.ORIGIN, 2.0f, SpriteEffects.None, Constants.UI_DEPTH);
        }
    }

    class UIElement_DataBar : UIElement
    {
        public AssetKit mAssetKit;
        public Vector2 mPosition;

        public UIElement_DataBar(Game1 pGame, Vector2 pPosition) 
            : base(pGame)
        {
            mPosition = pPosition;
            mAssetKit = new AssetKit_UI_DataBar();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aaAssetLoader.GetAsset(mAssetKit.ASSET_NAME), mPosition, mAssetKit.SRC_RECTANGLE, Color.White, 0.0f, mAssetKit.ORIGIN, 2.0f, SpriteEffects.None, Constants.UI_DEPTH);
        }
    }

    class UIElement_Alert : UIElement
    {
        public AssetKit mAssetKit;
        public Vector2 mPosition;

        public UIElement_Alert(Game1 pGame, Vector2 pPosition, AssetKit pAssetKit)
            : base(pGame)
        {
            mPosition = pPosition;
            mAssetKit = pAssetKit;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aaAssetLoader.GetAsset(mAssetKit.ASSET_NAME), mPosition, mAssetKit.SRC_RECTANGLE, Color.White, 0.0f, mAssetKit.ORIGIN, 2.0f, SpriteEffects.None, Constants.UI_DEPTH);
        }
    }

    class UIElement_Icon : UIElement
    {
        public AssetKit mAssetKit;
        public Vector2 mPosition;

        public float mSize;
        public bool isVisible;

        public UIElement_Icon(Game1 pGame, Vector2 pPosition, AssetKit pAssetKit, float pSize, bool isVisibleAtStart)
            : base(pGame)
        {
            mPosition = pPosition;
            mAssetKit = pAssetKit;
            isVisible = isVisibleAtStart;
            mSize = pSize;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(isVisible && mAssetKit != null)
                spriteBatch.Draw(aaAssetLoader.GetAsset(mAssetKit.ASSET_NAME), mPosition, mAssetKit.SRC_RECTANGLE, Color.White, 0.0f, mAssetKit.ORIGIN, mSize, SpriteEffects.None, Constants.UI_DEPTH + 0.03f);
        }
    }

    class UIElement_Text : UIElement
    {
        public SpriteFont mFont;
        public Vector2 mPosition;
        public Color mColor;
        public string mText;

        public UIElement_Text(Game1 pGame, Vector2 pPosition, Color pColor)
            : base(pGame)
        {
            mText = "";
            mColor = pColor;
            mFont = aaAssetLoader.mFont;
            mPosition = pPosition;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(mFont, mText, mPosition, mColor, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, Constants.UI_DEPTH + 0.09f);
        }
    }

    class UIElement_Button : UIElement
    {
        public AssetKit mAssetKit;
        public Vector2 mPosition;
        public Rectangle mRectangle;
        public bool isActive;
        public string mType;

        public UIElement_Button(Game1 pGame, Vector2 pPosition, AssetKit pAssetKit, string pType, float pDepth = 0, int pRectWidth = -1, int pRectHeight = -1)
            : base(pGame)
        {
            mPosition = pPosition;
            mAssetKit = pAssetKit;
            mType = pType;
            mDepth = pDepth;
            isActive = false;

            if (pRectWidth == -1 && pRectHeight == -1)
                mRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, pAssetKit.SRC_RECTANGLE.Width * 2, pAssetKit.SRC_RECTANGLE.Height * 2);
            else
                mRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, pRectWidth, pRectHeight);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(mAssetKit != null)
                spriteBatch.Draw(aaAssetLoader.GetAsset(mAssetKit.ASSET_NAME), mPosition, mAssetKit.SRC_RECTANGLE, Color.White, 0.0f, mAssetKit.ORIGIN, 2.0f, SpriteEffects.None, mDepth);
        }
    }
}
