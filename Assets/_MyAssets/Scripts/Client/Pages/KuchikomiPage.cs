using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class KuchikomiPage : BasePageManager
{
    [SerializeField] KuchikomiManager kuchikomiManager;
    public override void OnStart()
    {
        base.SetPageAction(Page.Kuchikomi);
        kuchikomiManager.OnStart();
        Order(UIManager.i.uranaishiAry);
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


    }


    void Order(Uranaishi[] uranaishis)
    {
        var priorityDic = new Dictionary<UranaishiStatus, int>
        {
            {UranaishiStatus.Waiting,100},
            {UranaishiStatus.Counseling,90},
            {UranaishiStatus.DatTime,10},
            {UranaishiStatus.Closed,0},
        };


        var groups = uranaishis
        .SelectMany(uranaishi => uranaishi.reviews)
        .Where(review => review.isPickUp)
        .GroupBy(review => review.uranaishi.status)
        .OrderByDescending(g => priorityDic[g.Key]);


        foreach (var group in groups)
        {
            Review[] reviews;
            switch (group.Key)
            {
                case UranaishiStatus.Counseling:
                    reviews = group.OrderBy(i => Guid.NewGuid()).ToArray();
                    break;
                case UranaishiStatus.Waiting:
                    reviews = group.OrderBy(i => Guid.NewGuid()).ToArray();
                    break;
                case UranaishiStatus.Closed:
                    reviews = group.OrderByDescending(i => i.writtenDate.dateTime).ToArray();
                    break;
                case UranaishiStatus.DatTime:
                    reviews = group.OrderByDescending(i => i.writtenDate.dateTime).ToArray();
                    break;
                default:
                    reviews = group.OrderByDescending(i => i.writtenDate.dateTime).ToArray();
                    break;
            }
            kuchikomiManager.AddElement(reviews);

        }
    }

}
