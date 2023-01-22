
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Create " + nameof(UranaishiSO), fileName = nameof(UranaishiSO))]
public class UranaishiSO : SingletonScriptableObject<UranaishiSO>
{
    public Uranaishi[] uranaishiAry;

}

[System.Serializable]
public class Uranaishi
{
    public string id;
    // public string iconStorageFilePath;
    public string name;
    public string[] keywords;
    public int status;

    public Sprite GetSprite()
    {
        return null;
    }
}

[System.Serializable]
public class Review
{
    public string writerId;
    public string uranaishiId;
    public string text;
    public int starCount;
}