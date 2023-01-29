using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Create " + nameof(UranaishiTestData), fileName = nameof(UranaishiTestData))]

public class UranaishiTestData : SingletonScriptableObject<UranaishiTestData>
{
    public Uranaishi[] uranaishis;
}
