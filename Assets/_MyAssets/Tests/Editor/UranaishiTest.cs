using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.TestTools;
using System;

public class UranaishiTest
{

    [Test]
    public void DateTime_0()
    {

    }

}

public class SerializableDateTimeTest
{
    [Test]
    public void DateTime_0()
    {
        var serializableDateTime = new SerializableDateTime();
        LogAssert.Expect(LogType.Error, "日付のパース失敗 " + "n/a");
        Assert.That(serializableDateTime.dateTime == null);
        Assert.That(serializableDateTime.GetStr() == "n/a");
        LogAssert.Expect(LogType.Error, "日付のパース失敗 " + "n/a");
        Assert.That(serializableDateTime.IsFutureFromNow() == false);
    }

    [Test]
    public void DateTime_1()
    {
        var serializableDateTime = new SerializableDateTime();
        serializableDateTime.dateTime = DateTime.MinValue;
        Assert.That(serializableDateTime.dateTime == DateTime.MinValue);
        Assert.That(serializableDateTime.GetStr() == DateTime.MinValue.ToString());
        Assert.That(serializableDateTime.IsFutureFromNow() == false);
    }

    [Test]
    public void DateTime_2()
    {
        var serializableDateTime = new SerializableDateTime();
        var test = new DateTime();
        serializableDateTime.dateTime = test;
        Assert.That(serializableDateTime.dateTime == test);
        Assert.That(serializableDateTime.GetStr() == test.ToString());
        Assert.That(serializableDateTime.IsFutureFromNow() == false);
    }

    [Test]
    public void DateTime_3()
    {
        var serializableDateTime = new SerializableDateTime();
        serializableDateTime.dateTime = null;
        LogAssert.Expect(LogType.Error, "日付のパース失敗 " + "n/a");
        Assert.That(serializableDateTime.dateTime == null);
        Assert.That(serializableDateTime.GetStr() == "n/a");
        LogAssert.Expect(LogType.Error, "日付のパース失敗 " + "n/a");
        Assert.That(serializableDateTime.IsFutureFromNow() == false);
    }

    [Test]
    public void DateTime_4()
    {
        var serializableDateTime = new SerializableDateTime();
        serializableDateTime.dateTime = DateTime.Now;
        Assert.That(serializableDateTime.dateTime == DateTime.Now);
        Assert.That(serializableDateTime.GetStr() == DateTime.Now.ToString());
        Assert.That(serializableDateTime.IsFutureFromNow() == false);
    }

    [Test]
    public void DateTime_5()
    {
        var serializableDateTime = new SerializableDateTime();
        serializableDateTime.dateTime = DateTime.MaxValue;
        Assert.That(serializableDateTime.dateTime == DateTime.MaxValue);
        Assert.That(serializableDateTime.GetStr() == DateTime.MaxValue.ToString());
        Assert.That(serializableDateTime.IsFutureFromNow() == true);
    }

    [Test]
    public void ToStringIncludeEmpty_0()
    {
        DateTime? dateTime = null;
        Assert.That(dateTime.ToStringIncludeEmpty() == "n/a");
    }

    [Test]
    public void ToStringIncludeEmpty_1()
    {
        DateTime newDT = new DateTime();
        DateTime? dateTime = newDT;
        Assert.That(dateTime.ToStringIncludeEmpty() == newDT.ToString());
    }

    [Test]
    public void ToStringIncludeEmpty_2()
    {
        DateTime newDT = DateTime.Now;
        DateTime? dateTime = newDT;
        Assert.That(dateTime.ToStringIncludeEmpty() == newDT.ToString());
    }

    [Test]
    public void ToStringIncludeEmpty_3()
    {
        DateTime? dateTime = null;
        Assert.That(dateTime.ToStringIncludeEmpty("M月d日(ddd)") == "n/a");
    }

    [Test]
    public void ToStringIncludeEmpty_4()
    {
        DateTime newDT = new DateTime();
        DateTime? dateTime = newDT;
        Assert.That(dateTime.ToStringIncludeEmpty("M月d日(ddd)") == newDT.ToString("M月d日(ddd)"));
    }

    [Test]
    public void ToStringIncludeEmpty_5()
    {
        DateTime newDT = DateTime.Now;
        DateTime? dateTime = newDT;
        Assert.That(dateTime.ToStringIncludeEmpty("M月d日(ddd)") == newDT.ToString("M月d日(ddd)"));
    }
}


public class ReviewTest
{

    [Test]
    public void GetTitleText_0()
    {
        Review review = new Review(1, "");

        string title = review.GetTitleText();
        // Debug.Log(review.reviewerName);
        Assert.That(title == "匿名");
    }

    [Test]
    public void GetTitleText_1()
    {
        Review review = new Review(1, "");
        review.reviewerName = "よしこ";
        review.age = 50;
        review.sex = Sex.Woman;

        string title = review.GetTitleText();
        Assert.That(title == "よしこ・50代・女性");
    }

    [Test]
    public void GetTitleText_2()
    {
        Review review = new Review(1, "");
        review.reviewerName = "";
        review.age = 20;
        review.sex = Sex.Man;

        string title = review.GetTitleText();
        Assert.That(title == "匿名・20代・男性");
    }

    [Test]
    public void GetTitleText_3()
    {
        Review review = new Review(1, "");
        review.reviewerName = "よしお";
        review.age = 0;
        review.sex = Sex.Man;

        string title = review.GetTitleText();
        Assert.That(title == "よしお・男性");
    }


    [Test]
    public void GetTitleText_4()
    {
        Review review = new Review(1, "");
        review.reviewerName = "よしお";
        review.age = 20;
        review.sex = Sex.None;

        string title = review.GetTitleText();
        Assert.That(title == "よしお・20代");
    }

    [Test]
    public void GetTitleText_5()
    {
        Review review = new Review(1, "");
        review.reviewerName = "";
        review.age = 0;
        review.sex = Sex.Man;

        string title = review.GetTitleText();
        Assert.That(title == "匿名・男性");
    }

    [Test]
    public void GetTitleText_6()
    {
        Review review = new Review(1, "");
        review.reviewerName = "よしお";
        review.age = 0;
        review.sex = Sex.None;

        string title = review.GetTitleText();
        Assert.That(title == "よしお");
    }

    [Test]
    public void GetTitleText_7()
    {
        Review review = new Review(1, "");
        review.reviewerName = "";
        review.age = 20;
        review.sex = Sex.None;

        string title = review.GetTitleText();
        Assert.That(title == "匿名・20代");
    }
}
