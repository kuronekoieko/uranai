using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UranaishiButtonManager : ObjectPooling<UranaishiButton>
{
    public void OnStart()
    {
        base.Initialize();
    }

    public void ShowButtons(Uranaishi[] uranaishiAry)
    {
        base.Clear();

        for (int i = 0; i < uranaishiAry.Length; i++)
        {
            var uranaishiButton = base.GetInstance();
            uranaishiButton.ShowData(uranaishiAry[i]);
        }
    }

}
