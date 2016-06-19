using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CitySim
{
    class Building_Resource : Building
    {
        public bool isAlertDisplayed;

        public Building_Resource(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
        }

        public override void Update()
        {
            base.Update();
        }
    }

    class Basic_Mine : Building_Resource
    {
        public int mWorkerCapacity;
        public int mHiredWorkers;
        public int mBaseMineRate;
        public int mMineRate;

        public int mHireAmount;
        public int mMineAmount;

        public bool isExhuastedAlert;
        public bool isWorkerlessAlert;

        public List<Residence> mHiredHomeList;
        public List<int> mHiredWorkerAmount;

        public Basic_Mine(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
            mHiredWorkers = 0;
            mWorkerCapacity = 20;
            mBaseMineRate = 100;
            isExhuastedAlert = false;
            isWorkerlessAlert = false;

            mHiredHomeList = new List<Residence>();
            mHiredWorkerAmount = new List<int>();

            mName = "Basic Mine";
            mAssetKit = new AssetKit_BasicMine();
            CreateDisplayObject();
        }

        public override void Update()
        {
            if (mHiredWorkers > 0)
                isEnabled = true;
            else
                isEnabled = false;

            if (mHiredWorkers < mWorkerCapacity)
            {
                HireWorkers();
            }

            mMineRate = (int)(mBaseMineRate * ((float)mHiredWorkers / mWorkerCapacity));

            if (isEnabled)
            {
                isWorkerlessAlert = false;
                mMineAmount = mBlock.MineMinerals(mMineRate);
                aaGame.aaGameWorld.mWarehouse.mMineral += mMineAmount;
                if (mMineAmount == 0 && !isExhuastedAlert)
                {
                    isEnabled = false;
                    isExhuastedAlert = true;
                    aaGame.aaGameWorld.mAlerts.AddAlert("RED", "Mine Exhuasted");
                }
            }

            base.Update();
        }

        public void HireWorkers()
        {
            foreach (Residence r in aaGame.aaGameWorld.mWorldHomes)
            {
                if (r.mEmployed < r.mWorkers)
                {
                    mHireAmount = r.HireWorkers(mWorkerCapacity - mHiredWorkers);
                    mHiredWorkers += mHireAmount;
                    if (mHireAmount > 0)
                    {
                        mHiredHomeList.Add(r);
                        mHiredWorkerAmount.Add(mHireAmount);
                    }

                    if (mHiredWorkers == mWorkerCapacity)
                        return;
                }
            }

            if (mHiredWorkers == 0 && !isWorkerlessAlert)
            {
                isWorkerlessAlert = true;
                aaGame.aaGameWorld.mAlerts.AddAlert("RED", "Worker Shortage");
            }
        }

        public override void GetInformation(UI_InfoBox pInfo)
        {
            pInfo.mUI_RowOneIcon.mAssetKit = pInfo.mOnIcon;
            pInfo.mUI_RowTwoIcon.mAssetKit = pInfo.mWorkerIcon;
            pInfo.mUI_RowThreeIcon.mAssetKit = pInfo.mMineralIcon;

            if (isEnabled)
            {
                pInfo.mRowOneText.mText = "Working";
                pInfo.mRowOneText.mColor = Color.Green;
            }
            else
            {
                pInfo.mRowOneText.mText = "Disabled";
                pInfo.mRowOneText.mColor = Color.Red;
            }

            pInfo.mRowTwoText.mText = mHiredWorkers.ToString() + "/" + mWorkerCapacity.ToString();
            if (mHiredWorkers == 0)
                pInfo.mRowTwoText.mColor = Color.Red;
            else
                pInfo.mRowTwoText.mColor = Color.White;

            pInfo.mRowThreeText.mText = mMineRate.ToString() + "/" + mBaseMineRate.ToString();
            if (mMineRate == 0)
                pInfo.mRowThreeText.mColor = Color.Red;
            else if (mMineRate < mBaseMineRate)
                pInfo.mRowThreeText.mColor = Color.Yellow;
            else
                pInfo.mRowThreeText.mColor = Color.Green;

            base.GetInformation(pInfo);
        }
    }

    class AutoMine : Building_Resource
    {
        public int mPowerUsage;
        public int mMineRate;

        public int mMineAmount;

        public bool isExhuastedAlert;
        public bool isNoPowerAlert;
        public bool isUsingPower;

        public AutoMine(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
            mPowerUsage = 20;
            mMineRate = 15;
            mName = "Automated Mine";
            isExhuastedAlert = false;
            isUsingPower = false;
            isNoPowerAlert = false;

            mAssetKit = new AssetKit_AutoMine();
            CreateDisplayObject();

            Update();
        }

        public override void Update()
        {
            //Power usage check
            

            //Mine update cycle
            if (isEnabled)
            {
                mMineAmount = mBlock.MineMinerals(mMineRate);
                aaGame.aaGameWorld.mWarehouse.mMineral += mMineAmount;
                if (mMineAmount == 0 && !isExhuastedAlert)
                {
                    isEnabled = false;
                    isExhuastedAlert = true;
                    aaGame.aaGameWorld.mAlerts.AddAlert("RED", "Mine Exhuasted");
                }
            }

            base.Update();
        }

        public override void GetInformation(UI_InfoBox pInfo)
        {
            pInfo.mUI_RowOneIcon.mAssetKit = pInfo.mOnIcon;
            pInfo.mUI_RowTwoIcon.mAssetKit = pInfo.mMineralIcon;

            if (isEnabled)
            {
                pInfo.mRowOneText.mText = "Powered";
                pInfo.mRowOneText.mColor = Color.Green;
            }
            else
            {
                pInfo.mRowOneText.mText = "Disabled";
                pInfo.mRowOneText.mColor = Color.Red;
            }

            pInfo.mRowTwoText.mText = mMineRate.ToString();

            base.GetInformation(pInfo);
        }
    }

    class Mineral_Power : Building_Resource
    {
        public int mGeneratedPower;
        public int mBurnRate;
        public int mFuelAmount;

        public bool isNoFuelAlert;

        public Mineral_Power(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
            mName = "Mineral Power Plant";
            mGeneratedPower = 20;
            mBurnRate = 50;
            isNoFuelAlert = false;

            mAssetKit = new AssetKit_MineralPower();
            CreateDisplayObject();
            Update();
        }

        public override void Update()
        {
            if (!isEnabled)
            {
                mFuelAmount = aaGame.aaGameWorld.mWarehouse.RequestMinerals(mBurnRate);
                if (mFuelAmount == mBurnRate)
                {
                    isNoFuelAlert = false;
                    isEnabled = true;
                    aaGame.aaGameWorld.mWarehouse.mTotalPower += mGeneratedPower;
                }
                else if (!isNoFuelAlert)
                {
                    isNoFuelAlert = true;
                    aaGame.aaGameWorld.mAlerts.AddAlert("RED", "Fuel Shortage");
                }
            }
            else
            {
                mFuelAmount = aaGame.aaGameWorld.mWarehouse.RequestMinerals(mBurnRate);
                if (mFuelAmount < mBurnRate && !isNoFuelAlert)
                {
                    isNoFuelAlert = true;
                    isEnabled = false;
                    aaGame.aaGameWorld.mWarehouse.mTotalPower -= mGeneratedPower;
                    aaGame.aaGameWorld.mAlerts.AddAlert("RED", "Fuel Shortage");
                }
            }

            base.Update();
        }

        public override void GetInformation(UI_InfoBox pInfo)
        {
            pInfo.mUI_RowOneIcon.mAssetKit = pInfo.mOnIcon;
            pInfo.mUI_RowTwoIcon.mAssetKit = pInfo.mMineralIcon;

            if (isEnabled)
            {
                pInfo.mRowOneText.mText = "Powered";
                pInfo.mRowOneText.mColor = Color.Green;
            }
            else
            {
                pInfo.mRowOneText.mText = "Disabled";
                pInfo.mRowOneText.mColor = Color.Red;
            }

            pInfo.mRowTwoText.mText = mBurnRate.ToString();

            base.GetInformation(pInfo);
        }
    }

    class Basic_Farm : Building_Resource
    {
        public int mFarmYeild;

        public Basic_Farm(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
            mFarmYeild = 100;
            mAssetKit = new AssetKit_BasicFarm();
            CreateDisplayObject();
        }

        public override void Update()
        {
            aaGame.aaGameWorld.mWarehouse.mFood += (int)(mFarmYeild * ((float)mBlock.mFertileAmt / 100));
            base.Update();
        }
    }

    class Shipment : Building_Resource
    {
        public int mShipmentAmt;
        public bool isShipping;
        public int mTickAmt;
        public int mShipTime; //Amount of update ticks it takes to ship

        public Shipment(Game1 pGame, Block pBlock)
            : base(pGame, pBlock)
        {
            mShipmentAmt = 100;
            isShipping = false;
            mShipTime = 5;
            mAssetKit = new AssetKit_Shippment();
            CreateDisplayObject();
        }

        public override void Update()
        {
            if (aaGame.aaGameWorld.mWarehouse.mMineral > mShipmentAmt && !isShipping)
            {
                isShipping = true;
                aaGame.aaGameWorld.mWarehouse.mMineral -= mShipmentAmt;
                mTickAmt = 0;
                aaGame.aaGameWorld.mMoney += mShipmentAmt * 10;
                Console.WriteLine("Spaceship has left the facility");
            }

            if (isShipping)
            {
                mTickAmt++;
                if (mTickAmt >= mShipTime)
                {
                    isShipping = false;
                    Console.WriteLine("Spaceship has arrived at the facility");
                }
            }

            base.Update();
        }
    }
}


