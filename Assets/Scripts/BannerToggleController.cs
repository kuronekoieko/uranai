using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerToggleController : MonoBehaviour
{
    Toggle toggle;
    [SerializeField] Page page;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(ToggleValueChanged);
    }

    void ToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            UIManager.i.activePage = page;
        }
    }
}
