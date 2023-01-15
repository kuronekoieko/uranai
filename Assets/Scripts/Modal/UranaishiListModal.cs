using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranaishiListModal : BaseModal
{
    [SerializeField] UranaishiButtonManager uranaishiButtonManager;
    public override void OnStart()
    {
        base.OnStart();
        uranaishiButtonManager.OnStart();
        uranaishiButtonManager.ShowButtons(11);

    }

    public void Open()
    {
        base.OpenAnim();


    }
}
