using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UranaishiPageManager : MonoBehaviour
{
    [SerializeField] Button xButton;
    [SerializeField] RectTransform rectTransform;
    Vector3 initPos;

    public void OnStart()
    {
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


    public void Open()
    {
        gameObject.SetActive(true);
        rectTransform
            .DOMoveY(initPos.y, 0.3f)
            .SetEase(Ease.OutCirc);
    }
}
