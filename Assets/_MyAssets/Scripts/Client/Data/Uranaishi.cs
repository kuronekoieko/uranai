using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[System.Serializable]
public class Uranaishi
{
    public string id;
    public string name;
    // public string[] keywords;
    public UranaishiStatus status;
    public int callChargePerSec;
    [TextArea(5, 10)] public string message;
    public Schedule[] schedules;

    [System.NonSerialized] Sprite _iconSprite;

    public void GetIcon(UnityAction<Sprite> onComplete)
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

        FirebaseStorageManager.i.DownloadFile(this, (sprite) =>
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
                return "X/XX XX:XX～";
            default:
                return "";
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