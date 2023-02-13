using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CallingManager : MonoBehaviour
{
    BaseCallingScreen[] baseCallingScreens;


    public void OnStart()
    {
        baseCallingScreens = GetComponentsInChildren<BaseCallingScreen>(true);
        foreach (var item in baseCallingScreens)
        {
            item.OnStart(this);
        }
    }

    public void Open(Uranaishi uranaishi)
    {
        gameObject.SetActive(true);

        foreach (var item in baseCallingScreens)
        {
            item.Close();
        }

        bool isEnoughPoint = SaveData.i.GetSumPoint() > uranaishi.callChargePerMin * 3;
        //isEnoughPoint = true;
        if (isEnoughPoint)
        {
            GetScreen<ConfirmCallingPopup>().Open(uranaishi);
        }
        else
        {
            GetScreen<PurchasePointsPopup>().Open(uranaishi);
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
        foreach (var item in baseCallingScreens)
        {
            item.Close();
        }
    }

    public T GetScreen<T>() where T : BaseCallingScreen
    {
        T subClass = baseCallingScreens.Select(_ => _ as T).FirstOrDefault(_ => _);
        // Debug.Log(subClass.GetType());
        return subClass;
    }
}
