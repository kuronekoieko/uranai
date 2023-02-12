using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCallingScreen : MonoBehaviour
{
    protected CallingManager callingManager;
    protected Uranaishi uranaishi;

    public virtual void OnStart(CallingManager callingManager)
    {
        this.callingManager = callingManager;
        Close();

    }

    public virtual void Open(Uranaishi uranaishi)
    {
        this.uranaishi = uranaishi;
        gameObject.SetActive(true);

    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }

}
