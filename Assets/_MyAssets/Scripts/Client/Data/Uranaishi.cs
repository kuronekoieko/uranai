using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Threading.Tasks;
using System.Linq;

[System.Serializable]
public class Uranaishi
{
    public string id;
    public string name;
    public UranaishiStatus status;
    public int callChargePerSec;
    [TextArea(5, 10)] public string message;
    public string[] expertises = new string[0];
    public string[] divinations = new string[0];
    public Schedule[] schedules = new Schedule[0];
    public Review[] reviews = new Review[0];

    [System.NonSerialized] Sprite _iconSprite;

    public async void GetIcon(UnityAction<Sprite> onComplete)
    {
        if (_iconSprite)
        {
            onComplete(_iconSprite);
            return;
        }

        if (UIManager.i.isLocalTestData)
        {

            // return;
        }

        await FirebaseStorageManager.i.DownloadFile(this, (sprite) =>
        {
            _iconSprite = sprite;
            onComplete(sprite);
        });
    }

    public string GetStatusDisplayName()
    {
        switch (status)
        {
            case UranaishiStatus.Counseling:
                return "相談中(X人待ち)";
            case UranaishiStatus.Free:
                return "今すぐOK";
            case UranaishiStatus.Closed:
                return "本日終了";
            case UranaishiStatus.DatTime:
                Schedule schedule = schedules
                    .Where(schedule => schedule.start.IsFutureFromNow())
                    .OrderBy(schedule => schedule.start.GetString())
                    .FirstOrDefault();
                if (schedule == null) return "本日終了";
                return schedule.start.GetDateTime().ToString("M/dd HH:mm～");
            default:
                return "";
        }

    }

    public float GetReviewAvr()
    {
        double avr;
        if (reviews.Count() == 0)
        {
            avr = 0;
        }
        else
        {
            avr = reviews.Select(r => r.starCount).Average();
        }
        return (float)avr;
    }

    public Review[] GetOrderedReviews(int takeCount)
    {
        var pickUpReviews = reviews
            .Where(review => review.isPickUp)
            .OrderBy(review => review.writtenDate.GetString())
            .ToArray();
        var notPickUpReviews = reviews
            .Where(review => !review.isPickUp)
            .OrderBy(review => review.writtenDate.GetString())
            .Take(takeCount - pickUpReviews.Count())
            .ToArray();

        return reviews = pickUpReviews.Concat(notPickUpReviews).ToArray();
    }

    public Review GetFirstReview()
    {
        Review[] reviews = GetOrderedReviews(1);
        if (reviews.Length > 0)
        {
            return reviews[0];
        }
        else
        {
            return null;
        }
    }

}

[System.Serializable]
public enum UranaishiStatus
{
    Counseling = 0,
    Free = 1,
    Closed = 2,
    DatTime = 3
}

[System.Serializable]
public class Schedule
{
    public SerializableDateTime start;
    public SerializableDateTime end;
}

[System.Serializable]
public class SerializableDateTime
{
    public int year;
    public int month;
    public int day;
    public int hour;
    public int minute;
    public int second;

    public bool IsFutureFromNow()
    {
        return GetDateTime() > DateTime.Now;
    }

    public string GetString()
    {
        return year.ToString("0000")
            + month.ToString("00")
            + day.ToString("00")
            + hour.ToString("00")
            + minute.ToString("00")
            + second.ToString("00");
    }



    public string GetDateString()
    {
        return year.ToString("0000")
            + month.ToString("00")
            + day.ToString("00");
    }

    public DateTime GetDateTime()
    {
        return new DateTime(year, month, day, hour, minute, second);
    }
}

[System.Serializable]
public class Review
{
    public int starCount;
    [TextArea(5, 10)] public string text;
    public string reviewerName;
    public int age;
    public Sex sex;
    public bool isPickUp;
    public SerializableDateTime writtenDate;

    public string GetTitleText()
    {
        string title = "";
        title += reviewerName == "" ? "匿名" : reviewerName;
        title += "・" + age + "代";

        switch (sex)
        {
            case Sex.Man:
                title += "・男性";
                break;
            case Sex.Woman:
                title += "・女性";
                break;
            case Sex.None:

                break;
            default:
                break;
        }
        return title;

    }
}

[System.Serializable]
public enum Sex
{
    Man,
    Woman,
    None,
}