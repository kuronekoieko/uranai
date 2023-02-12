using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmCallingPopup : BaseCallingScreen
{
    [SerializeField] Button callButton;
    [SerializeField] Button cancelButton;
    [SerializeField] TextMeshProUGUI chargeText;
    [SerializeField] TextMeshProUGUI timeText;

    public override void OnStart(CallingManager callingManager)
    {
        base.OnStart(callingManager);

        cancelButton.onClick.AddListener(() =>
        {
            callingManager.Close();
        });
    }

    public override void Open(Uranaishi uranaishi)
    {
        base.Open(uranaishi);

        callButton.onClick.AddListener(() => OnClickCallButton(uranaishi));
        chargeText.text = uranaishi.callChargePerSec.ToString("N0");

        float minuteF = (float)SaveData.i.GetSumPoint() / (float)uranaishi.callChargePerSec;
        int minuteInt = Mathf.FloorToInt(minuteF);
        timeText.text = minuteInt.ToString("N0");

    }

    public override void Close()
    {
        base.Close();
    }

    void OnClickCallButton(Uranaishi uranaishi)
    {
        base.manager.callingScreen.Open(uranaishi);
    }
}
