using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveData
{
    public static SaveData i;

    public List<string> likedUranaishiIdList = new List<string>();
    public int purchasedPoint;
    public int freePoint;
    public List<History> histories = new List<History>();
    public List<Reserve> reserves = new List<Reserve>();



    public SaveData(int freePoint, int purchasedPoint = 0)
    {
        this.purchasedPoint = purchasedPoint;
        this.freePoint = freePoint;
    }

    public int GetAvailableDurationMin(int callChargePerMin)
    {
        float minuteF = (float)GetSumPoint() / (float)callChargePerMin;
        int minuteInt = Mathf.FloorToInt(minuteF);
        return minuteInt;
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

    public History(DateTime startCallingDT, string uranaishiId)
    {
        startCallingSDT = new SerializableDateTime();
        startCallingSDT.dateTime = startCallingDT;
        this.uranaishiId = uranaishiId;
    }
}

[System.Serializable]
public class Reserve
{
    public SerializableDateTime startSDT = new SerializableDateTime();
    public int durationMin;
    public string uranaishiId;
}