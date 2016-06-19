using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitySim
{
    class Building_Core : Building
    {
        public Building_Core(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
        }

        public override void Update()
        {
            base.Update();
        }
    }

    class Residence : Building_Core
    {
        public float mMoney;
        public float mHappiness;
        public int mWorkers;
        public int mEmployed;
        public int mLeftOver;

        public Residence(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
            mAssetKit = new AssetKit_Home();
            CreateDisplayObject();
            mMoney = 1000;
            mHappiness = 80;
            mWorkers = 10;
            mEmployed = 0;
            aaGame.aaGameWorld.mWorldHomes.Add(this);
        }

        public override void Update()
        {
            /*
            Console.WriteLine("-----------------HOME---------------------");
            Console.WriteLine("Happines: " + mHappiness);
            Console.WriteLine("Number Employed: " + mEmployed);
            Console.WriteLine("Money: " + mMoney);
            Console.WriteLine("------------------------------------------");
            */

            mHappiness -= mEmployed * 0.01f;

            base.Update();
        }


        public int HireWorkers(int pWorkers)
        {
            if (pWorkers <= mWorkers)
            {
                mWorkers -= pWorkers;
                mEmployed += pWorkers;
                return pWorkers;
            }
            else if (pWorkers > mWorkers)
            {
                mLeftOver = mWorkers;
                mWorkers = 0;
                mEmployed += mLeftOver;
                return mLeftOver;
            }
            else if (mWorkers == 0)
            {
                return mWorkers;
            }
            return 0;
        }
    }

    class Venue : Building_Core
    {
        public Venue(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
        }
    }
}