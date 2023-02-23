using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Linq;

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
    [SerializeField] Toggle[] durationToggles;
    [SerializeField] DoneReservePopup doneReservePopup;
    int[] reservableMins;

    Uranaishi uranaishi;
    DateTime dateTime;

    public override void OnStart()
    {
        base.OnStart();
        doneReservePopup.OnStart();

        reservableMins = new int[durationToggles.Length];
        for (int i = 0; i < reservableMins.Length; i++)
        {
            reservableMins[i] = Constant.Instance.reserveDurationMin * (i + 1);
            durationToggles[i].GetComponentInChildren<TextMeshProUGUI>().text = reservableMins[i] + "分";
        }

        purchaseButton.onClose += ShowClientStatus;
        confirmButton.onClick.AddListener(OnClickConfirmButton);
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

    void OnClickConfirmButton()
    {
        int index = durationToggles
           .Select((t, i) => new { Content = t, Index = i })
           .Where(ano => ano.Content.isOn)
           .Select(t => t.Index)
           .FirstOrDefault();

        int selectedMin = reservableMins[index];

        // bool isEnoughPoint = SaveData.i.GetSumPoint() > Constant.Instance.reserveDurationMin * uranaishi.callChargePerMin;
        bool isEnoughPoint = SaveData.i.GetSumPoint() > selectedMin * uranaishi.callChargePerMin;


        if (isEnoughPoint)
        {
            doneReservePopup.Open(uranaishi, dateTime, selectedMin);
            ConfirmReserve();
        }
        else
        {
            Debug.Log("ポイント購入のポップアプ");
        }
    }


    void ConfirmReserve()
    {

    }
}
