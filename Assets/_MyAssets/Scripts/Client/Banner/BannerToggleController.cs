using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerToggleController : MonoBehaviour
{
    public Toggle toggle { get; private set; }
    [SerializeField] Page _page;
    public Page page => _page;

    public void OnStart(Page initPage)
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(ToggleValueChanged);
        toggle.isOn = (initPage == _page);
    }

    void ToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            UIManager.i.activePage = _page;
        }
    }
}
