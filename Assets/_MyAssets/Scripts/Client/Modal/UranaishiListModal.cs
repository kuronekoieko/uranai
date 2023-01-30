using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UranaishiListModal : BaseModal
{
    [SerializeField] UranaishiButtonManager uranaishiButtonManager;
    public static UranaishiListModal i;
    public override void OnStart()
    {
        i = this;
        base.OnStart();
        uranaishiButtonManager.OnStart();

        uranaishiButtonManager.ShowButtons(UIManager.i.uranaishiAry.Take(20).ToArray());
    }

    public void Open()
    {
        base.OpenAnim();
    }
}
