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
        for (int i = 0; i < titleContentTexts.Count; i++)
        {
            titleContentTexts[i].gameObject.SetActive(false);
        }
    }

    public override void OnOpen(Uranaishi uranaishi)
    {
        var schedulesGroupList = uranaishi.schedules
            //.Where(schedule => schedule.IsFutureFromNow())
            .OrderBy(schedule => schedule.start.GetString())
            .GroupBy(schedule => schedule.start.GetDateString());
        //.Take(5);


        foreach (var group in schedulesGroupList)
        {
            string text = "";
            foreach (var schedule in group)
            {

                text += schedule.start.hour + ":" + schedule.start.minute
                + "～" + schedule.end.hour + ":" + schedule.end.minute + "\n";
            }

        }

        for (int i = 0; i < schedulesGroupList.Count(); i++)
        {
            var group = schedulesGroupList.ElementAt(i);
            string text = "";
            string dateText = "";
            foreach (var schedule in group)
            {
                text += schedule.start.GetDateTime().ToString("hh:mm")
                + "～" + schedule.end.GetDateTime().ToString("hh:mm") + "\n";
                dateText = schedule.start.GetDateTime().ToString("M月d日(ddd)");
            }

            titleContentTexts[i].gameObject.SetActive(true);
            titleContentTexts[i].titleTxt.value.text = dateText;
            titleContentTexts[i].contentTxt.value.text = text;

        }


    }




}

