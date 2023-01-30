using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UranaishiModal : BaseModal
{


    [SerializeField] Transform contentTf;
    [SerializeField] ScrollRect scrollRect;
    BaseUranaishiProfile[] baseUranaishiProfiles;
    public static UranaishiModal i;

    public override void OnStart()
    {
        i = this;
        base.OnStart();
        StartLayoutElements();
    }

    void StartLayoutElements()
    {
        baseUranaishiProfiles = contentTf.GetComponentsInChildren<BaseUranaishiProfile>(true);
        foreach (var item in baseUranaishiProfiles)
        {
            item.gameObject.SetActive(true);
            item.OnStart();
        }
    }


    public void Open(Uranaishi uranaishi)
    {
        base.OpenAnim();
        //スクロールの一番上に行くように
        scrollRect.verticalNormalizedPosition = 1;
        foreach (var item in baseUranaishiProfiles)
        {
            item.OnOpen(uranaishi);
        }
    }
}
