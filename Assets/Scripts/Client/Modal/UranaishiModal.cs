using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UranaishiModal : BaseModal
{

    [SerializeField] Image iconImage;
    [SerializeField] Text nameTxt;
    [SerializeField] LikeToggleController likeToggleController;


    public override void OnStart()
    {
        base.OnStart();
        likeToggleController.OnStart();
    }


    public void Open(Uranaishi uranaishi)
    {
        base.OpenAnim();
        likeToggleController.OnOpen(uranaishi);

        iconImage.sprite = uranaishi.iconSr;
        nameTxt.text = uranaishi.name;

    }
}
