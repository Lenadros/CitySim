using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CitySim
{
    class AssetLoader
    {
        public ContentManager aaContent;

        public string[] mAssetNames;
        public Texture2D[] mAssetTextures;
        public List<string> mAssetKitNames;
        public List<AssetKit> mAssetKits;
        public SpriteFont mFont;

        public AssetLoader(ContentManager pContent)
        {
            aaContent = pContent;
            mAssetKitNames = new List<string>();
            mAssetKits = new List<AssetKit>();
        }

        public void CreateContentList()
        {
            List<string> mContentList = new List<string>();

            mContentList.Add("Cursor");
            mContentList.Add("Block_Grass");
            mContentList.Add("Block_Water");
            mContentList.Add("Block_Rock");
            mContentList.Add("UI_InfoBox_Block");
            mContentList.Add("UI_InfoBox_Building");
            mContentList.Add("UI_Build_Panel");
            mContentList.Add("Icons");
            mContentList.Add("Buildings_Resource");
            mContentList.Add("UI_DataBar");
            mContentList.Add("UI_Alert");
            mContentList.Add("UI_AlertGreen");

            LoadContent(mContentList);
        }

        public void LoadContent(List<string> pContentList)
        {
            mAssetNames = new string[pContentList.Count];
            mAssetTextures = new Texture2D[pContentList.Count];

            int index = 0;
            foreach (string aName in pContentList)
            {
                mAssetNames[index] = aName;
                mAssetTextures[index] = aaContent.Load<Texture2D>(aName);
                index++;
            }

            mFont = aaContent.Load<SpriteFont>("mFont");

            Console.WriteLine("Finished Loading Content");
        }

        public Texture2D GetAsset(string pAssetName)
        {
            return mAssetTextures[Array.IndexOf(mAssetNames, pAssetName)];
        }

        public AssetKit GetAssetKit(string pAssetKitName)
        {
            return mAssetKits[mAssetKitNames.IndexOf(pAssetKitName)];
        }
    }
}
