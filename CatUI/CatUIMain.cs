using MelonLoader;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CatUI
{
    public static class CatUIMain
    {

        public static GameObject CatUIPanel;

        private static GameObject banner;

        private static Image bannerimg;

        private static GameObject MainMenu;

        public static IEnumerator InitializeCatUI()
        {
            while (GameObject.Find("Cohtml") == null) yield return null;
            CatUIPanel = new GameObject("CatUI");
            CatUIPanel.layer = LayerMask.NameToLayer("UI");
            CatUIPanel.transform.parent = GameObject.Find("Cohtml/QuickMenu").transform;
            CatUIPanel.AddComponent<Canvas>();
            var Canvas = CatUIPanel.GetComponent<Canvas>();
            Canvas.renderMode = RenderMode.WorldSpace;
            Canvas.GetComponent<Canvas>().worldCamera = Camera.main;
            Canvas.sortingLayerID = 10;
            Canvas.sortingLayerName = "UI";
            Canvas.sortingOrder = 10;
            Canvas.overrideSorting = true;
            CatUIPanel.transform.localPosition = new Vector3(0.686f, 0, 0);
            CatUIPanel.transform.localScale = new Vector3(0.006f, 0.007f, 0.001f);
            CatUIPanel.AddComponent<GraphicRaycaster>();
            CatUIPanel.gameObject.SetActive(false);

            banner = new GameObject("Banner");
            banner.layer = LayerMask.NameToLayer("UI");
            banner.transform.parent = CatUIPanel.transform;
            banner.transform.localPosition = new Vector3(0, 41, 0);
            banner.transform.localScale = new Vector3(1, 0.18f, 0.1f);

            banner.AddComponent<Image>();
            bannerimg = banner.GetComponent<Image>();
            bannerimg.sprite = (Environment.CurrentDirectory + "/CatUI/banner.png").LoadSpriteFromDisk();
            bannerimg.color = new Color(1, 1, 1, 1);
            banner.SetActive(true);

            MainMenu = new GameObject("MainMenu");
            MainMenu.layer = LayerMask.NameToLayer("UI");
            MainMenu.transform.parent = GameObject.Find("Cohtml/QuickMenu/CatUI").transform;
            MainMenu.transform.localPosition = new Vector3(0.686f, 0, 0);
            MainMenu.transform.localScale = new Vector3(1, 1, 1);
            MainMenu.AddComponent<GraphicRaycaster>();

            CatUIMenu();

            MelonLogger.Msg(ConsoleColor.Blue, "CatUI successfully initialized");
        }

        /*
        X | -40.6f | -20.3f | 0 | 20.3f | 40.6f |
        Banner
          | 20.5f |
          | -0.05f |
          | -20.5f |
          | -41.25f |
        Y
        */

        public static void CatUIMenu()
        {
            //put all ur stuff here

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            new CatUISimpleButton("CatUISimpleButton", -40.6f, 20.5f, "/CatUI/CatUISimpleButton.png", () =>                       //Simple Click Button
            {
                MelonLogger.Msg(ConsoleColor.Blue, "click");
            }, null);

            new CatUIToggleButton("CatUIToggleButton", -40.6f, -0.05f, "/CatUI/CatUIToggleButton.png", (value) =>            //Toggle State Button
            {
                if (value)
                {
                    MelonLogger.Msg(ConsoleColor.Green, "on");
                }
                else
                {
                    MelonLogger.Msg(ConsoleColor.Red, "off");
                }
            }, null, false);

            new CatUIMenuButton("CatUIMenuButton", -40.6f, -20.5f, "/CatUI/CatUIMenuButton.png", "TestMenu", null);      //Menu Button

            //btnname = button name
            //x = left/right
            //y = up/down
            //imagepath = path in ur cvr directory
            //location = CatUIMenuButton menuname or null for MainMenu
            //menuname = name of ur submenu (CatUIMenuButton)
            //defaultvalue = decide whether your ToggleButton is set to true or false by default (CatUIToggleButton)
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //dont forget to change the back button texture in CatUIMenuButton.cs
        }
    }
}
