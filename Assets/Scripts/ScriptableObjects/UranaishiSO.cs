
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Create " + nameof(UranaishiSO), fileName = nameof(UranaishiSO))]
public class UranaishiSO : SingletonScriptableObject<UranaishiSO>
{
    public Uranaishi[] uranaishi;

}

[System.Serializable]
public class Uranaishi
{
    public string id;
    public Sprite iconSr;
    public string name;
    public string[] keywords;
    public int status;
}

[System.Serializable]
public class Review
{
    public string writerId;
    public string uranaishiId;
    public string text;
    public int starCount;
}