using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CitySim
{
    class Cursor
    {
        public Display aaDisplay;
        public Input aaInput;
        public WorldMap aaWorldMap;
        public Block mTargetBlock;
        public Game1 aaGame;

        public Vector2 mPosition;
        public Vector2 mGridPos;

        public string mType;

        public bool isEnabled;

        public Cursor(Game1 pGame, Display pDisplay, Input pInput, WorldMap pWorldMap)
        {
            aaGame = pGame;
            mPosition = Vector2.Zero;
            aaWorldMap = pWorldMap;
            aaDisplay = pDisplay;
            aaInput = pInput;
            mType = "EMPTY";
            isEnabled = true;
        }

        public void Update()
        {
            mPosition.X = aaInput.GetMouseState().X;
            mPosition.Y = aaInput.GetMouseState().Y;

            if (aaInput.LeftBtnPress() && isEnabled)
            {
                mGridPos = aaWorldMap.ScreenToGrid(mPosition.X, mPosition.Y);
                mTargetBlock = aaWorldMap.GetBlock(mGridPos);
                if (mTargetBlock != null && !mTargetBlock.isOccupied)
                {
                    if (mType == "BASIC_MINE" && aaGame.aaGameWorld.mMoney >= 200)
                    {
                        aaWorldMap.mBuildingData[(int)mGridPos.X, (int)mGridPos.Y] = new Basic_Mine(aaDisplay.aaGame, mTargetBlock);
                        mTargetBlock.isOccupied = true;
                        aaGame.aaGameWorld.mMoney -= 200;
                    }
                    else if (mType == "WAREHOUSE" && aaGame.aaGameWorld.mWarehouse == null && aaGame.aaGameWorld.mMoney >= 500)
                    {
                        aaWorldMap.mBuildingData[(int)mGridPos.X, (int)mGridPos.Y] = new Warehouse(aaDisplay.aaGame, mTargetBlock);
                        mTargetBlock.isOccupied = true;
                        aaGame.aaGameWorld.mMoney -= 500;
                    }
                    else if (mType == "POWER_MINERAL" && aaGame.aaGameWorld.mMoney >= 100)
                    {
                        aaWorldMap.mBuildingData[(int)mGridPos.X, (int)mGridPos.Y] = new Mineral_Power(aaDisplay.aaGame, mTargetBlock);
                        mTargetBlock.isOccupied = true;
                        aaGame.aaGameWorld.mMoney -= 100;
                    }
                    else if (mType == "BASIC_FARM" && aaGame.aaGameWorld.mMoney >= 100)
                    {
                        aaWorldMap.mBuildingData[(int)mGridPos.X, (int)mGridPos.Y] = new Basic_Farm(aaDisplay.aaGame, mTargetBlock);
                        mTargetBlock.isOccupied = true;
                        aaGame.aaGameWorld.mMoney -= 100;
                    }
                    else if (mType == "SHIPPING" && aaGame.aaGameWorld.mMoney >= 100)
                    {
                        aaWorldMap.mBuildingData[(int)mGridPos.X, (int)mGridPos.Y] = new Shipment(aaDisplay.aaGame, mTargetBlock);
                        mTargetBlock.isOccupied = true;
                        aaGame.aaGameWorld.mMoney -= 100;
                    }
                    else if (mType == "HOME" && aaGame.aaGameWorld.mMoney >= 100)
                    {
                        aaWorldMap.mBuildingData[(int)mGridPos.X, (int)mGridPos.Y] = new Residence(aaDisplay.aaGame, mTargetBlock);
                        mTargetBlock.isOccupied = true;
                        aaGame.aaGameWorld.mMoney -= 100;
                    }
                    else if (mType == "AUTOMINE" && aaGame.aaGameWorld.mMoney >= 100)
                    {
                        aaWorldMap.mBuildingData[(int)mGridPos.X, (int)mGridPos.Y] = new AutoMine(aaDisplay.aaGame, mTargetBlock);
                        mTargetBlock.isOccupied = true;
                        aaGame.aaGameWorld.mMoney -= 100;
                    }
                }
            }

            if (aaInput.RightBtnPress())
            {
                mType = "EMPTY";
            }

            isEnabled = true;
        }
    }
}
