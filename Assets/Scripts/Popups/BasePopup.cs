using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BasePopup : MonoBehaviour
{
    [SerializeField] Button xButton;
    RectTransform rectTransform;
    Vector3 initPos;

    public virtual void OnStart()
    {
        rectTransform = GetComponent<RectTransform>();
        initPos = rectTransform.position;
        gameObject.SetActive(false);
        xButton.onClick.AddListener(OnClickXButton);
        Vector3 pos = initPos;
        pos.y = -Screen.height / 2f;
        rectTransform.position = pos;
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


    public virtual void OpenAnim()
    {
        gameObject.SetActive(true);
        rectTransform
            .DOMoveY(initPos.y, 0.3f)
            .SetEase(Ease.OutCirc);
        // 今いる自分の階層の一番下に移動して、一番手前に表示されます。
        transform.SetAsLastSibling();
    }
}
