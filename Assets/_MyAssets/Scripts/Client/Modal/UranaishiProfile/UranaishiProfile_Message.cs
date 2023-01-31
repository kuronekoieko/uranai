using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranaishiProfile_Message : BaseUranaishiProfile
{
    [SerializeField] Text messageTxt;
    [SerializeField] Button twitterButton;
    [SerializeField] Button facebookButton;
    [SerializeField] Button otherURLButton;

    public override void OnStart()
    {

    }

    public override void OnOpen(Uranaishi uranaishi)
    {
        messageTxt.text = uranaishi.message;
        twitterButton.gameObject.SetActive(!string.IsNullOrEmpty(uranaishi.twitterURL));
        facebookButton.gameObject.SetActive(!string.IsNullOrEmpty(uranaishi.facebookURL));
        otherURLButton.gameObject.SetActive(!string.IsNullOrEmpty(uranaishi.otherURL));

        twitterButton.onClick.AddListener(() => Application.OpenURL(uranaishi.twitterURL));
        facebookButton.onClick.AddListener(() => Application.OpenURL(uranaishi.facebookURL));
        otherURLButton.onClick.AddListener(() => Application.OpenURL(uranaishi.otherURL));
    }
}
