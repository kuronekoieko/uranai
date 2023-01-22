using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UranauPage : BasePageManager
{

    [SerializeField] UranaishiButtonManager uranaishiButtonManager;
    [SerializeField] Button uranaishiListButton;

    public override async void OnStart()
    {
        base.SetPageAction(Page.Uranau);
        uranaishiButtonManager.OnStart();
        Uranaishi[] a = await FirebaseDatabaseManager.i.GetUranaishiAry(10);
        uranaishiButtonManager.ShowButtons(a);
        uranaishiListButton.onClick.AddListener(() => UIManager.i.uranaishiListModal.Open());
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
