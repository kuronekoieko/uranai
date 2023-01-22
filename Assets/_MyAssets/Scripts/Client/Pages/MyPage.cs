using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPage : BasePageManager
{
    public override void OnStart()
    {
        base.SetPageAction(Page.MyPage);

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
