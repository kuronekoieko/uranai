using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class OkiniiriPage : BasePageManager
{

    [SerializeField] UranaishiButtonManager uranaishiButtonManager;

    public override void OnStart()
    {
        base.SetPageAction(Page.Okiniiri);
        uranaishiButtonManager.OnStart();

        ShowLikedList();
    }

    public override void OnUpdate()
    {
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    protected override void OnOpen()
    {
        gameObject.SetActive(true);
        ShowLikedList();
    }


    void ShowLikedList()
    {
        List<Uranaishi> likedList = new List<Uranaishi>();


        foreach (var uranaishi in UranaishiSO.Instance.uranaishiAry)
        {
            foreach (var likedUranaishiId in SaveData.i.likedUranaishiIdList)
            {
                if (uranaishi.id == likedUranaishiId)
                {
                    likedList.Add(uranaishi);
                }
            }
        }

        uranaishiButtonManager.ShowButtons(likedList.ToArray());
    }
}
