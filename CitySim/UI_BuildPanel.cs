using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CitySim
{
    class UI_BuildPanel
    {
        public Game1 aaGame;

        public Vector2 mPosition;

        public int index;
        public bool BuildisAcitve;

        public List<UIElement_Button> mBaseButtonList;
        public List<UIElement_Button> mBuildButtonList;

        public UIElement_BaseBuildPanel BaseBuildPanel;
        public UIElement_BuildPanel BuildPanel;
        public UIElement_Button MiningBtn;
        public UIElement_Button AutoMiningBtn;
        public UIElement_Button BasicMineBtn;
        public UIElement_Button MineralPowerBtn;
        public UIElement_Button WarehouseBtn;
        public UIElement_Button BackBtn;
        public UIElement_Button PowerBtn;
        public UIElement_Button FoodBtn;
        public UIElement_Button BasicFarmBtn;
        public UIElement_Button ShippingBtn;
        public UIElement_Button HomeBtn;

        public UI_BuildPanel(Game1 pGame, float pPosX, float pPosY)
        {
            aaGame = pGame;
            mPosition = new Vector2(pPosX, pPosY);
            mBaseButtonList = new List<UIElement_Button>();
            mBuildButtonList = new List<UIElement_Button>();
            BaseBuildPanel = new UIElement_BaseBuildPanel(aaGame, mPosition);
            BuildPanel = new UIElement_BuildPanel(aaGame, mPosition - new Vector2(50, 0));
            BuildisAcitve = false;
            CreateButtonList();

        }

        public void CreateButtonList()
        {
            WarehouseBtn = new UIElement_Button(aaGame, mPosition + new Vector2(5, 25), new AssetKit_UI_WarehouseButton(), "WAREHOUSE", Constants.UI_DEPTH + 0.02f);
            MiningBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 80), new AssetKit_UI_MiningButton(), "MINING", Constants.UI_DEPTH + 0.02f);
            PowerBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 135), new AssetKit_UI_PowerButton(), "POWER", Constants.UI_DEPTH + 0.02f);
            FoodBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 190), new AssetKit_UI_FoodButton(), "FOOD", Constants.UI_DEPTH + 0.02f);
            mBaseButtonList.Add(WarehouseBtn);
            mBaseButtonList.Add(MiningBtn);
            mBaseButtonList.Add(PowerBtn);
            mBaseButtonList.Add(FoodBtn);
            BasicMineBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 0), new AssetKit_UI_BMineButton(), "BASIC_MINE", Constants.UI_DEPTH + 0.001f);
            MineralPowerBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 0), new AssetKit_UI_MineralPowerButton(), "POWER_MINERAL", Constants.UI_DEPTH + 0.001f);
            BasicFarmBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 0), new AssetKit_UI_BasicFarmButton(), "BASIC_FARM", Constants.UI_DEPTH + 0.001f);
            BackBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 0), new AssetKit_UI_BackButton(), "BACK", Constants.UI_DEPTH + 0.001f);
            ShippingBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 0), new AssetKit_UI_ShipmentButton(), "SHIPPING", Constants.UI_DEPTH + 0.001f);
            HomeBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 0), new AssetKit_UI_HomeButton(), "HOME", Constants.UI_DEPTH + 0.001f);
            AutoMiningBtn = new UIElement_Button(aaGame, mPosition + new Vector2(-50, 0), new AssetKit_UI_AutoMineButton(), "AUTOMINE", Constants.UI_DEPTH + 0.001f);

            WarehouseBtn.isActive = true;
        }

        public void Update()
        {
            foreach (UIElement_Button b in mBaseButtonList)
            {
                if (aaGame.aaInput.LeftBtnPress())
                {
                    if (b.isActive && b.mRectangle.Contains(aaGame.aaInput.mMouseState.X, aaGame.aaInput.mMouseState.Y))
                    {
                        ResetButtons();
                        mBuildButtonList.Clear();

                        BuildisAcitve = true;
                        if (b.mType == "MINING")
                        {
                            mBuildButtonList.Add(AutoMiningBtn);
                            mBuildButtonList.Add(BasicMineBtn);
                            mBuildButtonList.Add(ShippingBtn);
                        }
                        else if (b.mType == "WAREHOUSE")
                        {
                            aaGame.aaDisplay.aaCursor.mType = b.mType;
                            BuildisAcitve = false;
                        }
                        else if (b.mType == "POWER")
                        {
                            mBuildButtonList.Add(MineralPowerBtn);
                        }
                        else if (b.mType == "FOOD")
                        {
                            mBuildButtonList.Add(BasicFarmBtn);
                            mBuildButtonList.Add(HomeBtn);
                        }
                        mBuildButtonList.Add(BackBtn);
                        SetButtonPositions();
                    }
                }

                if (b.isActive)
                {
                    b.mPosition.X = MathHelper.Lerp(b.mPosition.X, 5.0f, 0.15f);
                }
            }

            if (BuildisAcitve)
            {
                BuildPanel.mPosition.X = MathHelper.Lerp(BuildPanel.mPosition.X, 70, 0.2f);
                foreach (UIElement_Button b in mBuildButtonList)
                {
                    b.mPosition.X = MathHelper.Lerp(b.mPosition.X, 65, 0.2f);

                    if (aaGame.aaInput.LeftBtnPress())
                    {
                        if (b.isActive && b.mRectangle.Contains(aaGame.aaInput.mMouseState.X, aaGame.aaInput.mMouseState.Y))
                        {
                            if (b.mType == "BACK")
                                BuildisAcitve = false;
                            else
                                aaGame.aaDisplay.aaCursor.mType = b.mType;
                        }
                    }
                }
            }
            else
            {
                BuildPanel.mPosition.X = MathHelper.Lerp(BuildPanel.mPosition.X, -50, 0.2f);
                foreach (UIElement_Button b in mBuildButtonList)
                {
                    b.mPosition.X = MathHelper.Lerp(b.mPosition.X, -50, 0.2f);
                }
            }

            if (aaGame.aaGameWorld.mWarehouse != null)
            {
                foreach (UIElement_Button b in mBaseButtonList)
                {
                    b.isActive = true;
                    b.mRectangle.X = 5;
                }
            }
        }

        public void SetButtonPositions()
        {
            index = 0;
            foreach (UIElement_Button b in mBuildButtonList)
            {
                b.mPosition.Y = mPosition.Y + 25 + 55 * index;
                b.mRectangle.Y = (int)mPosition.Y + 25 + 55 * index;
                b.mRectangle.X = 65;
                b.isActive = true;
                index++;
            }
        }

        public void ResetButtons()
        {
            foreach (UIElement_Button bb in mBuildButtonList)
            {
                bb.mPosition.X = -50;
                bb.isActive = false;
                BuildPanel.mPosition.X = -50;
            }
        }
    }
}
