using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LikePopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public static LikePopup i;
    Vector2 shownPos;
    Vector2 hiddenPos
    {
        get
        {
            Vector3 pos = shownPos;
            pos.y = -pos.y;// 下をアンカーにしているから
            return pos;
        }
    }
    RectTransform rectTransform;
    Tween closeTween;

    public void OnStart()
    {
        i = this;
        rectTransform = GetComponent<RectTransform>();
        shownPos = rectTransform.position;
        gameObject.SetActive(false);
    }


    public void Show(Uranaishi uranaishi)
    {
        text.text = $"{uranaishi.name}先生を「お気に入り」に登録しました";
        ShowAnim();
        closeTween = DOVirtual.DelayedCall(3, () => Close());
    }


    void ShowAnim()
    {
        rectTransform.position = hiddenPos;
        gameObject.SetActive(true);
        rectTransform
            .DOMoveY(shownPos.y, 0.3f)
            .SetEase(Ease.OutCirc);
    }

    public void Close()
    {
        closeTween.Kill();
        rectTransform
            .DOMoveY(hiddenPos.y, 0.3f)
            .SetEase(Ease.OutCirc)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }
}
