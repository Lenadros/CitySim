using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitySim
{
    class Block
    {
        public Game1 aaGame;
        public Display aaDisplay;
        public DisplayObject mDispObj;
        public AssetKit mAssetKit;

        public int mFertileAmt = -1;
        public int mMineralAmt = -1;
        public int mWaterAmt = -1;
        public int mResourceAmt;

        public string mType;
        public string mName;

        public float mPosX;
        public float mPosY;

        public bool isOccupied;

        public Block(Game1 pGame, string pBlockType, float pPosX, float pPosY)
        {
            aaGame = pGame;
            aaDisplay = aaGame.aaDisplay;
            mPosX = pPosX;
            mPosY = pPosY;
            mType = pBlockType;
            isOccupied = false;
            SetType(mType);

            mDispObj = new DisplayObject(aaDisplay, mAssetKit.ASSET_NAME, mPosX, mPosY, mAssetKit.SRC_RECTANGLE, mAssetKit.ORIGIN, mPosY/10000);
        }

        public void SetType(string pType)
        {
            if (pType == "GRASS")
            {
                mAssetKit = new AssetKit_Block_Grass();
                mName = "Grass Field";
                mFertileAmt = aaGame.mRandom.Next(50, 100);
                mMineralAmt = aaGame.mRandom.Next(100, 1000);
                mWaterAmt = aaGame.mRandom.Next(0, 60);
            }
            else if (pType == "WATER")
            {
                mAssetKit = new AssetKit_Block_Water();
                mName = "Lake";
                mMineralAmt = aaGame.mRandom.Next(50000, 100000);
                mWaterAmt = aaGame.mRandom.Next(80,100);
            }
            else if (pType == "EMPTY")
            {
                mAssetKit = new AssetKit_Empty();
                mName = "";
            }
        }

        public void Destroy()
        {
            aaDisplay.RemoveFromDisplayList(mDispObj);
        }

        public int MineMinerals(int pAmt)
        {
            if(mMineralAmt == 0)
            {
                return 0;
            }
            else if (pAmt <= mMineralAmt)
            {
                mMineralAmt -= pAmt;
                return pAmt;
            }
            else if (pAmt > mMineralAmt)
            {
                mResourceAmt = mMineralAmt;
                mMineralAmt = 0;
                return mResourceAmt;
            }
            return 0;
        }

        /*
        public bool TakeWater(int pAmt)
        {
        }*/
    }
}
