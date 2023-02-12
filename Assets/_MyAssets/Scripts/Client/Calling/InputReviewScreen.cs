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
        myPointText.text = $"所持ポイント : {SaveData.i.GetSumPoint()}pt";
    }

    public override void Close()
    {
        base.Close();
    }

    void SendData()
    {
        Review review = new Review();
        review.starCount = inputReviewStarManager.starCount;
        review.text = reviewTextIF.text;



        uranaishi.reviews.Add(review);


        SaveData.i.ConsumePoints(giftPoint);
        SaveDataManager.i.Save();
    }
}
