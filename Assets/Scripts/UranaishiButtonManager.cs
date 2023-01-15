using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranaishiButtonManager : MonoBehaviour
{
    [SerializeField] UranaishiButton uranaishiButtonPrefab;
    [SerializeField] RectTransform initRT;
    Vector3 pos;

    public void OnStart()
    {
        pos = initRT.localPosition;
        initRT.gameObject.SetActive(false);
    }

    public void ShowButtons(Uranaishi[] uranaishiAry)
    {
        for (int i = 0; i < uranaishiAry.Length; i++)
        {
            var uranaishiButton = Instantiate(uranaishiButtonPrefab, transform);
            uranaishiButton.rectTransform.localPosition = pos;
            float margin = 10f;
            pos.y -= margin + initRT.sizeDelta.y;

            uranaishiButton.ShowData(uranaishiAry[i]);
        }
    }
}
