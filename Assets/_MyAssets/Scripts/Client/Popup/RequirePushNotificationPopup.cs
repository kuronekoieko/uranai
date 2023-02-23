using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RequirePushNotificationPopup : BasePopup
{


    public override void OnStart()
    {
        base.OnStart();
    }

    public override void Open()
    {
        base.onClickPositiveButton = OnClickSettingPNButton;
        base.Open();
    }

    void OnClickSettingPNButton()
    {
    }


}
