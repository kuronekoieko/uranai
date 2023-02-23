using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ReserveModal : BaseModal
{
    [SerializeField] TextMeshProUGUI ownPointText;
    [SerializeField] TextMeshProUGUI durationText;
    [SerializeField] PurchaseButton purchaseButton;
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI uranaishiNameText;
    [SerializeField] TextMeshProUGUI chargeText;
    [SerializeField] TextMeshProUGUI dateText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Button confirmButton;

    Uranaishi uranaishi;
    DateTime dateTime;

    public override void OnStart()
    {
        base.OnStart();
        purchaseButton.onClose += () =>
        {
            ShowClientStatus();
        };
        confirmButton.onClick.AddListener(() =>
        {

        });
    }

    public void Open(DateTime dateTime, Uranaishi uranaishi)
    {
        base.OpenAnim(ModalType.Horizontal);
        this.uranaishi = uranaishi;
        this.dateTime = dateTime;

        ShowClientStatus();
        iconImage.sprite = null;
        uranaishi.GetIcon((sprite) =>
        {
            iconImage.sprite = sprite;
        });
        uranaishiNameText.text = uranaishi.name + " 先生";
        chargeText.text = $"1分 {uranaishi.callChargePerMin}pt";
        dateText.text = dateTime.ToString("MM月dd日 (ddd)");
        timeText.text = dateTime.ToString("HH:mm～");
    }

    void ShowClientStatus()
    {
        ownPointText.text = $"所持ポイント : {SaveData.i.GetSumPoint()}pt";
        var leftTimeSpan = new TimeSpan(0, SaveData.i.GetAvailableDurationMin(uranaishi.callChargePerMin), 0);
        var timeStr = leftTimeSpan.ToString(@"hh'時間'mm'分'");
        durationText.text = "鑑定可能時間 : " + timeStr;
    }
}
