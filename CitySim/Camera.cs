using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CitySim
{
    class Camera
    {
        public Matrix mTransform;
        public Vector3 mZoom;
        public Vector3 mPosition;
        public Display aaDisplay;

        public Camera(Display pDisplay, float pPosX = 0, float pPosY = 0)
        {
            aaDisplay = pDisplay;
            mZoom = new Vector3(Constants.CAMERA_ZOOM, Constants.CAMERA_ZOOM, 0);
            mPosition = new Vector3(pPosX, pPosY, 0);
        }

        public void Update()
        {
            if (aaDisplay.aaGame.aaInput.mKeyState.IsKeyDown(Keys.W))
            {
                mPosition.Y += Constants.CAMERA_SPEED;
            }
            else if (aaDisplay.aaGame.aaInput.mKeyState.IsKeyDown(Keys.S))
            {
                mPosition.Y -= Constants.CAMERA_SPEED;
            }
            else if (aaDisplay.aaGame.aaInput.mKeyState.IsKeyDown(Keys.A))
            {
                mPosition.X += Constants.CAMERA_SPEED;
            }
            else if (aaDisplay.aaGame.aaInput.mKeyState.IsKeyDown(Keys.D))
            {
                mPosition.X -= Constants.CAMERA_SPEED;
            }

            mTransform = Matrix.CreateScale(mZoom) * Matrix.CreateTranslation(mPosition);
        }

        public Matrix GetTransform()
        {
            return mTransform;
        }
    }
}
