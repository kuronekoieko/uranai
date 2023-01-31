using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ReviewListModal : BaseModal
{
    [SerializeField] TitleContentTexts titleContentTextOrigin;
    [SerializeField] Transform contentTf;

    List<TitleContentTexts> titleContentTexts = new List<TitleContentTexts>();
    readonly int showReviewCount = 20;
    public static ReviewListModal i;

    public override void OnStart()
    {
        i = this;
        base.OnStart();

        for (int i = 0; i < showReviewCount; i++)
        {
            if (i == 0)
            {
                titleContentTexts.Add(titleContentTextOrigin);
            }
            else
            {
                titleContentTexts.Add(Instantiate(titleContentTextOrigin, contentTf));
            }
        }
    }

    public void Open(Uranaishi uranaishi)
    {
        base.OpenAnim();

        var reviews = uranaishi.GetOrderedReviews();
        for (int i = 0; i < titleContentTexts.Count; i++)
        {
            titleContentTexts[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < reviews.Length; i++)
        {
            titleContentTexts[i].gameObject.SetActive(true);
            titleContentTexts[i].contentTxt.value.text = reviews[i].text;
            titleContentTexts[i].titleTxt.value.text = reviews[i].GetTitleText();
            titleContentTexts[i].reviewStarHighlight.HighlightStars(reviews[i].starCount);
            titleContentTexts[i].pickUpImage.value.gameObject.SetActive(reviews[i].isPickUp);
        }
    }
}
