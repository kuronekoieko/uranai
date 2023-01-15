using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeToggleController : MonoBehaviour
{
    Toggle toggle;
    Uranaishi uranaishi;

    public void OnStart()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(ToggleValueChanged);
    }

    public void OnOpen(Uranaishi uranaishi)
    {
        this.uranaishi = uranaishi;
        toggle.isOn = SaveData.i.likedUranaishiIdList.Contains(uranaishi.id);
    }

    void ToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            if (SaveData.i.likedUranaishiIdList.Contains(uranaishi.id)) return;
            SaveData.i.likedUranaishiIdList.Add(uranaishi.id);
            SaveDataManager.i.Save();
        }
        else
        {
            SaveData.i.likedUranaishiIdList.Remove(uranaishi.id);
            SaveDataManager.i.Save();
        }
    }
}
