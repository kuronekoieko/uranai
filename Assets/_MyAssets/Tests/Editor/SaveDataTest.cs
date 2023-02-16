using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.TestTools;

public class SaveDataTest
{

    [Test]
    public void ConsumePoints()
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
            Assert.That(a == b);

        }
    }
}
