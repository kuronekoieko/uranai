using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UranaishiModal : BaseModal
{


    [SerializeField] Transform contentTf;
    BaseUranaishiProfile[] baseUranaishiProfiles;


    public override void OnStart()
    {
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
        foreach (var item in baseUranaishiProfiles)
        {
            item.OnOpen(uranaishi);
        }
    }
}
