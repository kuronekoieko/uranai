using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranauPage : BasePageManager
{

    [SerializeField] UranaishiButtonManager uranaishiButtonManager;
    [SerializeField] Button uranaishiListButton;

    public override void OnStart()
    {
        base.SetPageAction(Page.Uranau);
        uranaishiButtonManager.OnStart();
        uranaishiButtonManager.ShowButtons(10);
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
