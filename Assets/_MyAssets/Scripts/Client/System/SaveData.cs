using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public static SaveData i;

    public List<string> likedUranaishiIdList = new List<string>();
    public int purchasedPoint;
    public int freePoint;
    public List<History> histories = new List<History>();



    public SaveData(int freePoint, int purchasedPoint = 0)
    {
        this.purchasedPoint = purchasedPoint;
        this.freePoint = freePoint;
    }


    public int GetSumPoint()
    {
        return purchasedPoint + freePoint;
    }

    public void ConsumePoints(int consumingPoint)
    {
        //  2000        3000             1000
        int leftPoint = consumingPoint - freePoint;
        if (leftPoint <= 0)
        {
            //2000           1000 
            freePoint -= consumingPoint;
            return;
        }

        freePoint = 0;
        //-3000      2000        5000 
        int lackPoint = leftPoint - purchasedPoint;
        if (lackPoint <= 0)
        {
            //3000           2000
            purchasedPoint -= leftPoint;
            return;
        }
        purchasedPoint = 0;
        Debug.LogError("ポイントが不足しているのに購入できてしまった");

    }

}

[System.Serializable]
public class History
{
    public SerializableDateTime startCallingSDT;
    public int durationSec;
    public string uranaishiId;
}