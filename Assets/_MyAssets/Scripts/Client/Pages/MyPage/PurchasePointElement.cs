using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchasePointElement : ObjectPoolingElement
{
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI omakeText;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] Button button;
    ChargeInfo chargeInfo;

    public override void Initialize()
    {
        button.onClick.AddListener(OnClickPurchaseButton);
    }

    public void Show(ChargeInfo chargeInfo)
    {
        this.chargeInfo = chargeInfo;
        pointText.text = chargeInfo.point.ToString();
        omakeText.text = $"無料ポイント{chargeInfo.omake}";
        costText.text = "￥" + chargeInfo.cost.ToString();
    }

    void OnClickPurchaseButton()
    {
        SaveData.i.purchasedPoint += chargeInfo.point;
        SaveDataManager.i.Save();
    }

}
