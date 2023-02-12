using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputReviewScreen : BaseCallingScreen
{
    [SerializeField] InputReviewStarManager inputReviewStarManager;
    [SerializeField] Button sendButton;


    public override void OnStart(CallingManager callingManager)
    {
        base.OnStart(callingManager);

        inputReviewStarManager.OnStart();
        sendButton.onClick.AddListener(() =>
        {

        });

    }

    public override void Open(Uranaishi uranaishi)
    {
        base.Open(uranaishi);

    }

    public override void Close()
    {
        base.Close();
    }
}
