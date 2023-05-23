using System.Collections.Generic;
using SideScroller.UI.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class ScreenAssetPath
    {
        #region Struct

        public struct ScreenPath
        {
            public string Screen;
            public Dictionary<ScreenElementTypes, string> Elements;
        }

        #endregion

        #region Fields

        public static readonly Dictionary<ScreenTypes, ScreenPath> Screens = new Dictionary<ScreenTypes, ScreenPath>
        {
            {
                ScreenTypes.Canvas,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Prefabs_UI_Canvas",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.MainMenu,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Screens/Prefabs_UI_Screens_MainMenu",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.PauseMenu,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Screens/Prefabs_UI_Screens_PauseMenu",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.GameMenu,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Screens/Prefabs_UI_Screens_GameMenu",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.EndGameMenu,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Screens/Prefabs_UI_Screens_EndGameMenu",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                }
            },
            {
                ScreenTypes.InventoryMenu,
                new ScreenPath
                {
                    Screen = "Prefabs/UI/Screens/Prefabs_UI_Screens_InventoryMenu",
                    Elements = new Dictionary<ScreenElementTypes, string>()
                    {
                        {ScreenElementTypes.ItemCell,"Prefabs/UI/Parts/Prefabs_UI_Parts_ItemCell" }
                    }
                }
            }
        };

        #endregion
    }
}