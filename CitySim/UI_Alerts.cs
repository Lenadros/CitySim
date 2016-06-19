using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CitySim
{
    class UI_Alerts
    {
        public Game1 aaGame;
        public Vector2 mPosition;

        public UIElement_Alert[] mAlertList;
        public UIElement_Text[] mTextList;
        public float[] mPositionList;
        public int[] mTimeStamp;

        public UI_Alerts(Game1 pGame, float pPosX, float pPosY)
        {
            aaGame = pGame;
            mPosition = new Vector2(pPosX, pPosY);
            mAlertList = new UIElement_Alert[Constants.MAX_ALERTS];
            mTextList = new UIElement_Text[Constants.MAX_ALERTS];
            mPositionList = new float[Constants.MAX_ALERTS];
            mTimeStamp = new int[Constants.MAX_ALERTS];
            CreateSetPositions();
        }

        public void Update()
        {
            for (int i = 0; i < Constants.MAX_ALERTS; i++)
            {
                if (mAlertList[i] != null)
                {
                    mAlertList[i].mPosition.X = MathHelper.Lerp(mAlertList[i].mPosition.X, mPosition.X, 0.1f);
                    mAlertList[i].mPosition.Y = MathHelper.Lerp(mAlertList[i].mPosition.Y, mPositionList[i], 0.1f);
                    mTextList[i].mPosition.X = MathHelper.Lerp(mTextList[i].mPosition.X, mPosition.X + 15, 0.1f);
                    mTextList[i].mPosition.Y = MathHelper.Lerp(mTextList[i].mPosition.Y, mPositionList[i] + 10, 0.1f);
                    mTimeStamp[i]++;
                    if (mTimeStamp[i] > 300)
                    {
                        mAlertList[i].Destroy();
                        mTextList[i].Destroy();
                    }
                }
            }
        }

        public void AddAlert(string pType, string pMessage)
        {
            for (int i = Constants.MAX_ALERTS - 1; i > 0; i--)
            {
                mAlertList[i] = mAlertList[i - 1];
                mTimeStamp[i] = mTimeStamp[i - 1];
                mTextList[i] = mTextList[i - 1];
            }

            if (pType == "RED")
                mAlertList[0] = new UIElement_Alert(aaGame, mPosition - new Vector2(-200, 0), new AssetKit_UI_Alert());
            else if (pType == "GREEN")
                mAlertList[0] = new UIElement_Alert(aaGame, mPosition - new Vector2(-200, 0), new AssetKit_UI_AlertGreen());

            mTextList[0] = new UIElement_Text(aaGame, mPosition - new Vector2(-200, -10), Color.White);
            mTextList[0].mText = pMessage;
            mTimeStamp[0] = 0;
        }

        public void CreateSetPositions()
        {
            for (int i = 0; i < Constants.MAX_ALERTS; i++)
            {
                mPositionList[i] = mPosition.Y - i * 50;
            }
        }
    }
}
