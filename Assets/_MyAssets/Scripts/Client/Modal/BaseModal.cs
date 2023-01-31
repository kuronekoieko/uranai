using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BaseModal : MonoBehaviour
{
    public enum ModalType
    {
        Horizontal,
        Vertical
    }
    [SerializeField] Button xButton;
    [SerializeField] Button returnButton;
    RectTransform rectTransform;
    Vector3 initPos;

    public virtual void OnStart()
    {
        rectTransform = GetComponent<RectTransform>();
        initPos = rectTransform.position;
        gameObject.SetActive(false);
        xButton.onClick.AddListener(OnClickXButton);
        returnButton.onClick.AddListener(OnClickReturnButton);
    }

    void OnClickXButton()
    {

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

        rectTransform
            .DOMoveX(Screen.width * 1.5f, 0.3f)
            .SetEase(Ease.OutCirc)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }


    protected virtual void OpenAnim(ModalType modalType = ModalType.Vertical)
    {
        xButton.gameObject.SetActive(modalType == ModalType.Vertical);
        returnButton.gameObject.SetActive(modalType != ModalType.Vertical);
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

        // 今いる自分の階層の一番下に移動して、一番手前に表示されます。
        transform.SetAsLastSibling();
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
        Vector3 pos = initPos;
        pos.x = Screen.width * 1.5f;
        rectTransform.position = pos;
        gameObject.SetActive(true);
        rectTransform
            .DOMoveX(initPos.x, 0.3f)
            .SetEase(Ease.OutCirc);
    }
}
