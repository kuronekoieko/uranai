using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
        var schedulesGroupList = uranaishi.schedules
            .Where(schedule => schedule.startSDT.IsFutureFromNow())
            .OrderBy(schedule => schedule.startSDT.dateTime)
            .GroupBy(schedule => schedule.startSDT.dateTime?.Date)
            .Take(titleContentTexts.Count);

        for (int i = 0; i < schedulesGroupList.Count(); i++)
        {
            var group = schedulesGroupList.ElementAt(i);
            string text = "";
            string dateText = "";
            foreach (var schedule in group)
            {
                text += schedule.startSDT.dateTime.ToStringIncludeEmpty("HH:mm")
                + "～" + schedule.endDT.ToString("HH:mm") + "\n";
                dateText = schedule.startSDT.dateTime.ToStringIncludeEmpty("M月d日(ddd)");
            }
            text = text.TrimEnd('\n');
            titleContentTexts[i].gameObject.SetActive(true);

            titleContentTexts[i].SetTexts(dateText, text);

        }


    }




}

