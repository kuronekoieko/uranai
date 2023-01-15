using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranaishiButton : MonoBehaviour
{
    [SerializeField] Button button;

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

}
