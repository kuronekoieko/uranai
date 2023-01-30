using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UranaishiProfile_FirstView : BaseUranaishiProfile
{
    [SerializeField] Image iconImage;
    [SerializeField] Text nameTxt;
    [SerializeField] LikeToggleController likeToggleController;
    [SerializeField] Text statusTxt;
    [SerializeField] Text chargeTxt;
    [SerializeField] ReviewStarHighlight reviewStarHighlight;
    [SerializeField] Text messageTxt;

    public override void OnStart()
    {
        likeToggleController.OnStart();
    }

    public override void OnOpen(Uranaishi uranaishi)
    {
        likeToggleController.OnOpen(uranaishi);
        iconImage.sprite = null;
        uranaishi.GetIcon((sprite) =>
        {
            iconImage.sprite = sprite;
        });
        nameTxt.text = uranaishi.name;
        statusTxt.text = uranaishi.GetStatusDisplayName();
        chargeTxt.text = uranaishi.callChargePerSec + "円/1分";

        double avr;
        if (uranaishi.reviews.Count() == 0)
        {
            avr = 0;
        }
        else
        {
            avr = uranaishi.reviews.Select(r => r.starCount).Average();
        }
        reviewStarHighlight.HighlightStars((float)avr);
        messageTxt.SetLimitedText(uranaishi.message, 3);
    }
}
