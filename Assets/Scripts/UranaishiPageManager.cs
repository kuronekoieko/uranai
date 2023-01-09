using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UranaishiPageManager : MonoBehaviour
{
    [SerializeField] Button xButton;
    [SerializeField] RectTransform rectTransform;
    public static UranaishiPageManager i;
    Vector3 initPos;

    public void Initialize()
    {

    }

    void Start()
    {
        initPos = rectTransform.position;
        i = this;
        // gameObject.SetActive(false);
        xButton.onClick.AddListener(OnClickXButton);
    }

    void OnClickXButton()
    {
        // gameObject.SetActive(false);
        rectTransform.DOMoveY(-Screen.height / 2f, 0.3f).SetEase(Ease.OutCirc);

    }


    public void Open()
    {
        // gameObject.SetActive(true);
        rectTransform.DOMoveY(initPos.y, 0.3f).SetEase(Ease.OutCirc);
    }
}
