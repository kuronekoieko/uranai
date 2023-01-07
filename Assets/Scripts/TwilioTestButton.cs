using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwilioTestButton : MonoBehaviour
{
    TwilioTest twilioTest;
    Button button;

    void Start()
    {
        twilioTest = new TwilioTest(
            twilioAccountSid: "AC63b5338a8c09ba458c2b5798517196bc",
            twilioAuthToken: "f73124266847896ecfdff34b81c296c1",
            twilioPhoneNo: "8109022784843"
        );

        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        twilioTest.Call("あああ", "8109022784843");
    }

}
