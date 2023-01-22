using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : BaseButtonController
{
    void Start()
    {
        base.AddListener(() =>
        {
            ChromeCustomTabs.OpenURL("https://www.google.co.jp");
        });
    }


}
