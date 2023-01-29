using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UranaishiModal : BaseModal
{

    [SerializeField] Image iconImage;
    [SerializeField] Text nameTxt;
    [SerializeField] LikeToggleController likeToggleController;
    [SerializeField] Transform contentTf;


    public override void OnStart()
    {
        base.OnStart();
        likeToggleController.OnStart();
        StartLayoutElements();
    }

    void StartLayoutElements()
    {
        LayoutElement[] layoutElements = contentTf.GetComponentsInChildren<LayoutElement>(true);
        foreach (var item in layoutElements)
        {
            item.gameObject.SetActive(true);
        }
    }


    public void Open(Uranaishi uranaishi)
    {
        base.OpenAnim();
        likeToggleController.OnOpen(uranaishi);
        iconImage.sprite = null;
        uranaishi.GetIcon((sprite) =>
        {
            iconImage.sprite = sprite;
        });
        nameTxt.text = uranaishi.name;

    }
}
