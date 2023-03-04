using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPage : BasePageManager
{
    [SerializeField] Button historyButton;
    [SerializeField] Button tutorialButton;
    [SerializeField] Button helpButton;
    [SerializeField] Button twitterButton;
    [SerializeField] Button ratingButton;
    [SerializeField] Button aboutButton;

    public override void OnStart()
    {
        base.SetPageAction(4);

        historyButton.onClick.AddListener(OnClickHistoryButton);
        tutorialButton.onClick.AddListener(OnClickTutorialButton);
        helpButton.onClick.AddListener(OnClickHelpButton);
        twitterButton.onClick.AddListener(OnClickTwitterButton);
        ratingButton.onClick.AddListener(OnClickRatingButton);
        aboutButton.onClick.AddListener(OnClickAboutButton);
    }

    public override void OnUpdate()
    {
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    protected override void OnOpen()
    {
        gameObject.SetActive(true);
    }


    void OnClickHistoryButton()
    {

    }

    void OnClickTutorialButton()
    {

    }
    void OnClickHelpButton()
    {
        ChromeCustomTabs.OpenURL("ヘルプのURL");
    }
    void OnClickTwitterButton()
    {
        Application.OpenURL("公式twitterのURL");
    }
    void OnClickRatingButton()
    {
        // https://kingmo.jp/kumonos/unity-inappreview-ios-android/
        StartCoroutine(InAppReviewManager.RequestReview());
    }
    void OnClickAboutButton()
    {

    }


}
