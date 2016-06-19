using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CitySim
{
    class WorldMap
    {
        public Game1 aaGame;

        public int mWidth;
        public int mHeight;
        public int mStartX;
        public int mLakeCount;
        public int mMineralPatchCount;
        public int mFertilePatchCount;

        public Block[,] mMapData;
        public Building[,] mBuildingData;
        public Vector2 mGridPos;

        public WorldMap(Game1 pGame, int pWidth, int pHeight, int pLakes, int pMinerals, int pFertile)
        {
            aaGame = pGame;
            mWidth = pWidth;
            mHeight = pHeight;
            mLakeCount = pLakes;
            mMineralPatchCount = pMinerals;
            mFertilePatchCount = pFertile;

            GenerateMap();

            Console.WriteLine("Finished Generating Map");
        }

        public void GenerateMap()
        {
            mMapData = new Block[mWidth, mHeight];
            mBuildingData = new Building[mWidth, mHeight];

            mStartX = (mWidth - 1) * Constants.TILE_WIDTH / 2;

            //TODO: THIS IS ONLY FOR TESTING. SHOULD BE REPLACED WITH SOME PERLIN NOISE
            for (int y = 0; y < mHeight; y++)
            {
                for (int x = 0; x < mWidth; x++)
                {
                    mMapData[x, y] = new Block(aaGame, "GRASS", mStartX + x * Constants.TILE_WIDTH/2 - y * Constants.TILE_HEIGHT, y * Constants.TILE_HEIGHT/2 + x * Constants.TILE_HEIGHT/2);
                }
            }

            for (int l = 0; l < mLakeCount; l++)
            {
                CreateLake(aaGame.mRandom.Next(0,mWidth), aaGame.mRandom.Next(0,mHeight));
            }
        }

        public void CreateLake(int pPosX, int pPosY)
        {
            //TODO: THIS IS ONLY FOR TESTING. SHOULD BE REPLACED WITH SOME PERLIN NOISE
            for (int x = pPosX - 2; x < pPosX + 3; x++)
            {
                for (int y = pPosY - 1; y < pPosY + 2; y++)
                {
                    if (x > 0 && x < mWidth -1 && y > 0 && y < mHeight - 1)
                    {
                        mMapData[x, y].Destroy();
                        mMapData[x, y] = new Block(aaGame, "WATER", mStartX + x * Constants.TILE_WIDTH / 2 - y * Constants.TILE_HEIGHT, y * Constants.TILE_HEIGHT / 2 + x * Constants.TILE_HEIGHT / 2);
                    }
                }
            }

            for (int x = pPosX - 1; x < pPosX + 2; x++)
            {
                for (int y = pPosY - 2; y < pPosY + 3; y++)
                {
                    if (x > 0 && x < mWidth - 1 && y > 0 && y < mHeight - 1)
                    {
                        mMapData[x, y].Destroy();
                        mMapData[x, y] = new Block(aaGame, "WATER", mStartX + x * Constants.TILE_WIDTH / 2 - y * Constants.TILE_HEIGHT, y * Constants.TILE_HEIGHT / 2 + x * Constants.TILE_HEIGHT / 2);
                    }
                }
            }
        }

        public Vector2 ScreenToGrid(float pScreenX, float pScreenY)
        {
            mGridPos.X = (int)((pScreenX - mWidth * Constants.TILE_WIDTH - aaGame.aaDisplay.aaCamera.mPosition.X) / Constants.TILE_WIDTH + (pScreenY - aaGame.aaDisplay.aaCamera.mPosition.Y) / Constants.TILE_HEIGHT) / 2;
            mGridPos.Y = (int)((pScreenY- aaGame.aaDisplay.aaCamera.mPosition.Y) / Constants.TILE_HEIGHT - (pScreenX - mWidth * Constants.TILE_WIDTH - aaGame.aaDisplay.aaCamera.mPosition.X) / Constants.TILE_WIDTH) / 2;
            return mGridPos;
        }

        public Block GetBlock(Vector2 pGridPos)
        {
            if (pGridPos.X < 0 || pGridPos.X > mWidth-1 || pGridPos.Y < 0 || pGridPos.Y > mHeight-1)
                return null;
            else
                return mMapData[(int)pGridPos.X, (int)pGridPos.Y];
        }

        public Building GetBuilding(Vector2 pGridPos)
        {
            if (pGridPos.X < 0 || pGridPos.X > mWidth - 1 || pGridPos.Y < 0 || pGridPos.Y > mHeight - 1)
                return null;
            else
                return mBuildingData[(int)pGridPos.X, (int)pGridPos.Y];
        }

        public void AddBuilding(Vector2 pGridPos, Building pBuilding)
        {
            mBuildingData[(int)pGridPos.X, (int)pGridPos.Y] = pBuilding;
        }
    }
}
