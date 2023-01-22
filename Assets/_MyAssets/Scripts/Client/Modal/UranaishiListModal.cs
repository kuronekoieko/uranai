using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UranaishiListModal : BaseModal
{
    [SerializeField] UranaishiButtonManager uranaishiButtonManager;
    public override async void OnStart()
    {
        base.OnStart();
        uranaishiButtonManager.OnStart();

        Uranaishi[] uranaishiAry = await FirebaseDatabaseManager.i.GetUranaishiAry(20);
        uranaishiButtonManager.ShowButtons(uranaishiAry);
    }

    public void Open()
    {
        base.OpenAnim();


    }
}
