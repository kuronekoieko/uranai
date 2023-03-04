using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutAppModal : BaseModal
{
    [SerializeField] Button privacyPolicyButton;
    [SerializeField] Button tokushouhouButton;
    [SerializeField] Button idButton;
    [SerializeField] Button licenseButton;
    [SerializeField] Button cancelMembershipButton;
    public override void OnStart()
    {
        base.OnStart();

        privacyPolicyButton.onClick.AddListener(OnClickPrivacyPolicyButton);
        tokushouhouButton.onClick.AddListener(OnClickTokushouhouButton);
        idButton.onClick.AddListener(OnClickIdButton);
        licenseButton.onClick.AddListener(OnClickLicenseButton);
        cancelMembershipButton.onClick.AddListener(OnClickCancelMembershipButton);
    }

    public void Open()
    {
        base.OpenAnim();
    }

    void OnClickPrivacyPolicyButton()
    {

    }

    void OnClickTokushouhouButton()
    {

    }
    void OnClickIdButton()
    {
    }
    void OnClickLicenseButton()
    {
    }
    void OnClickCancelMembershipButton()
    {

    }
}
