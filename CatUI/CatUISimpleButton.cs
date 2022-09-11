using System;
using UnityEngine;
using UnityEngine.UI;

namespace CatUI
{
    public class CatUISimpleButton
    {
        private GameObject btn;

        private Image img;

        private Button btnfunc;

        public CatUISimpleButton(string btnname, float x, float y, string imagepath, UnityEngine.Events.UnityAction action, string location)
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
            btn.transform.localScale = new Vector3(0.187f, 0.181f, 0.1f);

            btn.AddComponent<Image>();
            img = btn.GetComponent<Image>();
            img.sprite = (Environment.CurrentDirectory + imagepath).LoadSpriteFromDisk();
            img.color = new Color(1, 1, 1, 1);

            btn.AddComponent<Button>();
            btnfunc = btn.GetComponent<Button>();
            btnfunc.onClick = new Button.ButtonClickedEvent();
            btnfunc.onClick.AddListener(action);
            btn.SetActive(true);
        }
    }
}
