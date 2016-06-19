using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CitySim
{
    class UI_InfoBox
    {
        public Game1 aaGame;
        public Block mTargetBlock;
        public Block mPrevTargetBlock;
        public Building mTargetBuilding;
        public Building mPrevTargetBuilding;

        public Vector2 mPosition;
        public Vector2 mGridPos;

        public bool onBlockInfo;

        public UIElement_InfoBoxBlock mUI_BlockInfo;
        public UIElement_InfoBoxBuilding mUI_BuildingInfo;

        public UIElement_Button mUI_BlockButton;
        public UIElement_Button mUI_BuildingButton;

        public UIElement_Icon mUI_RowOneIcon;
        public UIElement_Icon mUI_RowTwoIcon;
        public UIElement_Icon mUI_RowThreeIcon;
        public UIElement_Icon mUI_RowFourIcon;

        public AssetKit_UI_MineralIcon mMineralIcon;
        public AssetKit_UI_FertileIcon mFertileIcon;
        public AssetKit_UI_WaterIcon mWaterIcon;
        public AssetKit_UI_OnIcon mOnIcon;
        public AssetKit_UI_WorkerIcon mWorkerIcon;

        public UIElement_Text mTitleText;
        public UIElement_Text mRowOneText;
        public UIElement_Text mRowTwoText;
        public UIElement_Text mRowThreeText;
        public UIElement_Text mRowFourText;

        public UI_InfoBox(Game1 pGame, float pPosX, float pPosY)
        {
            aaGame = pGame;
            mTargetBlock = null;
            mPosition = new Vector2(pPosX, pPosY);
            onBlockInfo = true;

            //Info box textures
            mUI_BlockInfo = new UIElement_InfoBoxBlock(aaGame, mPosition, 0.02f);
            mUI_BuildingInfo = new UIElement_InfoBoxBuilding(aaGame, mPosition, 0.01f);

            //Info box text lines
            mTitleText = new UIElement_Text(aaGame, mPosition + new Vector2(55, 8), Color.Black);
            mRowOneText = new UIElement_Text(aaGame, mPosition + new Vector2(95, 50), Color.White);
            mRowTwoText = new UIElement_Text(aaGame, mPosition + new Vector2(95, 85), Color.White);
            mRowThreeText = new UIElement_Text(aaGame, mPosition + new Vector2(95, 120), Color.White);
            mRowFourText = new UIElement_Text(aaGame, mPosition + new Vector2(95, 155), Color.White);

            //Info box icons
            mUI_RowOneIcon = new UIElement_Icon(aaGame, mPosition + new Vector2(55, 45), null, 2.0f, true);
            mUI_RowTwoIcon = new UIElement_Icon(aaGame, mPosition + new Vector2(55, 80), null, 2.0f, true);
            mUI_RowThreeIcon = new UIElement_Icon(aaGame, mPosition + new Vector2(55, 115), null, 2.0f, true);
            mUI_RowFourIcon = new UIElement_Icon(aaGame, mPosition + new Vector2(55, 150), null, 2.0f, true);

            //Icon asset kits
            mMineralIcon = new AssetKit_UI_MineralIcon();
            mFertileIcon = new AssetKit_UI_FertileIcon();
            mWaterIcon = new AssetKit_UI_WaterIcon();
            mOnIcon = new AssetKit_UI_OnIcon();
            mWorkerIcon = new AssetKit_UI_WorkerIcon();

            //Info box buttons
            mUI_BlockButton = new UIElement_Button(aaGame, mPosition, null, null, 0, 40, 38);
            mUI_BuildingButton = new UIElement_Button(aaGame, mPosition + new Vector2(0, 38), null, null, 0, 40, 38);
            mUI_BlockButton.isActive = true;
        }

        public void Update()
        {
            if (aaGame.aaInput.LeftBtnPress())
            {
                if (mUI_BlockButton.isActive && mUI_BlockButton.mRectangle.Contains(aaGame.aaInput.GetCursorPosition()))
                {   //Disable cursor and display block data
                    aaGame.aaDisplay.aaCursor.isEnabled = false;
                    onBlockInfo = true;
                    mUI_BlockInfo.mDepth = 0.02f;
                    mUI_BuildingInfo.mDepth = 0.01f;
                }
                else if (mUI_BuildingButton.isActive && mUI_BuildingButton.mRectangle.Contains(aaGame.aaInput.GetCursorPosition()))
                {   //Disable cursor and display building data
                    aaGame.aaDisplay.aaCursor.isEnabled = false;
                    onBlockInfo = false;
                    mUI_BlockInfo.mDepth = 0.01f;
                    mUI_BuildingInfo.mDepth = 0.02f;
                }
                else
                {   //Get target block information
                    mPrevTargetBuilding = mTargetBuilding;
                    mPrevTargetBlock = mTargetBlock;
                    mGridPos = aaGame.aaGameWorld.aaWorldMap.ScreenToGrid(aaGame.aaInput.mMouseState.X, aaGame.aaInput.mMouseState.Y);
                    mTargetBlock = aaGame.aaGameWorld.aaWorldMap.GetBlock(mGridPos);
                    mTargetBuilding = aaGame.aaGameWorld.aaWorldMap.GetBuilding(mGridPos);

                    //Check if target block has building and activate info panels accordingly
                    if (mTargetBlock != null && mTargetBlock.isOccupied)
                    {
                        mUI_BuildingInfo.isActive = true;
                        mUI_BuildingButton.isActive = true;
                    }
                    else if(mTargetBlock != null)
                    {
                        mUI_BuildingInfo.isActive = false;
                        mUI_BuildingButton.isActive = false;
                        onBlockInfo = true;
                    }
                }

                //Clicking out of bounds catch
                if (mTargetBlock == null)
                {
                    mTargetBlock = mPrevTargetBlock;
                    mTargetBuilding = mPrevTargetBuilding;
                }
            }

            //Display block information
            if (onBlockInfo && mTargetBlock != null)
            {
                ClearInfoBox();
                DisplayBlockData();
            }
            else if (!onBlockInfo && mTargetBlock != null)
            {
                ClearInfoBox();
                DisplayBuildingData();
            }
        }

        public void ClearInfoBox()
        {
            mUI_RowOneIcon.mAssetKit = null;
            mUI_RowTwoIcon.mAssetKit = null;
            mUI_RowThreeIcon.mAssetKit = null;
            mUI_RowFourIcon.mAssetKit = null;
            mRowOneText.mText = "";
            mRowTwoText.mText = "";
            mRowThreeText.mText = "";
            mRowFourText.mText = "";
            mRowOneText.mColor = Color.White;
            mRowTwoText.mColor = Color.White;
            mRowThreeText.mColor = Color.White;
            mRowFourText.mColor = Color.White;
        }

        public void DisplayBlockData()
        {
            mTitleText.mText = mTargetBlock.mName;

            if (mTargetBlock.mType == "GRASS")
            {
                mUI_RowOneIcon.mAssetKit = mMineralIcon;
                mUI_RowTwoIcon.mAssetKit = mFertileIcon;
                mUI_RowThreeIcon.mAssetKit = mWaterIcon;
                mRowOneText.mText = mTargetBlock.mMineralAmt.ToString();
                mRowTwoText.mText = mTargetBlock.mFertileAmt.ToString() + "%";
                mRowThreeText.mText = mTargetBlock.mWaterAmt.ToString();
            }
            else if (mTargetBlock.mType == "WATER")
            {
                mUI_RowOneIcon.mAssetKit = mMineralIcon;
                mUI_RowTwoIcon.mAssetKit = mWaterIcon;
                mRowOneText.mText = mTargetBlock.mMineralAmt.ToString();
                mRowTwoText.mText = mTargetBlock.mWaterAmt.ToString();
            }
        }

        public void DisplayBuildingData()
        {
            mTitleText.mText = mTargetBuilding.mName;
            mTargetBuilding.GetInformation(this);
        }
    }
}
