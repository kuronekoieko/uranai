using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasePointManager : ObjectPooling<PurchasePointElement>
{
    public void OnStart()
    {
        base.Initialize();
    }

    public void ShowElements(List<ChargeInfo> chargeInfos)
    {
        base.Clear();

        for (int i = 0; i < chargeInfos.Count; i++)
        {
            var instance = base.GetInstance();
            instance.Show(chargeInfos[i]);
        }
    }
}
