using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallingManager : MonoBehaviour
{
    public ConfirmCallingPopup confirmCallingPopup;
    public CallingScreen callingScreen;
    public ConfirmHangUpPopup confirmHangUpPopup;

    public void OnStart()
    {
        Close();
        confirmCallingPopup.OnStart(this);
        callingScreen.OnStart(this);
        confirmHangUpPopup.OnStart(this);
    }

    public void Open(Uranaishi uranaishi)
    {
        gameObject.SetActive(true);

        confirmCallingPopup.Open(uranaishi);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
