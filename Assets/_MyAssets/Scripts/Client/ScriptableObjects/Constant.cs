using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Create " + nameof(Constant), fileName = nameof(Constant))]
public class Constant : SingletonScriptableObject<Constant>
{
    [SerializeField] UranaishiStatusDisplayName[] _uranaishiStatusDisplayNames;
    public UranaishiStatusDisplayName[] uranaishiStatusDisplayNames => _uranaishiStatusDisplayNames;


}

[System.Serializable]
public class UranaishiStatusDisplayName
{
    public UranaishiStatus uranaishiStatus;
    public string displayName;
}