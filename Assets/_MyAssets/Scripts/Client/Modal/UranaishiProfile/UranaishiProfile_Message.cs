using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranaishiProfile_Message : BaseUranaishiProfile
{
    [SerializeField] Text messageTxt;
    public override void OnStart()
    {
    }
    public override void OnOpen(Uranaishi uranaishi)
    {
        messageTxt.text = uranaishi.message;
    }
}
