using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranaishiButton : ObjectPoolingElement
{
    [SerializeField] Button button;
    [SerializeField] Image iconImage;
    [SerializeField] Text nameTxt;
    [SerializeField] Text divinationsText;
    [SerializeField] Text statusText;
    [SerializeField] ReviewElement reviewElement;

    public RectTransform rectTransform;
    Uranaishi uranaishi;

    public override void Initialize()
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
        Review review = uranaishi.GetFirstReview();
        if (review != null)
        {
            reviewElement.ShowData(review, 3);
        }
        else
        {
            reviewElement.gameObject.SetActive(false);
        }


        statusText.text = uranaishi.GetStatusDisplayName();
    }

}
