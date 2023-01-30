using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour
{

    [SerializeField] ToggleGroup bannerToggleGroup;
    [SerializeField] Transform pagesTf;
    [SerializeField] Transform modalsTf;
    public Uranaishi[] uranaishiAry { get; set; }
    public static UIManager i;
    public Page activePage { get; set; } = Page.Uranau;
    public bool isLocalTestData { get; } = true;
    public Dictionary<UranaishiStatus, string> a;


    async void Start()
    {
        i = this;
        SaveDataManager.i.LoadSaveData();



        if (isLocalTestData)
        {
            uranaishiAry = UranaishiTestData.Instance.uranaishis;
        }
        else
        {
            Debug.Log("ユーザーデータ取得開始");
            uranaishiAry = await FirebaseDatabaseManager.i.GetUranaishiAry(10);
            Debug.Log("ユーザーデータ取得終了");
        }

        StartPages();
        StartModals();
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

    void StartModals()
    {
        BaseModal[] baseModals = modalsTf.GetComponentsInChildren<BaseModal>(true);
        foreach (var baseModal in baseModals)
        {
            baseModal.OnStart();
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
