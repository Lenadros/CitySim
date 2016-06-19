using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitySim
{
    class Building
    {
        public float mPosX;
        public float mPosY;
        public string mName;
        public bool isEnabled;

        public Game1 aaGame;

        public AssetKit mAssetKit;
        public DisplayObject mDispObj;
        public Block mBlock;

        public Building(Game1 pGame, Block pBlock)
        {
            aaGame = pGame;
            mBlock = pBlock;
            mPosX = mBlock.mPosX;
            mPosY = mBlock.mPosY - 16;
            isEnabled = false;
        }

        public virtual void Update()
        {
        }

        public void CreateDisplayObject()
        {
            mDispObj = new DisplayObject(aaGame.aaDisplay, mAssetKit.ASSET_NAME, mPosX, mPosY, mAssetKit.SRC_RECTANGLE, mAssetKit.ORIGIN, mBlock.mDispObj.mDepth + 0.1f);
        }

        public virtual void GetInformation(UI_InfoBox pInfo)
        {
        }
    }

    class Warehouse : Building
    {
        public int mTotalPower;
        public int mMineral;
        public int mFood;
        public int mLeftOver;

        public Warehouse(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
            mName = "Warehouse";
            mMineral = 0;
            mFood = 0;
            mTotalPower = 100;

            mAssetKit = new AssetKit_Warehouse();
            CreateDisplayObject();
            aaGame.aaGameWorld.mWarehouse = this;
            isEnabled = false;
            aaGame.aaGameWorld.mAlerts.AddAlert("GREEN", "New Building Options");
        }

        public int RequestMinerals(int pShipment)
        {
            if (pShipment <= mMineral)
            {
                mMineral -= pShipment;
                return pShipment;
            }
            else if (pShipment > mMineral)
            {
                return 0;
            }
            return 0;
        }

        public bool UsePower(int pPower)
        {
            if (pPower > mTotalPower)
                return false;
            else
                return true;
        }
    }
}
