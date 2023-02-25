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
    public int callChargePerMin;
    [TextArea(5, 10)] public string message;
    public string belonging;
    public string twitterURL;
    public string facebookURL;
    public string otherURL;
    public string[] expertises = new string[0];
    public string[] divinations = new string[0];
    public List<Schedule> schedules = new List<Schedule>();
    public List<Review> reviews = new List<Review>();

    [System.NonSerialized] Sprite _iconSprite;

    public void CheckSchedules(int reserveDurationMin, int days)
    {
        DateTime today = DateTime.Today;
        // 古いスケジュールを削除
        // 念のため、予約可能日を超えた時間も削除
        schedules.RemoveAll(s => s.startSDT.dateTime < today || s.startSDT.dateTime > today.AddDays(days));

        // 4日間のスケジュールを作成
        if (schedules.Count == 0)
        {
            Schedule schedule = new Schedule();
            schedule.startSDT.dateTime = today;
            schedules.Add(schedule);
        }


        while (true)
        {
            DateTime lastDT = schedules[schedules.Count - 1].startSDT.dateTime.Value;
            Schedule schedule = new Schedule();
            schedule.startSDT.dateTime = lastDT.AddMinutes(reserveDurationMin);

            if (schedule.startSDT.dateTime >= today.AddDays(days))
            {
                break;
            }
            schedules.Add(schedule);
        }
    }

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
            case UranaishiStatus.Waiting:
                return "今すぐOK";
            case UranaishiStatus.Closed:
                return "本日終了";
            case UranaishiStatus.DatTime:
                Schedule schedule = schedules
                    .Where(schedule => schedule.startSDT.IsFutureFromNow())
                    .OrderBy(schedule => schedule.startSDT.dateTime)
                    .FirstOrDefault();
                if (schedule == null) return "本日終了";
                return schedule.startSDT.dateTime.ToStringIncludeEmpty("M/dd HH:mm～");
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

    public Review[] GetOrderedReviews()
    {
        var pickUpReviews = reviews
            .Where(review => review.isPickUp)
            .OrderBy(review => review.writtenDate.dateTime)
            .ToArray();

        var notPickUpReviews = reviews
            .Where(review => !review.isPickUp)
            .OrderBy(review => review.writtenDate.dateTime)
            .ToArray();

        return pickUpReviews.Concat(notPickUpReviews).ToArray();
    }

    public Review GetFirstReview()
    {
        Review[] reviews = GetOrderedReviews();
        if (reviews.Length > 0)
        {
            return reviews[0];
        }
        else
        {
            return null;
        }
    }

    public string GetChareText()
    {
        return callChargePerMin + "pt/1分"; ;
    }

}

[System.Serializable]
public enum UranaishiStatus
{
    Counseling = 0,
    Waiting = 1,
    Closed = 2,
    DatTime = 3
}

[System.Serializable]
public class Schedule
{
    public SerializableDateTime startSDT = new SerializableDateTime();
    public DateTime endDT => startSDT.dateTime.Value.AddMinutes(Constant.Instance.reserveDurationMin);
    public ScheduleStatus scheduleStatus = ScheduleStatus.Free;
}

[System.Serializable]
public enum ScheduleStatus
{
    Free = 0,
    Reserved = 1,
    Closed = 2,
}


[System.Serializable]
public class SerializableDateTime
{
    [Header("yyyy/MM/dd HH:mm:ss")]
    [SerializeField] string dateTimeStr = "n/a";
    Nullable<DateTime> _dateTime;

    public string GetStr()
    {
        return dateTimeStr;
    }

    public Nullable<DateTime> dateTime
    {
        set
        {
            _dateTime = value;
            dateTimeStr = _dateTime.ToStringIncludeEmpty();
        }
        get
        {
            if (_dateTime != null)
            {
                return _dateTime;
            }

            if (DateTime.TryParse(dateTimeStr, out DateTime a))
            {
                _dateTime = a;
                return _dateTime;
            }
            else
            {
                Debug.LogError("日付のパース失敗 " + dateTimeStr);
                return null;
            }
        }

    }

    public bool IsFutureFromNow()
    {
        return dateTime > DateTime.Now;
    }
}

[System.Serializable]
public class Review
{
    [NonSerialized] public Uranaishi uranaishi;
    public int starCount;
    [TextArea(5, 10)] public string text;
    public string reviewerName;
    public int age;
    public Sex sex;
    public bool isPickUp;
    public SerializableDateTime writtenDate;

    public Review(
        int starCount,
        string text)
    {
        this.starCount = starCount;
        this.text = text;
        writtenDate = new SerializableDateTime();
        writtenDate.dateTime = DateTime.Now;
        sex = Sex.None;
    }

    public string GetTitleText()
    {
        string title = "";
        title += string.IsNullOrEmpty(reviewerName) ? "匿名" : reviewerName;
        title += age == 0 ? "" : "・" + age + "代";

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

[System.Serializable]
public class Reserve
{
    public Schedule[] schedules;
    public string uranaishiId;
}
