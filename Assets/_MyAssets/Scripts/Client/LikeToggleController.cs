using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UniRx;

public class LikeToggleController : MonoBehaviour
{
    Toggle toggle;
    Uranaishi uranaishi;

    public void OnStart()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(ToggleValueChanged);

        toggle.isOn = false;
        this.ObserveEveryValueChanged(count => SaveData.i.likedUranaishiIdList.Count)
            .Where(count => uranaishi != null)
            .Select(contains => SaveData.i.likedUranaishiIdList.Contains(uranaishi.id))
            .Subscribe(contains => OnChangedSaveData(contains))
            .AddTo(this.gameObject);
    }

    public void OnOpen(Uranaishi uranaishi)
    {
        this.uranaishi = uranaishi;
        toggle.isOn = SaveData.i.likedUranaishiIdList.Contains(uranaishi.id);
    }

    void ToggleValueChanged(bool isOn)
    {
        if (uranaishi == null) return;
        bool isContains = SaveData.i.likedUranaishiIdList.Contains(uranaishi.id);
        if (isOn)
        {
            if (isContains) return;
            SaveData.i.likedUranaishiIdList.Add(uranaishi.id);
            SaveDataManager.i.Save();
        }
        else
        {
            if (isContains == false) return;
            SaveData.i.likedUranaishiIdList.Remove(uranaishi.id);
            SaveDataManager.i.Save();
        }
    }


    void OnChangedSaveData(bool isAdded)
    {
        // TODO: すべてのtoggleが変更検知してしまう
        toggle.isOn = isAdded;
        // Debug.Log(uranaishi.id + " " + isAdded);
    }

}
