using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallingManager : MonoBehaviour
{
    public ConfirmCallingPopup confirmCallingPopup;
    public CallingScreen callingScreen;
    public ConfirmHangUpPopup confirmHangUpPopup;
    public InputReviewScreen inputReviewScreen;

    public void OnStart()
    {
        Close();
        confirmCallingPopup.OnStart(this);
        callingScreen.OnStart(this);
        confirmHangUpPopup.OnStart(this);
        inputReviewScreen.OnStart(this);
    }

    public void Open(Uranaishi uranaishi)
    {
        gameObject.SetActive(true);

        confirmCallingPopup.Close();
        callingScreen.Close();
        confirmHangUpPopup.Close();
        inputReviewScreen.Close();

        confirmCallingPopup.Open(uranaishi);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        confirmCallingPopup.Close();
        callingScreen.Close();
        confirmHangUpPopup.Close();
        inputReviewScreen.Close();
    }
}
