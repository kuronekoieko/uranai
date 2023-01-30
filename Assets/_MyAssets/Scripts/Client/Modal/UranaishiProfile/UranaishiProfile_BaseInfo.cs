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
        for (int i = 0; i < titleContentTexts.Count; i++)
        {
            titleContentTexts[i].gameObject.SetActive(false);
        }
    }

    public override void OnOpen(Uranaishi uranaishi)
    {
        titleContentTexts[0].SetTexts("得意分野", GetJoinedText(uranaishi.expertises));
        titleContentTexts[1].SetTexts("占術", GetJoinedText(uranaishi.divinations));


    }


    string GetJoinedText(string[] texts)
    {
        return string.Join("、", texts);
    }

}
