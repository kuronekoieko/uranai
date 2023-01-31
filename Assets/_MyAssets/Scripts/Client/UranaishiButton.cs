using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranaishiButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image iconImage;
    [SerializeField] Text nameTxt;
    [SerializeField] Text divinationsText;
    [SerializeField] Text statusText;
    [SerializeField] TitleContentTexts titleContentTexts;
    [SerializeField] ReviewStarHighlight reviewStarHighlight;

    public RectTransform rectTransform;
    Uranaishi uranaishi;

    public void Initialize()
    {
        button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        UranaishiModal.i.Open(uranaishi);
    }

    public void ShowData(Uranaishi uranaishi)
    {
        this.uranaishi = uranaishi;
        iconImage.sprite = null;
        uranaishi.GetIcon((sprite) =>
        {
            iconImage.sprite = sprite;
        });
        nameTxt.text = uranaishi.name;
        divinationsText.text = uranaishi.expertises.GetJoinedKeywords();
        titleContentTexts.SetTexts("", "");
        Review review = uranaishi.GetFirstReview();
        if (review != null)
        {
            titleContentTexts.SetTexts(review.GetTitleText(), review.text, 3);
        }
        reviewStarHighlight.HighlightStars(uranaishi.GetReviewAvr());
        statusText.text = uranaishi.GetStatusDisplayName();
    }

}
