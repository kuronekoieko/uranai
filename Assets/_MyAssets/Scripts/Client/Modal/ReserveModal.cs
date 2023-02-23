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
    [SerializeField] PurchasePointsPopup purchasePointsPopup;
    [SerializeField] RequirePushNotificationPopup requirePushNotificationPopup;

    int[] reservableMins;

    Uranaishi uranaishi;
    DateTime dateTime;
    int selectedMin;
    bool isEnoughPoint => SaveData.i.GetSumPoint() > selectedMin * uranaishi.callChargePerMin;


    public override void OnStart()
    {
        base.OnStart();
        doneReservePopup.OnStart();
        purchasePointsPopup.OnStart();
        requirePushNotificationPopup.OnStart();

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

        selectedMin = reservableMins[index];

        if (!isEnoughPoint)
        {
            purchasePointsPopup.Open(uranaishi, selectedMin);
            purchasePointsPopup.onReturnFromPurchase = OnReturnFromPurchase;
            return;
        }


        if (!LocalPushNotification.Enabled)
        {
            // プッシュ通知がオフのときのポップアップ
            requirePushNotificationPopup.Open();
            return;
        }

        ConfirmReserve();

    }

    void OnReturnFromPurchase()
    {
        ShowClientStatus();
        //isEnoughPoint = true;
        if (isEnoughPoint == false)
        {
            purchasePointsPopup.Open(uranaishi, selectedMin);
        }
    }


    void ConfirmReserve()
    {
        doneReservePopup.Open(uranaishi, dateTime, selectedMin);
        SettingPush();
    }

    private void SettingPush()
    {
        //　Androidチャンネルの登録
        //LocalPushNotification.RegisterChannel(引数1,引数２,引数３);
        //引数１ Androidで使用するチャンネルID なんでもいい LocalPushNotification.AddSchedule()で使用する
        //引数2　チャンネルの名前　なんでもいい　アプリ名でも入れておく
        //引数3　通知の説明 なんでもいい　自分がわかる用に書いておくもの　
        LocalPushNotification.RegisterChannel("channelId", "PushTest", "通知の説明");

        //通知のクリア
        LocalPushNotification.AllClear();

        // プッシュ通知の登録
        //LocalPushNotification.AddSchedule(引数１,引数2,引数3,引数4,引数5);
        //引数１ プッシュ通知のタイトル
        //引数2　通知メッセージ
        //引数3　表示するバッジの数(バッジ数はiOSのみ適用の様子 Androidで数値を入れても問題無い)
        //引数4　何秒後に表示させるか？
        //引数5　Androidで使用するチャンネルID　「Androidチャンネルの登録」で登録したチャンネルIDと合わせておく
        //注意　iOSは45秒経過後からしかプッシュ通知が表示されない  

        //https://www.fenet.jp/dotnet/column/language/8364/
        TimeSpan interval = dateTime - DateTime.Now;
        int sec = (int)interval.TotalSeconds;
        LocalPushNotification.AddSchedule("予約時間になりました。", "予約時間になりました。", 1, sec, "channelId");
    }
}
