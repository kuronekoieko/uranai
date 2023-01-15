using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkiniiriPage : BasePageManager
{
    public override void OnStart()
    {
        base.SetPageAction(Page.Okiniiri);
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
