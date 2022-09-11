using System;
using UnityEngine;
using UnityEngine.UI;

namespace CatUI
{
    public class CatUIToggleButton
    {
        private GameObject btnh;

        private Image imgh;

        private Outline outl;

        private GameObject btn;

        private Image img;

        private Toggle btnfunc;

        public CatUIToggleButton(string btnname, float x, float y, string imagepath, Action<bool> callback, string location, bool defaultvalue)
        {
            btnh = new GameObject(btnname + "h");
            btnh.layer = LayerMask.NameToLayer("UI");
            if (location != null)
            {
                btnh.transform.parent = GameObject.Find("Cohtml/QuickMenu/CatUI/" + location).transform;
            }
            else
            {
                btnh.transform.parent = GameObject.Find("Cohtml/QuickMenu/CatUI/MainMenu").transform;
            }
            btnh.transform.localPosition = new Vector3(x, y, 1);
            btnh.transform.localScale = new Vector3(0.187f, 0.181f, 0.1f);

            btnh.AddComponent<Image>();
            imgh = btnh.GetComponent<Image>();
            imgh.sprite = (Environment.CurrentDirectory + "/CatUI/blankbtn.png").LoadSpriteFromDisk();
            imgh.color = new Color(0, 0, 0, 1);
            imgh.enabled = defaultvalue;

            btnh.AddComponent<Outline>();
            outl = btnh.GetComponent<Outline>();
            outl.effectColor = new Color(0.3f, 1, 0.3f, 1);
            outl.effectDistance = new Vector2(1.7f, -1.7f);
            outl.enabled = defaultvalue;
            btnh.SetActive(true);

            btn = new GameObject(btnname);
            btn.layer = LayerMask.NameToLayer("UI");
            if (location != null)
            {
                btn.transform.parent = GameObject.Find("Cohtml/QuickMenu/CatUI/" + location + "/" + btnname + "h").transform;
            }
            else
            {
                btn.transform.parent = GameObject.Find("Cohtml/QuickMenu/CatUI/MainMenu/" + btnname + "h").transform;
            }
            btn.transform.localPosition = new Vector3(0, 0, 0);
            btn.transform.localScale = new Vector3(1, 1, 1);

            btn.AddComponent<Image>();
            img = btn.GetComponent<Image>();
            img.sprite = (Environment.CurrentDirectory + imagepath).LoadSpriteFromDisk();
            img.color = new Color(1, 1, 1, 1);

            btn.AddComponent<Toggle>();
            btnfunc = btn.GetComponent<Toggle>();
            btnfunc.SetIsOnWithoutNotify(defaultvalue);
            btnfunc.onValueChanged = new Toggle.ToggleEvent();
            btnfunc.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<bool>(value =>
            {
                if (value)
                {
                    imgh.enabled = true;
                    outl.enabled = true;
                    callback(value);
                }
                else
                {
                    imgh.enabled = false;
                    outl.enabled = false;
                    callback(value);
                }
            }));
            btn.SetActive(true);
        }

        public void SetToggleState(bool value)
        {
            this.btnfunc.isOn = value;
        }
    }
}
