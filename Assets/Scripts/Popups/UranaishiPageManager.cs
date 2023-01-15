using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UranaishiPageManager : BasePopup
{

    [SerializeField] Image iconImage;
    [SerializeField] Text nameTxt;


    public override void OnStart()
    {
        base.OnStart();
    }


    public void Open(Uranaishi uranaishi)
    {
        base.OpenAnim();

        iconImage.sprite = uranaishi.iconSr;
        nameTxt.text = uranaishi.name;
    }
}
