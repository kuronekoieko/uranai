using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class UranaishiProfile_Schedule : BaseUranaishiProfile
{
    [SerializeField] TitleContentTexts titleContentTextOrigin;
    List<TitleContentTexts> titleContentTexts = new List<TitleContentTexts>();
    public override void OnStart()
    {
        titleContentTexts.Add(titleContentTextOrigin);
        for (int i = 0; i < 4; i++)
        {
            titleContentTexts.Add(Instantiate(titleContentTextOrigin, transform));
        }
    }

    public override void OnOpen(Uranaishi uranaishi)
    {
        for (int i = 0; i < titleContentTexts.Count; i++)
        {
            titleContentTexts[i].gameObject.SetActive(false);
        }
        Period closedPeriod = new Period();
        closedPeriod.startDT = new DateTime(2000, 1, 1, 5, 0, 0);
        closedPeriod.endDT = new DateTime(2000, 1, 1, 9, 0, 0);


        var freeDateTimes = uranaishi.schedules
            .Where(schedule => schedule.startSDT.IsFutureFromNow())
            .Where(schedule => schedule.scheduleStatus == ScheduleStatus.Free)
            .Where(schedule => schedule.startSDT.dateTime.Value.TimeOfDay < closedPeriod.startDT.Value.TimeOfDay
                || schedule.startSDT.dateTime.Value.TimeOfDay > closedPeriod.endDT.Value.TimeOfDay)
            .OrderBy(schedule => schedule.startSDT.dateTime)
            .Select(schedule => schedule.startSDT.dateTime)
            .ToArray();


        Period period = null;
        List<Period> periods = new List<Period>();
        foreach (var startDT in freeDateTimes)
        {

            if (period == null || period.endDT != startDT)
            {
                period = new Period();
                period.startDT = startDT;
                period.endDT = startDT.Value.AddMinutes(Constant.Instance.reserveDurationMin);
                periods.Add(period);
                continue;
            }

            period.endDT = period.endDT.Value.AddMinutes(Constant.Instance.reserveDurationMin);
        }


        var periodGroupList = periods
            .GroupBy(period => period.startDT?.Date)
            .Take(titleContentTexts.Count);


        for (int i = 0; i < periodGroupList.Count(); i++)
        {
            var group = periodGroupList.ElementAt(i);
            string text = "";
            string dateText = "";
            foreach (var p in group)
            {
                text += p.startDT.ToStringIncludeEmpty("HH:mm")
                + "～" + p.endDT.ToStringIncludeEmpty("HH:mm") + "\n";
                dateText = p.startDT.ToStringIncludeEmpty("M月d日(ddd)");
            }
            text = text.TrimEnd('\n');
            titleContentTexts[i].gameObject.SetActive(true);

            titleContentTexts[i].SetTexts(dateText, text);

        }


    }



    class Period
    {
        public DateTime? startDT;
        public DateTime? endDT;
    }




}

