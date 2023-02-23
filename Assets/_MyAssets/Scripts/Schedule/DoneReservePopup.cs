using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DoneReservePopup : MonoBehaviour
{
    [SerializeField] Button confirmButton;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI startDateTimeText;
    [SerializeField] TextMeshProUGUI durationText;


    public void OnStart()
    {
        gameObject.SetActive(false);
        confirmButton.onClick.AddListener(() =>
        {
            UIManager.i.CloseAllModals(4);
            gameObject.SetActive(false);
        });
    }

    public void Open(Uranaishi uranaishi, DateTime startDateTime, int durationMin)
    {
        gameObject.SetActive(true);
        nameText.text = uranaishi.name;
        startDateTimeText.text = startDateTime.ToString("MM/dd(ddd) HH:mm");
        durationText.text = durationMin + "分";
    }
}
