using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ScheduleSelectManager : ObjectPooling<RowElement>
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public void ShowElement(List<DateTime[]> dateTimeMatrix, Uranaishi uranaishi, int span)
    {
        base.Clear();
        for (int i = 0; i < dateTimeMatrix.Count; i++)
        {
            var element = base.GetInstance();
            // element.Show(histories[i]);
            element.Show(dateTimeMatrix[i], uranaishi, span);
        }
    }

    public void AddElement(History[] histories)
    {
        for (int i = 0; i < histories.Length; i++)
        {
            var element = base.GetInstance();
            // element.Show(histories[i]);
        }
    }
}
