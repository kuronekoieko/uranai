using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] ToggleGroup bannerToggleGroup;
    [SerializeField] Transform pagesTf;
    public UranaishiPageManager uranaishiPageManager;
    public UranaishiListPopup uranaishiListPopup;
    public static UIManager i;
    public Page activePage { get; set; } = Page.Uranau;
    BasePageManager[] basePageManagers;

    void Start()
    {
        i = this;
        basePageManagers = pagesTf.GetComponentsInChildren<BasePageManager>(true);
        StartPages();
        uranaishiPageManager.OnStart();
        uranaishiListPopup.OnStart();
    }

    void StartPages()
    {
        foreach (var basePageManager in basePageManagers)
        {
            basePageManager.OnStart();
        }
    }
}
