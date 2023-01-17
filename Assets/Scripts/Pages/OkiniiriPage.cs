using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UniRx;

public class OkiniiriPage : BasePageManager
{

    [SerializeField] UranaishiButtonManager uranaishiButtonManager;

    public override void OnStart()
    {
        base.SetPageAction(Page.Okiniiri);
        uranaishiButtonManager.OnStart();

        ShowLikedList();

        this.ObserveEveryValueChanged(listCount => SaveData.i.likedUranaishiIdList.Count)
            .Where(listCount => UIManager.i.activePage == Page.Okiniiri)
            .Subscribe(listCount => ShowLikedList())
            .AddTo(this.gameObject);
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
