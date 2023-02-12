using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmHangUpPopup : MonoBehaviour
{
    [SerializeField] Button hangupButton;
    [SerializeField] Button cancelButton;
    CallingManager callingManager;

    public void OnStart(CallingManager callingManager)
    {
        this.callingManager = callingManager;
        Close();
        cancelButton.onClick.AddListener(() =>
        {
            Close();
        });
        hangupButton.onClick.AddListener(() =>
        {
            HangUp();
        });
    }

    public void Open(Uranaishi uranaishi)
    {
        gameObject.SetActive(true);

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    void HangUp()
    {
    }
}
