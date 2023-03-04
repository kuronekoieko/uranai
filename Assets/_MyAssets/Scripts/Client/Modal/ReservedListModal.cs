using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ReservedListModal : BaseModal
{
    [SerializeField] ReservedInfoManager reservedInfoManager;

    public override void OnStart()
    {
        base.OnStart();
        reservedInfoManager.OnStart();

    }

    public void Open()
    {
        base.OpenAnim();
        reservedInfoManager.ShowElement(SaveData.i.reserves.ToArray());
    }
}
