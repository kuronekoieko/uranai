using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchasePointsPopup : BaseCallingScreen
{
    [SerializeField] Button purchaseButton;
    [SerializeField] Button cancelButton;
    [SerializeField] TextMeshProUGUI needText;

    public override void OnStart(CallingManager manager)
    {
        base.OnStart(manager);

        purchaseButton.onClick.AddListener(() =>
        {
            UIManager.i.GetModal<PurchaseModal>().Open();
        });
        cancelButton.onClick.AddListener(() =>
        {
            Close();
        });
    }

    public override void Open(Uranaishi uranaishi)
    {
        base.Open(uranaishi);
        int point = uranaishi.callChargePerMin * 3;
        needText.text = $"ご利用には\n最低{point}pt(3分間の電話分)を\n所持している必要があります";
    }

    public override void Close()
    {
        base.Close();
    }
}
