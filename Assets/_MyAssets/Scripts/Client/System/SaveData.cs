using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public static SaveData i;

    public List<string> likedUranaishiIdList = new List<string>();
    public int purchasedPoint;
    public int freePoint;

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

    public void Test()
    {
        var tests = new SaveData[] {
            new SaveData(0,0),
            new SaveData(2000,2000),
            new SaveData(2000,5000),
            new SaveData(5000,2000),
            new SaveData(0,2000),
            new SaveData(2000,0),
         };

        var answers = new SaveData[] {
            new SaveData(0,0),
            new SaveData(2000,0),
            new SaveData(2000,3000),
            new SaveData(5000,0),
            new SaveData(0,0),
            new SaveData(0,0),
         };


        for (int i = 0; i < tests.Length; i++)
        {
            tests[i].ConsumePoints(2000);
            bool a = tests[i].freePoint == answers[i].freePoint;
            bool b = tests[i].purchasedPoint == answers[i].purchasedPoint;

            Debug.Log(i + " " + (a && b));
        }

    }
}
