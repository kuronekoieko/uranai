using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public static class Utils
{

    public static Review[] OrderForKuchikomi(Uranaishi[] uranaishis)
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

        Review[] reviews = new Review[0];
        foreach (var group in groups)
        {
            IOrderedEnumerable<Review> a = null;
            switch (group.Key)
            {
                case UranaishiStatus.Counseling:
                    a = group.OrderBy(i => Guid.NewGuid());
                    break;
                case UranaishiStatus.Waiting:
                    a = group.OrderBy(i => Guid.NewGuid());
                    break;
                case UranaishiStatus.Closed:
                    a = group.OrderByDescending(i => i.writtenDate.dateTime);
                    break;
                case UranaishiStatus.DatTime:
                    a = group.OrderByDescending(i => i.writtenDate.dateTime);
                    break;
                default:
                    a = group.OrderByDescending(i => i.writtenDate.dateTime);
                    break;
            }
            if (a != null) reviews = reviews.Concat(a).ToArray();
        }
        return reviews;
    }

}
