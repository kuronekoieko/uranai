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
    public Uranaishi[] uranaishiAry;
    public static UIManager i;
    public Page activePage { get; set; } = Page.Uranau;

    async void Start()
    {
        i = this;
        SaveDataManager.i.LoadSaveData();

        Debug.Log("ユーザーデータ取得開始");
        uranaishiAry = await FirebaseDatabaseManager.i.GetUranaishiAry(10);
        Debug.Log("ユーザーデータ取得終了");

        StartPages();
        uranaishiModal.OnStart();
        uranaishiListModal.OnStart();
        StartBannerToggles();

        Application.targetFrameRate = 60;
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
