using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwilioTestButton : MonoBehaviour
{
    TwilioTest twilioTest;
    [SerializeField] Button callButton;
    [SerializeField] Button dialButton;


    void Start()
    {
        twilioTest = new TwilioTest(
            twilioAccountSid: "AC63b5338a8c09ba458c2b5798517196bc",
            twilioAuthToken: "f73124266847896ecfdff34b81c296c1",
            twilioPhoneNo: ""
        );

        if (callButton) callButton.onClick.AddListener(OnClickCallBtn);
        if (dialButton) dialButton.onClick.AddListener(OnClickDialBtn);
    }

    void OnClickCallBtn()
    {
        // twilio番号からこの番号に着信
        twilioTest.Call("あああ", "+8109022784843");
    }


    void OnClickDialBtn()
    {
        twilioTest.Dial("+8109022784843");
    }


}
