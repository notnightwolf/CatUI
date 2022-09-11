using System;
using UnityEngine;
using UnityEngine.UI;

namespace CatUI
{
    public class CatUIMenuButton
    {
        private GameObject btn;

        private Image img;

        private GameObject menu;

        private Button btnfunc;

        private GameObject backbtn;

        private Image backbtnimg;

        private Button backbtnfunc;

        public CatUIMenuButton(string btnname, float x, float y, string imagepath, string menuname, string location)
        {
            btn = new GameObject(btnname);
            btn.layer = LayerMask.NameToLayer("UI");
            if (location != null)
            {
                btn.transform.parent = GameObject.Find("Cohtml/QuickMenu/CatUI/" + location).transform;
            }
            else
            {
                btn.transform.parent = GameObject.Find("Cohtml/QuickMenu/CatUI/MainMenu").transform;
            }
            btn.transform.localPosition = new Vector3(x, y, 1);
            btn.transform.localScale = new Vector3(0.187f, 0.181f, 1);

            img = btn.AddComponent<Image>();
            img.sprite = (Environment.CurrentDirectory + imagepath).LoadSpriteFromDisk();
            img.color = new Color(1, 1, 1, 1);

            menu = new GameObject(menuname);
            menu.layer = LayerMask.NameToLayer("UI");
            menu.transform.parent = GameObject.Find("Cohtml/QuickMenu/CatUI").transform;
            menu.transform.localPosition = new Vector3(0.686f, 0, 0);
            menu.transform.localScale = new Vector3(1, 1, 1);
            menu.AddComponent<GraphicRaycaster>();

            btnfunc = btn.AddComponent<Button>();
            btnfunc.onClick = new Button.ButtonClickedEvent();
            btnfunc.onClick.AddListener(() =>
            {
                if (location != null)
                {
                    GameObject.Find("Cohtml/QuickMenu/CatUI/" + menuname).SetActive(true);
                    GameObject.Find("Cohtml/QuickMenu/CatUI/" + location).SetActive(false);
                }
                else
                {
                    GameObject.Find("Cohtml/QuickMenu/CatUI/" + menuname).SetActive(true);
                    GameObject.Find("Cohtml/QuickMenu/CatUI/MainMenu").SetActive(false);
                }
            });

            backbtn = new GameObject("Back");
            backbtn.layer = LayerMask.NameToLayer("UI");
            backbtn.transform.parent = GameObject.Find("Cohtml/QuickMenu/CatUI/" + menuname).transform;
            backbtn.transform.localPosition = new Vector3(-40.6f, -41.25f, 1);
            backbtn.transform.localScale = new Vector3(0.187f, 0.181f, 1);

            backbtnimg = backbtn.AddComponent<Image>();
            backbtnimg.sprite = (Environment.CurrentDirectory + "/CatUI/BackButton.png").LoadSpriteFromDisk();    //dont forget to change the texture :P
            backbtnimg.color = new Color(1, 1, 1, 1);

            backbtnfunc = backbtn.AddComponent<Button>();
            backbtnfunc.onClick = new Button.ButtonClickedEvent();
            backbtnfunc.onClick.AddListener(() =>
            {
                if (location != null)
                {
                    GameObject.Find("Cohtml/QuickMenu/CatUI/MainMenu" + location).SetActive(true);
                    GameObject.Find("Cohtml/QuickMenu/CatUI/" + menuname).SetActive(false);
                }
                else
                {
                    GameObject.Find("Cohtml/QuickMenu/CatUI/MainMenu").SetActive(true);
                    GameObject.Find("Cohtml/QuickMenu/CatUI/" + menuname).SetActive(false);
                }
            });

            btn.SetActive(true);
            menu.SetActive(false);
            backbtn.SetActive(true);
        }
    }
}
