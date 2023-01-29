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
    public string[] keywords;
    public UranaishiStatus status;
    public int callChargePerSec;

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

