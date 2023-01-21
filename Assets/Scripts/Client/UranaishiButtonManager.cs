using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UranaishiButtonManager : MonoBehaviour
{
    [SerializeField] UranaishiButton uranaishiButtonPrefab;
    [SerializeField] RectTransform initRT;
    Vector3 pos;
    List<UranaishiButton> uranaishiButtons = new List<UranaishiButton>();

    public void OnStart()
    {
        pos = initRT.localPosition;
        initRT.gameObject.SetActive(false);
    }

    void Clear()
    {
        pos = initRT.localPosition;
        foreach (var item in uranaishiButtons)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void ShowButtons(Uranaishi[] uranaishiAry)
    {
        Clear();

        for (int i = 0; i < uranaishiAry.Length; i++)
        {
            var uranaishiButton = GetUranaishiButton();
            uranaishiButton.rectTransform.localPosition = pos;
            float margin = 10f;
            pos.y -= margin + initRT.sizeDelta.y;

            uranaishiButton.ShowData(uranaishiAry[i]);
            uranaishiButtons.Add(uranaishiButton);
        }
    }

    UranaishiButton GetUranaishiButton()
    {
        foreach (var item in uranaishiButtons)
        {
            if (item.gameObject.activeSelf == false)
            {
                item.gameObject.SetActive(true);
                return item;
            }
        }
        var uranaishiButton = Instantiate(uranaishiButtonPrefab, transform);

        return uranaishiButton;
    }
}
