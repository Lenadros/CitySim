using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CitySim
{
    class GameWorld
    {
        public Game1 aaGame;
        public Display aaDisplay;
        public WorldMap aaWorldMap;
        public Warehouse mWarehouse;

        public int mMoney;

        public List<Venue> mWorldVenues;
        public List<Residence> mWorldHomes;

        public UI_InfoBox mInfoBox;
        public UI_BuildPanel mBuildPanel;
        public UI_DataBar mDataBar;
        public UI_Alerts mAlerts;

        public GameWorld(Game1 pGame, Display pDisplay)
        {
            aaGame = pGame;
            aaDisplay = pDisplay;
            aaWorldMap = new WorldMap(aaGame, 20, 20, 3,2,2);
            mInfoBox = new UI_InfoBox(aaGame, Constants.SCREEN_WIDTH - 264, Constants.SCREEN_HEIGHT - 200);
            mBuildPanel = new UI_BuildPanel(aaGame, 0, 60);
            mDataBar = new UI_DataBar(aaGame, 0, 0);
            mAlerts = new UI_Alerts(aaGame, Constants.SCREEN_WIDTH - 200, 460);
            mMoney = 10000;

            mWorldVenues = new List<Venue>();
            mWorldHomes = new List<Residence>();
        }

        public void Update(GameTime gameTime)
        {
            aaDisplay.aaCamera.Update();
            mInfoBox.Update();
            mBuildPanel.Update();
            mDataBar.Update();
            mAlerts.Update();
            aaDisplay.aaCursor.Update();

            foreach (UIElement u in aaDisplay.mUIList)
                u.Update(gameTime);
        }

        public void UpdateBuildings()
        {
            //Console.WriteLine("--TICK--");
            foreach (Building b in aaWorldMap.mBuildingData)
            {
                if(b != null)
                    b.Update();
            }
        }
    }
}
