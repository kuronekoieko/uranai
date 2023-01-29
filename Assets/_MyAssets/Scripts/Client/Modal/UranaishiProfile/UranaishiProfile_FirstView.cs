using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranaishiProfile_FirstView : BaseUranaishiProfile
{
    [SerializeField] Image iconImage;
    [SerializeField] Text nameTxt;
    [SerializeField] LikeToggleController likeToggleController;


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
    }
}
