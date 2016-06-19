using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CitySim
{
    class AssetKit
    {
        public string ASSET_NAME;

        public Rectangle SRC_RECTANGLE = Rectangle.Empty;
        

        public Vector2 ORIGIN = Vector2.Zero;
    }

    //-------------------------------------------------------
    //                    EMPTY ASSET KIT
    //-------------------------------------------------------
    class AssetKit_Empty : AssetKit
    {
        public AssetKit_Empty()
            : base()
        {
            ASSET_NAME = "Block_Grass";
        }
    }

    //-------------------------------------------------------
    //                    BLOCK ASSET KITS
    //-------------------------------------------------------
    class AssetKit_Block_Grass : AssetKit
    {
        public AssetKit_Block_Grass()
            : base()
        {
            ASSET_NAME = "Block_Grass";

            SRC_RECTANGLE.Width = 32;
            SRC_RECTANGLE.Height = 32;
        }
    }

    class AssetKit_Block_Water : AssetKit
    {
        public AssetKit_Block_Water()
            : base()
        {
            ASSET_NAME = "Block_Water";

            SRC_RECTANGLE.Width = 32;
            SRC_RECTANGLE.Height = 32;
        }
    }

    //-------------------------------------------------------
    //                    UI ASSET KITS
    //-------------------------------------------------------
    class AssetKit_UI_InfoBoxBlock : AssetKit
    {
        public AssetKit_UI_InfoBoxBlock()
            : base()
        {
            ASSET_NAME = "UI_InfoBox_Block";

            SRC_RECTANGLE.Width = 132;
            SRC_RECTANGLE.Height = 100;
        }
    }

    class AssetKit_UI_InfoBoxBuilding : AssetKit
    {
        public AssetKit_UI_InfoBoxBuilding()
            : base()
        {
            ASSET_NAME = "UI_InfoBox_Building";

            SRC_RECTANGLE.Width = 132;
            SRC_RECTANGLE.Height = 100;
        }
    }


    class AssetKit_Mouse : AssetKit
    {
        public AssetKit_Mouse()
            : base()
        {
            ASSET_NAME = "Cursor";

            SRC_RECTANGLE.Height = 16;
            SRC_RECTANGLE.Width = 16;
        }
    }

    class AssetKit_UI_DataBar : AssetKit
    {
        public AssetKit_UI_DataBar()
            : base()
        {
            ASSET_NAME = "UI_DataBar";

            SRC_RECTANGLE.Width = Constants.SCREEN_WIDTH;
            SRC_RECTANGLE.Height = 20;
        }
    }

    class AssetKit_UI_Alert : AssetKit
    {
        public AssetKit_UI_Alert()
            : base()
        {
            ASSET_NAME = "UI_Alert";

            SRC_RECTANGLE.Width = 100;
            SRC_RECTANGLE.Height = 20;
        }
    }

    class AssetKit_UI_AlertGreen : AssetKit
    {
        public AssetKit_UI_AlertGreen()
            : base()
        {
            ASSET_NAME = "UI_AlertGreen";

            SRC_RECTANGLE.Width = 100;
            SRC_RECTANGLE.Height = 20;
        }
    }

    class AssetKit_UI_BaseBuildPanel : AssetKit
    {
        public AssetKit_UI_BaseBuildPanel()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.Height = 300;
            SRC_RECTANGLE.Width = 9;
        }
    }

    class AssetKit_UI_BuildPanel : AssetKit
    {
        public AssetKit_UI_BuildPanel()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 52;
            SRC_RECTANGLE.Height = 300;
            SRC_RECTANGLE.Width = 18;
        }
    }

    //-------------------------------------------------------
    //                    ICON ASSET KITS
    //-------------------------------------------------------
    class AssetKit_UI_FertileIcon : AssetKit
    {
        public AssetKit_UI_FertileIcon()
            : base()
        {
            ASSET_NAME = "Icons";

            SRC_RECTANGLE.Width = 16;
            SRC_RECTANGLE.Height = 16;
        }
    }

    class AssetKit_UI_MineralIcon : AssetKit
    {
        public AssetKit_UI_MineralIcon()
            : base()
        {
            ASSET_NAME = "Icons";

            SRC_RECTANGLE.Width = 16;
            SRC_RECTANGLE.Height = 16;
            SRC_RECTANGLE.X = 16;
        }
    }

    class AssetKit_UI_WaterIcon : AssetKit
    {
        public AssetKit_UI_WaterIcon()
            : base()
        {
            ASSET_NAME = "Icons";

            SRC_RECTANGLE.Width = 16;
            SRC_RECTANGLE.Height = 16;
            SRC_RECTANGLE.X = 32;
        }
    }

    class AssetKit_UI_PowerIcon : AssetKit
    {
        public AssetKit_UI_PowerIcon()
            : base()
        {
            ASSET_NAME = "Icons";

            SRC_RECTANGLE.Width = 16;
            SRC_RECTANGLE.Height = 16;
            SRC_RECTANGLE.X = 64;
        }
    }

    class AssetKit_UI_MoneyIcon : AssetKit
    {
        public AssetKit_UI_MoneyIcon()
            : base()
        {
            ASSET_NAME = "Icons";

            SRC_RECTANGLE.Width = 16;
            SRC_RECTANGLE.Height = 16;
            SRC_RECTANGLE.X = 48;
        }
    }

    class AssetKit_UI_OnIcon : AssetKit
    {
        public AssetKit_UI_OnIcon()
            : base()
        {
            ASSET_NAME = "Icons";

            SRC_RECTANGLE.Width = 16;
            SRC_RECTANGLE.Height = 16;
            SRC_RECTANGLE.Y = 16;
        }
    }

    class AssetKit_UI_WorkerIcon : AssetKit
    {
        public AssetKit_UI_WorkerIcon()
            : base()
        {
            ASSET_NAME = "Icons";

            SRC_RECTANGLE.Width = 16;
            SRC_RECTANGLE.Height = 16;
            SRC_RECTANGLE.X = 16;
            SRC_RECTANGLE.Y = 16;
        }
    }

    //-------------------------------------------------------
    //                    BUTTON ASSET KITS
    //-------------------------------------------------------
    class AssetKit_UI_WarehouseButton : AssetKit
    {
        public AssetKit_UI_WarehouseButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 19;
            SRC_RECTANGLE.Y = 72;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    class AssetKit_UI_MiningButton : AssetKit
    {
        public AssetKit_UI_MiningButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 19;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;

        }
    }

    class AssetKit_UI_PowerButton : AssetKit
    {
        public AssetKit_UI_PowerButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 19;
            SRC_RECTANGLE.Y = 24;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    class AssetKit_UI_ShipmentButton : AssetKit
    {
        public AssetKit_UI_ShipmentButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 128;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    class AssetKit_UI_BMineButton : AssetKit
    {
        public AssetKit_UI_BMineButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 80;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    class AssetKit_UI_MineralPowerButton : AssetKit
    {
        public AssetKit_UI_MineralPowerButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 80;
            SRC_RECTANGLE.Y = 24;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    class AssetKit_UI_FoodButton : AssetKit
    {
        public AssetKit_UI_FoodButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 19;
            SRC_RECTANGLE.Y = 48;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    class AssetKit_UI_HomeButton : AssetKit
    {
        public AssetKit_UI_HomeButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 104;
            SRC_RECTANGLE.Y = 48;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    class AssetKit_UI_BasicFarmButton : AssetKit
    {
        public AssetKit_UI_BasicFarmButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 80;
            SRC_RECTANGLE.Y = 48;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    class AssetKit_UI_BackButton : AssetKit
    {
        public AssetKit_UI_BackButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 104;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    class AssetKit_UI_AutoMineButton : AssetKit
    {
        public AssetKit_UI_AutoMineButton()
            : base()
        {
            ASSET_NAME = "UI_Build_Panel";

            SRC_RECTANGLE.X = 152;
            SRC_RECTANGLE.Height = 23;
            SRC_RECTANGLE.Width = 23;
        }
    }

    //-------------------------------------------------------
    //                    BUILDING ASSET KITS
    //-------------------------------------------------------
    class AssetKit_BasicMine : AssetKit
    {
        public AssetKit_BasicMine()
            : base()
        {
            ASSET_NAME = "Buildings_Resource";

            SRC_RECTANGLE.Height = 32;
            SRC_RECTANGLE.Width = 32;
        }
    }

    class AssetKit_AutoMine : AssetKit
    {
        public AssetKit_AutoMine()
            : base()
        {
            ASSET_NAME = "Buildings_Resource";

            SRC_RECTANGLE.Height = 32;
            SRC_RECTANGLE.Width = 32;
            SRC_RECTANGLE.X = 160;
        }
    }

    class AssetKit_MineralPower : AssetKit
    {
        public AssetKit_MineralPower()
            : base()
        {
            ASSET_NAME = "Buildings_Resource";

            SRC_RECTANGLE.Height = 32;
            SRC_RECTANGLE.Width = 32;
            SRC_RECTANGLE.X = 32;
        }
    }

    class AssetKit_Shippment : AssetKit
    {
        public AssetKit_Shippment()
            : base()
        {
            ASSET_NAME = "Buildings_Resource";

            SRC_RECTANGLE.Height = 32;
            SRC_RECTANGLE.Width = 32;
            SRC_RECTANGLE.X = 96;
        }
    }

    class AssetKit_BasicFarm : AssetKit
    {
        public AssetKit_BasicFarm()
            : base()
        {
            ASSET_NAME = "Buildings_Resource";

            SRC_RECTANGLE.Height = 32;
            SRC_RECTANGLE.Width = 32;
            SRC_RECTANGLE.X = 64;
        }
    }

    class AssetKit_Home : AssetKit
    {
        public AssetKit_Home()
            : base()
        {
            ASSET_NAME = "Buildings_Resource";

            SRC_RECTANGLE.Height = 32;
            SRC_RECTANGLE.Width = 32;
            SRC_RECTANGLE.Y = 32;
        }
    }

    class AssetKit_Warehouse : AssetKit
    {
        public AssetKit_Warehouse()
            : base()
        {
            ASSET_NAME = "Buildings_Resource";

            SRC_RECTANGLE.Height = 32;
            SRC_RECTANGLE.Width = 32;
            SRC_RECTANGLE.X = 128;
        }
    }
}
