using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebViewSample : MonoBehaviour
{
    private void Start()
    {


        WebViewObject webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init(
            ld: (msg) => Debug.Log(string.Format("CallOnLoaded[{0}]", msg)),
            enableWKWebView: true);

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        webViewObject.bitmapRefreshCycle = 1;
#endif
        webViewObject.LoadURL("https://www.google.co.jp");

        webViewObject.SetVisibility(true);
    }



}