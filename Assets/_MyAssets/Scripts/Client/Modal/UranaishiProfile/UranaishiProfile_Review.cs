using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UranaishiProfile_Review : BaseUranaishiProfile
{
    [SerializeField] TitleContentTexts titleContentTextOrigin;
    List<TitleContentTexts> titleContentTexts = new List<TitleContentTexts>();
    public override void OnStart()
    {
        titleContentTexts.Add(titleContentTextOrigin);
        for (int i = 0; i < 4; i++)
        {
            titleContentTexts.Add(Instantiate(titleContentTextOrigin, transform));
        }

    }

    public override void OnOpen(Uranaishi uranaishi)
    {
        for (int i = 0; i < titleContentTexts.Count; i++)
        {
            titleContentTexts[i].gameObject.SetActive(false);
        }

        var reviews = uranaishi.GetOrderedReviews(titleContentTexts.Count);

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
