using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UranaishiModal : BaseModal
{


    [SerializeField] Transform contentTf;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] CallUranaishiButton callUranaishiButton;
    [SerializeField] Button scheduleButton;
    BaseUranaishiProfile[] baseUranaishiProfiles;
    public static UranaishiModal i;
    Uranaishi uranaishi;

    public override void OnStart()
    {
        i = this;
        base.OnStart();
        StartLayoutElements();
        callUranaishiButton.OnStart();
        scheduleButton.onClick.AddListener(OnClickScheduleButton);
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
        this.uranaishi = uranaishi;
        base.OpenAnim();
        //スクロールの一番上に行くように
        scrollRect.verticalNormalizedPosition = 1;
        foreach (var item in baseUranaishiProfiles)
        {
            item.OnOpen(uranaishi);
        }
        callUranaishiButton.OnOpen(uranaishi);
    }



    void OnClickScheduleButton()
    {

    }
}
