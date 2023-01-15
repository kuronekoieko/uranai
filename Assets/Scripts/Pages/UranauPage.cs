using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranauPage : BasePageManager
{
    [SerializeField] UranaishiButton uranaishiButtonPrefab;
    List<UranaishiButton> uranaishiButtons = new List<UranaishiButton>();
    [SerializeField] RectTransform initRT;
    [SerializeField] Transform uranaishiButtonsParent;

    public override void OnStart()
    {
        base.SetPageAction(Page.Uranau);

        Vector3 pos = initRT.position;
        for (int i = 0; i < 10; i++)
        {
            var uranaishiButton = Instantiate(uranaishiButtonPrefab, uranaishiButtonsParent);
            uranaishiButton.rectTransform.position = pos;
            float margin = 10f;
            pos.y -= margin + initRT.sizeDelta.y;

            uranaishiButton.ShowData(UranaishiSO.Instance.uranaishiAry[i]);
        }
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
}
