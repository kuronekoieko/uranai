using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleModal : BaseModal
{
    [SerializeField] ScheduleSelectManager scheduleSelectManager;
    public override void OnStart()
    {
        base.OnStart();
        scheduleSelectManager.OnStart();
    }

    public void Open(Uranaishi uranaishi)
    {
        base.OpenAnim(ModalType.Horizontal);



    }
}
