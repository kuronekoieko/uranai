using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] ToggleGroup bannerToggleGroup;
    [SerializeField] Transform pagesTf;
    public static UIManager i;
    public Page activePage = Page.Uranau;
    BasePageManager[] basePageManagers;

    void Start()
    {
        i = this;
        basePageManagers = pagesTf.GetComponentsInChildren<BasePageManager>(true);
        StartPages();
    }

    void Update()
    {

    }

    void StartPages()
    {
        foreach (var basePageManager in basePageManagers)
        {
            basePageManager.OnStart();
        }
    }
}
