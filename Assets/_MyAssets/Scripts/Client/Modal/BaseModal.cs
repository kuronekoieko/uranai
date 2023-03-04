using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using System;

public abstract class BaseModal : MonoBehaviour
{
    public enum ModalType
    {
        Horizontal,
        Vertical
    }
    [SerializeField] string title;
    [SerializeField] ScrollRect scrollRect;
    ModalCommon modalCommon;
    RectTransform rectTransform;
    Vector3 initPos;
    RectTransform underScreen;
    public Action onClose { get; set; }

    public virtual void OnStart()
    {
        modalCommon = GetComponentInChildren<ModalCommon>(true);
        rectTransform = GetComponent<RectTransform>();
        modalCommon.titleText.text = title;
        initPos = rectTransform.position;
        gameObject.SetActive(false);
        modalCommon.xButton.onClick.AddListener(OnClickXButton);
        modalCommon.returnButton.onClick.AddListener(OnClickReturnButton);
    }

    public void Clear()
    {
        rectTransform.position = initPos;
        gameObject.SetActive(false);
    }


    void OnClickXButton()
    {
        if (onClose != null) onClose.Invoke();
        rectTransform
            .DOMoveY(-Screen.height / 2f, 0.3f)
            .SetEase(Ease.OutCirc)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }

    void OnClickReturnButton()
    {
        if (onClose != null) onClose.Invoke();

        rectTransform
            .DOMoveX(Screen.width * 1.5f, 0.3f)
            .SetEase(Ease.OutCirc)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });


        if (underScreen)
        {
            underScreen
                .DOMoveX(Screen.width / 2f, 0.3f)
                .SetEase(Ease.OutCirc);
        }

    }

    protected virtual void OpenAnim(ModalType modalType = ModalType.Vertical)
    {
        onClose = null;
        //スクロールの一番上に行くように
        scrollRect.verticalNormalizedPosition = 1;
        // 今いる自分の階層の一番下に移動して、一番手前に表示されます。
        transform.SetAsLastSibling();

        modalCommon.xButton.gameObject.SetActive(modalType == ModalType.Vertical);
        modalCommon.returnButton.gameObject.SetActive(modalType != ModalType.Vertical);
        switch (modalType)
        {
            case ModalType.Vertical:
                VerticalAnim();
                break;
            case ModalType.Horizontal:
                HorizontalAnim();
                break;
            default:
                break;
        }


    }

    void VerticalAnim()
    {
        Vector3 pos = initPos;
        pos.y = -Screen.height / 2f;
        rectTransform.position = pos;
        gameObject.SetActive(true);
        rectTransform
            .DOMoveY(initPos.y, 0.3f)
            .SetEase(Ease.OutCirc);
    }

    void HorizontalAnim()
    {
        Transform underModalTf = null;
        for (int i = transform.parent.childCount - 1; i >= 0; i--)
        {
            var child = transform.parent.GetChild(i);
            if (child == transform) continue;
            if (child.gameObject.activeSelf == false) continue;
            if (child.CompareTag("Popup")) continue;
            underModalTf = child;
            break;
        }


        if (underModalTf)
        {
            this.underScreen = underModalTf.GetComponent<RectTransform>();
            underScreen
                .DOMoveX(Screen.width * 1f / 4f, 0.3f)
                .SetEase(Ease.OutCirc);
        }




        Vector3 pos = initPos;
        pos.x = Screen.width * 1.5f;
        rectTransform.position = pos;
        gameObject.SetActive(true);
        rectTransform
            .DOMoveX(initPos.x, 0.3f)
            .SetEase(Ease.OutCirc);
    }
}
