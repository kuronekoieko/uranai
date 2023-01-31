using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewManager : ObjectPooling<ReviewElement>
{
    public void OnStart()
    {
        base.Initialize();
    }

    public void ShowElements(Review[] reviews)
    {
        base.Clear();

        for (int i = 0; i < reviews.Length; i++)
        {
            var reviewElement = base.GetInstance();
            reviewElement.ShowData(reviews[i]);
        }
    }
}
