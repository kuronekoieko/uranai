using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderManager : MonoBehaviour
{
    [SerializeField] Button infoButton;
    [SerializeField] Button purchaseButton;
    public void OnStart()
    {
        infoButton.onClick.AddListener(() =>
        {
            ChromeCustomTabs.OpenURL("https://www.google.co.jp");
        });

        purchaseButton.onClick.AddListener(() =>
        {
            PurchaseModal.i.Open();
        });
    }


}
