using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallingScreen : MonoBehaviour
{
    CallingManager callingManager;

    public void OnStart(CallingManager callingManager)
    {
        this.callingManager = callingManager;
        Close();
    }

    public void Open(Uranaishi uranaishi)
    {
        gameObject.SetActive(true);

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
