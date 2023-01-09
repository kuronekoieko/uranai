using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UranaishiPageManager : MonoBehaviour
{
    [SerializeField] Button xButton;
    public static UranaishiPageManager i;

    public void Initialize()
    {

    }

    void Start()
    {
        i = this;
        gameObject.SetActive(false);
        xButton.onClick.AddListener(OnClickXButton);
    }

    void OnClickXButton()
    {
        gameObject.SetActive(false);
    }


    public void Open()
    {
        gameObject.SetActive(true);

    }
}
