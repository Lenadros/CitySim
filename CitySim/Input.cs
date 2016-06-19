using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CitySim
{
    class Input
    {
        public MouseState mMouseState;
        public MouseState mPrevMouseState;
        public KeyboardState mKeyState;
        public KeyboardState mPrevKeyState;

        public Point mCursorPos;

        public void Update()
        {
            mPrevMouseState = mMouseState;
            mMouseState = Mouse.GetState();
            mPrevKeyState = mKeyState;
            mKeyState = Keyboard.GetState();
            mCursorPos = Point.Zero;
        }

        public KeyboardState GetKeyState()
        {
            return mKeyState;
        }

        public KeyboardState GetPrevKeyState()
        {
            return mPrevKeyState;
        }

        public MouseState GetMouseState()
        {
            return mMouseState;
        }

        public MouseState GetPrevMouseState()
        {
            return mPrevMouseState;
        }

        public bool LeftBtnPress()
        {
            if (mPrevMouseState.LeftButton == ButtonState.Pressed && mMouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public bool RightBtnPress()
        {
            if (mPrevMouseState.RightButton == ButtonState.Pressed && mMouseState.RightButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public Point GetCursorPosition()
        {
            mCursorPos.X = mMouseState.X;
            mCursorPos.Y = mMouseState.Y;
            return mCursorPos;
        }
    }
}
