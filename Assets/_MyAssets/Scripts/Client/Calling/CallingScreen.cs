using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CallingScreen : BaseCallingScreen
{
    [SerializeField] GameObject makingCallObj;
    [SerializeField] GameObject callingObj;
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI uranaishiNameText;
    [SerializeField] Button hangupButton;
    [SerializeField] TextMeshProUGUI leftTimeText;


    public override void OnStart(CallingManager callingManager)
    {
        base.OnStart(callingManager);
    }

    public override void Open(Uranaishi uranaishi)
    {
        base.Open(uranaishi);
        uranaishiNameText.text = uranaishi.name;
        uranaishi.GetIcon((sprite) =>
        {
            iconImage.sprite = sprite;
        });
        hangupButton.onClick.AddListener(() =>
        {
            callingManager.confirmHangUpPopup.Open(uranaishi);
        });
        makingCallObj.SetActive(true);
        callingObj.SetActive(false);

        // 仮
        Invoke("Call", 3f);
    }

    IEnumerator Timer()
    {
        float passedTime = 0;
        float maxSeconds = (float)SaveData.i.GetSumPoint() / (float)uranaishi.callChargePerSec * 60f;

        while (passedTime < maxSeconds)
        {
            var leftTimeSpan = new TimeSpan(0, 0, Mathf.CeilToInt(maxSeconds - passedTime));
            var mmss = leftTimeSpan.ToString(@"mm\:ss");

            leftTimeText.text = $"残り 約{mmss}";
            passedTime += Time.deltaTime;
            yield return null;
        }

        // 通話強制終了

    }

    void Call()
    {
        makingCallObj.SetActive(false);
        callingObj.SetActive(true);
        StartCoroutine(Timer());
    }

    public override void Close()
    {
        base.Close();
    }
}
