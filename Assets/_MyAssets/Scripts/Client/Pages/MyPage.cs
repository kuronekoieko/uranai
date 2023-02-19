using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPage : BasePageManager
{
    [SerializeField] Button purchaseButton;

    public override void OnStart()
    {
        base.SetPageAction(4);
        purchaseButton.onClick.AddListener(() =>
        {
            UIManager.i.GetModal<PurchaseModal>().Open();
        });
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
