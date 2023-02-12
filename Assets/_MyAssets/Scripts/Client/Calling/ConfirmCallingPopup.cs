using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmCallingPopup : MonoBehaviour
{
    [SerializeField] Button callButton;
    [SerializeField] Button cancelButton;
    [SerializeField] TextMeshProUGUI chargeText;
    [SerializeField] TextMeshProUGUI timeText;

    CallingManager callingManager;

    public void OnStart(CallingManager callingManager)
    {
        this.callingManager = callingManager;
        Close();
        cancelButton.onClick.AddListener(() =>
        {
            callingManager.Close();
        });
    }

    public void Open(Uranaishi uranaishi)
    {
        gameObject.SetActive(true);
        callButton.onClick.AddListener(() => Call(uranaishi));
        chargeText.text = uranaishi.callChargePerSec.ToString("N0");

        float minuteF = (float)SaveData.i.GetSumPoint() / (float)uranaishi.callChargePerSec;
        int minuteInt = Mathf.FloorToInt(minuteF);
        timeText.text = minuteInt.ToString("N0");

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    void Call(Uranaishi uranaishi)
    {

    }
}
