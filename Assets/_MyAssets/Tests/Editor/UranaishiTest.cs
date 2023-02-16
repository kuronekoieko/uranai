using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Linq;

public class UranaishiTest
{



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
