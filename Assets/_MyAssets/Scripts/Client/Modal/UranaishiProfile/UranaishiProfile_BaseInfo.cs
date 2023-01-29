using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranaishiProfile_BaseInfo : BaseUranaishiProfile
{
    [SerializeField] TitleContentTexts titleContentTextOrigin;
    List<TitleContentTexts> titleContentTexts = new List<TitleContentTexts>();

    public override void OnStart()
    {
        titleContentTexts.Add(titleContentTextOrigin);
        for (int i = 0; i < 4; i++)
        {
            titleContentTexts.Add(Instantiate(titleContentTextOrigin, transform));
        }

        titleContentTexts[0].titleTxt.value.text = "得意分野";

        string tmp = "";
        foreach (var item in Constant.Instance.expertises.value)
        {
            tmp += item + "、";
        }
        titleContentTexts[0].contentTxt.value.text = tmp;

        titleContentTexts[1].titleTxt.value.text = "占術";
        tmp = "";
        foreach (var item in Constant.Instance.divinations)
        {
            tmp += item.value + "、";
        }
        titleContentTexts[1].contentTxt.value.text = "";
    }
    public override void OnOpen(Uranaishi uranaishi)
    {
    }
}
