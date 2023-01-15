using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerToggleController : MonoBehaviour
{
    Toggle toggle;
    [SerializeField] Page page;

    public void OnStart(Page initPage)
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(ToggleValueChanged);
        toggle.isOn = (initPage == page);
    }

    void ToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            UIManager.i.activePage = page;
        }
    }
}
