using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScheduleModal : BaseModal
{
    [SerializeField] ScheduleSelectManager scheduleSelectManager;
    public override void OnStart()
    {
        base.OnStart();
        scheduleSelectManager.OnStart();
    }

    public void Open(Uranaishi uranaishi)
    {
        base.OpenAnim(ModalType.Horizontal);

        List<DateTime[]> dateTimeMatrix = new List<DateTime[]>();

        double span = 30;
        DateTime init = DateTime.Today.AddHours(9);
        DateTime last = DateTime.Today.AddDays(1).AddHours(4);


        for (DateTime i = init; i <= last; i = i.AddMinutes(span))
        {
            // Debug.Log(i);
            DateTime[] dateTimes = new DateTime[3];
            for (int j = 0; j < dateTimes.Length; j++)
            {
                dateTimes[j] = i;
            }
            dateTimeMatrix.Add(dateTimes);
        }

        scheduleSelectManager.ShowElement(dateTimeMatrix, uranaishi, (int)span);

    }
}
