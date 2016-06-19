using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CitySim
{
    class BuildingDatabase
    {
        public Building[] mBuildingList;
        public string[] mBuildingTypes;

        public BuildingDatabase()
        {
            mBuildingList = new Building[10];
            mBuildingTypes = new string[10];
            CreateList();
        }

        public void CreateList()
        {
            mBuildingTypes[0] = "BASIC_MINE";
            //mBuildingList[0] = new Basic_Mine(
        }
    }
}
