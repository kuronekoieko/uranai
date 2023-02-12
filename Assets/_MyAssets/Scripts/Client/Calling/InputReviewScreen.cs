using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputReviewScreen : BaseCallingScreen
{
    [SerializeField] InputReviewStarManager inputReviewStarManager;
    [SerializeField] Button sendButton;
    [SerializeField] TMP_InputField reviewTextIF;
    [SerializeField] TMP_InputField giftIF;
    [SerializeField] TextMeshProUGUI myPointText;
    [SerializeField] Button purchaseButton;
    int giftPoint;

    public override void OnStart(CallingManager callingManager)
    {
        base.OnStart(callingManager);

        inputReviewStarManager.OnStart();
        sendButton.onClick.AddListener(() =>
        {
            SendData();
        });
        purchaseButton.onClick.AddListener(() =>
        {
            PurchaseModal.i.Open();
        });

        giftIF.contentType = TMP_InputField.ContentType.IntegerNumber;
        giftIF.onValueChanged.AddListener((text) =>
        {
            if (int.TryParse(text, out giftPoint))
            {
                giftPoint = Mathf.Clamp(giftPoint, 0, SaveData.i.GetSumPoint());
            }
            giftIF.text = giftPoint.ToString();
        });
    }

    public override void Open(Uranaishi uranaishi)
    {
        base.Open(uranaishi);

        // TODO : アプリ落とす対策に、リアルタイムにポイントを削るようにする
        float pointF = manager.callingScreen.passedTimeSec * (float)uranaishi.callChargePerMin / 60f;
        int point = Mathf.CeilToInt(pointF);
        SaveData.i.ConsumePoints(point);
        SaveDataManager.i.Save();

        myPointText.text = $"所持ポイント : {SaveData.i.GetSumPoint()}pt";
    }

    public override void Close()
    {
        base.Close();
    }

    async void SendData()
    {
        Review review = new Review
        (
            starCount: inputReviewStarManager.starCount,
            text: reviewTextIF.text
        );
        // 他のパラメーターの入力はどうするか？



        uranaishi.reviews.Add(review);

        // 占い師が同時に操作してると上書きされる可能性があるので、レビューだけ書き換えたい
        await FirebaseDatabaseManager.i.SetUserData(uranaishi);

        SaveData.i.ConsumePoints(giftPoint);
        SaveDataManager.i.Save();

        CBNativeDialog.Instance.Show(title: "",
                    message: "評価を投稿します。よろしいですか？",
                    positiveButtonTitle: "はい",
                    positiveButtonAction: () => { CloseAllModals(); },
                    negativeButtonTitle: "いいえ",
                    negativeButtonAction: () => { Debug.Log("CANCEL"); });

        if (Application.isEditor)
        {
            CloseAllModals();
        }

    }

    void CloseAllModals()
    {
        base.manager.Close();
        UIManager.i.CloseAllModals(Page.Rireki);
    }
}
