using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CommonPopup : BasePopup
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] TextMeshProUGUI pButtonText;
    [SerializeField] TextMeshProUGUI nButtonText;
    public static CommonPopup i
    {
        get
        {
            if (_i == null) _i = FindObjectOfType<CommonPopup>(true);
            return _i;
        }
    }
    static CommonPopup _i;

    public void Show(
        string title,
        string message,
        string positive,
        string negative = "",
        Action onClickPositiveButton = null,
        Action onClickNegativeButton = null
    )
    {
        base.Open();
        if (onClickPositiveButton != null) base.onClickPositiveButton = onClickPositiveButton;
        if (onClickNegativeButton != null) base.onClickNegativeButton = onClickNegativeButton;
        titleText.text = title;
        messageText.text = message;
        pButtonText.text = positive;
        nButtonText.text = negative;
        positiveButton.gameObject.SetActive(!string.IsNullOrEmpty(positive));
        negativeButton.gameObject.SetActive(!string.IsNullOrEmpty(negative));
    }
}
