using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RowElement : ObjectPoolingElement
{
    [SerializeField] SelectDateTimeButton[] selectDateTimeButtons;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] LayoutElement lightBorderLE;
    [SerializeField] LayoutElement boldBorderLE;


    public override void OnInstantiate()
    {
        for (int i = 0; i < selectDateTimeButtons.Length; i++)
        {
            selectDateTimeButtons[i].OnInstantiate();
        }
    }

    public void Show(DateTime dateTime, bool isLastOfTheHour)
    {
        timeText.text = dateTime.ToShortTimeString();

        lightBorderLE.gameObject.SetActive(!isLastOfTheHour);
        boldBorderLE.gameObject.SetActive(isLastOfTheHour);

        for (int i = 0; i < selectDateTimeButtons.Length; i++)
        {
            selectDateTimeButtons[i].OnOpen();
        }
    }



}
