using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Uranaishi
{
    public string id;
    // public string iconStorageFilePath;
    public string name;
    public string[] keywords;
    public int status;
    [System.NonSerialized] Sprite _iconSprite;

    public void GetIcon(UnityAction<Sprite> onComplete)
    {
        if (_iconSprite)
        {
            onComplete(_iconSprite);
            return;
        }

        FirebaseStorageManager.i.DownloadFile(this, (sprite) =>
        {
            _iconSprite = sprite;
            onComplete(sprite);
        });

    }
}