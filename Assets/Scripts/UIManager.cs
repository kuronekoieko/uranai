using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour
{

    [SerializeField] ToggleGroup bannerToggleGroup;
    [SerializeField] Transform pagesTf;
    public UranaishiModal uranaishiModal;
    public UranaishiListModal uranaishiListModal;
    public static UIManager i;
    public Page activePage { get; set; } = Page.Uranau;

    void Start()
    {
        i = this;
        StartPages();
        uranaishiModal.OnStart();
        uranaishiListModal.OnStart();
        StartBannerToggles();
    }

    void StartPages()
    {
        BasePageManager[] basePageManagers = pagesTf.GetComponentsInChildren<BasePageManager>(true);
        foreach (var basePageManager in basePageManagers)
        {
            basePageManager.OnStart();
        }
    }

    void StartBannerToggles()
    {
        var bannerToggleControllers = bannerToggleGroup.GetComponentsInChildren<BannerToggleController>(true);

        foreach (var bannerToggleController in bannerToggleControllers)
        {
            bannerToggleController.OnStart(activePage);
        }
    }
}
