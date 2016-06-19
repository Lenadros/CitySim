using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CitySim
{
    class DisplayObject
    {
        public Display aaDisplay;

        public float mDepth;

        public string mAssetName;

        public Rectangle mSrcRectangle;
        public Vector2 mOrigin;
        public Vector2 mPosition;

        public DisplayObject(Display pDisplay, string pAssetName, float pPosX, float pPosY, Rectangle pSrcRectangle, Vector2 pOrigin, float pDepth = 0)
        {
            aaDisplay = pDisplay;
            mAssetName = pAssetName;
            mPosition = new Vector2(pPosX, pPosY);
            mDepth = pDepth;
            mSrcRectangle = pSrcRectangle;
            mOrigin = pOrigin;
            aaDisplay.AddToDisplayList(this);
        }
    }
}
