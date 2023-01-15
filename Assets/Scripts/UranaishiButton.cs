using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranaishiButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image iconImage;
    [SerializeField] Text nameTxt;
    public RectTransform rectTransform;

    public void Initialize()
    {

    }

    void Start()
    {
        button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        UIManager.i.uranaishiPageManager.Open();
    }

    public void ShowData(Uranaishi uranaishi)
    {
        iconImage.sprite = uranaishi.iconSr;
        nameTxt.text = uranaishi.name;
    }

}
