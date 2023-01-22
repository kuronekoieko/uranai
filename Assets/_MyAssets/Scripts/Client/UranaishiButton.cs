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
    Uranaishi uranaishi;

    public void Initialize()
    {

    }

    void Start()
    {
        button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        UIManager.i.uranaishiModal.Open(uranaishi);
    }

    public void ShowData(Uranaishi uranaishi)
    {
        iconImage.sprite = null;
        uranaishi.GetIcon((sprite) =>
        {
            iconImage.sprite = sprite;
        });
        nameTxt.text = uranaishi.name;
        this.uranaishi = uranaishi;
    }

}
