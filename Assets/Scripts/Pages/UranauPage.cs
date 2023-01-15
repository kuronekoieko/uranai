using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranauPage : BasePageManager
{
    public override void OnStart()
    {
        base.SetPageAction(Page.Uranau);
    }

    public override void OnUpdate()
    {
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    protected override void OnOpen()
    {
        gameObject.SetActive(true);
    }
}
