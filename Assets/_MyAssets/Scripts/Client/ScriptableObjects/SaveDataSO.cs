using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

[CreateAssetMenu(menuName = "MyGame/Create " + nameof(SaveDataSO), fileName = nameof(SaveDataSO))]
public class SaveDataSO : ScriptableObject
{
    [SerializeField] SaveDataManager saveDataManager;

    [SerializeField] SaveData saveData;




    [Button]
    public void Pull()
    {
        saveDataManager.LoadSaveData();
        saveData = SaveData.i;
        Debug.Log("セーブデータ取得");
    }

    [Button]
    public void Send()
    {
        SaveData.i = saveData;
        saveDataManager.Save();
        Debug.Log("セーブデータ更新");
    }
}
