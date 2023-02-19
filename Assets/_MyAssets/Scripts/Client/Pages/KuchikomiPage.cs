using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KuchikomiPage : BasePageManager
{
    [SerializeField] KuchikomiManager kuchikomiManager;
    public override void OnStart()
    {
        base.SetPageAction(Page.Kuchikomi);
        kuchikomiManager.OnStart();



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


        Review[] reviews = UIManager.i.uranaishiAry
        .SelectMany(uranaishi => uranaishi.reviews)
        .Where(review => review.isPickUp)
        .OrderByDescending(review => review.writtenDate.dateTime)
        .ToArray();

        foreach (var item in reviews)
        {
            Debug.Log(item.writtenDate.dateTime);
        }

        kuchikomiManager.ShowElement(reviews);

    }
}
