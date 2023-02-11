using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public static SaveData i => _i;
    private static SaveData _i = new SaveData();

    public List<string> likedUranaishiIdList = new List<string>();
    public int purchasedPoint;
    public int freePoint = 2000;
}
