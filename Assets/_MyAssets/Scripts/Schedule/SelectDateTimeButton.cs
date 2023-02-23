using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class SelectDateTimeButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject availableObj;
    [SerializeField] GameObject notAvailableObj;

    Uranaishi uranaishi;

    public void OnInstantiate()
    {
        button.onClick.AddListener(OnClickSelectButton);
    }

    public void OnOpen(DateTime dateTime, Uranaishi uranaishi)
    {
        this.uranaishi = uranaishi;

        bool reserved = uranaishi.reserves.Any(a => a.reservedSDT.dateTime == dateTime);

        availableObj.SetActive(!reserved);
        notAvailableObj.SetActive(reserved);
        button.enabled = reserved;
    }

    void OnClickSelectButton()
    {

    }
}
