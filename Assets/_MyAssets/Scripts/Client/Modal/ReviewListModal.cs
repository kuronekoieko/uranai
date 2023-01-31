using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ReviewListModal : BaseModal
{
    [SerializeField] ReviewManager reviewManager;
    [SerializeField] ReviewStarHighlight reviewStarHighlight;

    readonly int showReviewCount = 20;
    public static ReviewListModal i;

    public override void OnStart()
    {
        i = this;
        base.OnStart();
        reviewManager.OnStart();
    }

    public void Open(Uranaishi uranaishi)
    {
        base.OpenAnim();

        var reviews = uranaishi.GetOrderedReviews();

        reviewManager.ShowElements(reviews);

        reviewStarHighlight.HighlightStars(uranaishi.GetReviewAvr());
    }
}
