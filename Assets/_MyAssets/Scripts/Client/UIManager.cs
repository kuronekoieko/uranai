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
    [SerializeField] HeaderManager headerManager;
    [SerializeField] UranaishiTestData uranaishiTestData;
    public Uranaishi[] uranaishiAry { get; set; }
    public static UIManager i;
    public Page activePage { get; set; } = Page.Uranau;
    public bool isLocalTestData { get; } = false;


    async void Start()
    {
        i = this;
        SaveDataManager.i.LoadSaveData();
        FirebaseDatabaseManager.i.Initialize();
        FirebaseStorageManager.i.Initialize();

        if (isLocalTestData)
        {
            uranaishiAry = uranaishiTestData.uranaishis;
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
        headerManager.OnStart();

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
