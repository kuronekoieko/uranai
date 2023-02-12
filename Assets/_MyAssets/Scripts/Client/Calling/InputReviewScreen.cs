using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputReviewScreen : MonoBehaviour
{
    [SerializeField] InputReviewStarManager inputReviewStarManager;
    [SerializeField] Button sendButton;
    CallingManager callingManager;
    Uranaishi uranaishi;

    public void OnStart(CallingManager callingManager)
    {
        this.callingManager = callingManager;
        Close();
        inputReviewStarManager.OnStart();
        sendButton.onClick.AddListener(() =>
        {

        });

    }

    public void Open(Uranaishi uranaishi)
    {
        this.uranaishi = uranaishi;

        gameObject.SetActive(true);

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
