using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class BasePopup : MonoBehaviour
{
    [SerializeField] Button negativeButton;
    [SerializeField] Button positiveButton;

    public Action onClickNegativeButton { get; set; }
    public Action onClickPositiveButton { get; set; }


    public virtual void OnStart()
    {
        gameObject.SetActive(false);
        negativeButton.onClick.AddListener(OnClickNegativeButton);
        positiveButton.onClick.AddListener(OnClickPositiveButton);
    }

    public void Close()
    {
        OnClose();
    }

    void OnClose()
    {
        gameObject.SetActive(false);
        onClickNegativeButton = null;
        onClickPositiveButton = null;
    }


    void OnClickNegativeButton()
    {
        if (onClickNegativeButton != null) onClickNegativeButton.Invoke();
        OnClose();
    }

    void OnClickPositiveButton()
    {
        if (onClickPositiveButton != null) onClickPositiveButton.Invoke();
        OnClose();
    }

    protected virtual void Open()
    {
        // 今いる自分の階層の一番下に移動して、一番手前に表示されます。
        transform.SetAsLastSibling();

        gameObject.SetActive(true);
    }

}
