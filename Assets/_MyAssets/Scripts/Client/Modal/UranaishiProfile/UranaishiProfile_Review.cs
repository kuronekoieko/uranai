using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UranaishiProfile_Review : BaseUranaishiProfile
{
    [SerializeField] ReviewManager reviewManager;
    [SerializeField] Button moreButton;
    readonly int showReviewCount = 6;

    public override void OnStart()
    {
        reviewManager.OnStart();

    }

    public override void OnOpen(Uranaishi uranaishi)
    {
        var reviews = uranaishi.GetOrderedReviews();
        var showingReviews = reviews.Take(showReviewCount).ToArray();

        reviewManager.ShowElements(showingReviews);

        bool isShowBoreButton = reviews.Count() > showReviewCount;

        moreButton.gameObject.SetActive(isShowBoreButton);
        if (isShowBoreButton == false) return;
        moreButton.transform.SetAsLastSibling();
        moreButton.onClick.AddListener(() =>
        {

            UIManager.i.GetModal<ReviewListModal>().Open(uranaishi);
        });
    }

}
