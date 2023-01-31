using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UranaishiProfile_Review : BaseUranaishiProfile
{
    [SerializeField] TitleContentTexts titleContentTextOrigin;
    [SerializeField] Button moreButton;
    List<TitleContentTexts> titleContentTexts = new List<TitleContentTexts>();
    readonly int showReviewCount = 6;

    public override void OnStart()
    {
        for (int i = 0; i < showReviewCount; i++)
        {
            if (i == 0)
            {
                titleContentTexts.Add(titleContentTextOrigin);
            }
            else
            {
                titleContentTexts.Add(Instantiate(titleContentTextOrigin, transform));
            }
        }

    }

    public override void OnOpen(Uranaishi uranaishi)
    {
        for (int i = 0; i < titleContentTexts.Count; i++)
        {
            titleContentTexts[i].gameObject.SetActive(false);
        }

        var reviews = uranaishi.GetOrderedReviews();
        var showingReviews = reviews.Take(showReviewCount).ToArray();

        for (int i = 0; i < showingReviews.Length; i++)
        {
            titleContentTexts[i].gameObject.SetActive(true);
            titleContentTexts[i].contentTxt.value.text = reviews[i].text;
            titleContentTexts[i].titleTxt.value.text = reviews[i].GetTitleText();
            titleContentTexts[i].reviewStarHighlight.HighlightStars(reviews[i].starCount);
            titleContentTexts[i].pickUpImage.value.gameObject.SetActive(reviews[i].isPickUp);
        }

        bool isShowBoreButton = reviews.Count() > showReviewCount;

        moreButton.gameObject.SetActive(isShowBoreButton);
        if (isShowBoreButton == false) return;
        moreButton.transform.SetAsLastSibling();
        moreButton.onClick.AddListener(() =>
        {

        });
    }

}
