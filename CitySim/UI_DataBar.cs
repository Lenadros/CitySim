using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CitySim
{
    class UI_DataBar
    {
        public Game1 aaGame;
        public Vector2 mPosition;
        
        public UIElement_DataBar mDataBar;
        public UIElement_Icon Mineral_Icon;
        public UIElement_Icon Power_Icon;
        public UIElement_Icon Money_Icon;
        public UIElement_Text Mineral_Amt;
        public UIElement_Text Power_Amt;
        public UIElement_Text Food_Amt;
        public UIElement_Text Money_Amt;

        public UI_DataBar(Game1 pGame, float pPosX, float pPosY)
        {
            aaGame = pGame;
            mPosition = new Vector2(pPosX, pPosY);
            mDataBar = new UIElement_DataBar(aaGame, mPosition);
            InitializeDataBar();
        }

        public void InitializeDataBar()
        {
            Mineral_Icon = new UIElement_Icon(aaGame, mPosition + new Vector2(110, 0), new AssetKit_UI_MineralIcon(), 2.0f, true);
            Power_Icon = new UIElement_Icon(aaGame, mPosition + new Vector2(230, 0), new AssetKit_UI_PowerIcon(), 2.0f, true);
            Money_Icon = new UIElement_Icon(aaGame, mPosition + new Vector2(0, 0), new AssetKit_UI_MoneyIcon(), 2.0f, true);

            Money_Amt = new UIElement_Text(aaGame, mPosition + new Vector2(30, 4), Color.White);
            Mineral_Amt = new UIElement_Text(aaGame, mPosition + new Vector2(140, 4), Color.White);
            Power_Amt = new UIElement_Text(aaGame, mPosition + new Vector2(260, 4), Color.White);
            Food_Amt = new UIElement_Text(aaGame, mPosition + new Vector2(500, 4), Color.White);

            Mineral_Amt.mText = "0";
            Power_Amt.mText = "0";
            Food_Amt.mText = "0";
        }

        public void Update()
        {
            Money_Amt.mText = aaGame.aaGameWorld.mMoney.ToString();

            if (aaGame.aaGameWorld.mWarehouse != null)
            {
                Mineral_Amt.mText = aaGame.aaGameWorld.mWarehouse.mMineral.ToString();
                Power_Amt.mText = aaGame.aaGameWorld.mWarehouse.mTotalPower.ToString();
                Food_Amt.mText = aaGame.aaGameWorld.mWarehouse.mFood.ToString();

                if (aaGame.aaGameWorld.mWarehouse.mTotalPower <= 0)
                    Power_Amt.mColor = Color.Red;
                else
                    Power_Amt.mColor = Color.White;
            }

            if (aaGame.aaGameWorld.mMoney <= 0)
                Money_Amt.mColor = Color.Red;
            else
                Money_Amt.mColor = Color.White;
        }
    }
}
