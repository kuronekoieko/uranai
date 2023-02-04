using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Firebase.Storage;
using Firebase.Extensions;
using UnityEngine.Networking;
using System;
using UnityEngine.Events;


public class FirebaseStorageManager : Singleton<FirebaseStorageManager>
{
    StorageReference storageRef;

    public void Initialize()
    {
        // Get a reference to the storage service, using the default Firebase App
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;


        // Create a root reference
        storageRef = storage.RootReference;


    }


    public async Task UploadFromLocalFile(Uranaishi uranaishi, string iconLocalFilePath)
    {
        // 画像を選択しなかったとき
        if (iconLocalFilePath == null) return;

        // File located on disk
        string localFile = iconLocalFilePath;

        // Create a reference to the file you want to upload
        StorageReference iconRef = storageRef.Child(uranaishi.id).Child("images").Child("icon.jpg");
        // uranaishi.iconStorageFilePath = iconRef.Path;

        // Upload the file to the path "images/rivers.jpg"
        await iconRef.PutFileAsync(localFile)
        .ContinueWith((Task<StorageMetadata> task) =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log(task.Exception.ToString());
                // Uh-oh, an error occurred!
            }
            else
            {
                // Metadata contains file metadata such as size, content-type, and download URL.
                StorageMetadata metadata = task.Result;
                string md5Hash = metadata.Md5Hash;
                Debug.Log("Finished uploading...");
                Debug.Log("md5 hash = " + md5Hash);
            }
        });
    }


    public async Task DownloadFile(Uranaishi uranaishi, UnityAction<Sprite> onComplete)
    {

        StorageReference iconRef = storageRef.Child(uranaishi.id).Child("images").Child("icon.jpg");


        // Fetch the download URL
        await iconRef.GetDownloadUrlAsync().ContinueWithOnMainThread(async task =>
        {
            //    await task;
            if (!task.IsFaulted && !task.IsCanceled)
            {
                // Debug.Log("Download URL: " + task.Result.ToString());
                // Debug.Log("画像のダウンロード開始 " + uranaishi.id);
                // ... now download the file via WWW or UnityWebRequest.
                Sprite sprite = await LoadTexture(task.Result.ToString());
                onComplete(sprite);
            }
        });

    }


    private async Task<Sprite> LoadTexture(string uri)
    {
        Sprite sprite = null;
        // Debug.Log("画像のダウンロード開始");
        var request = UnityWebRequestTexture.GetTexture(uri);
        await request.SendWebRequest();
        // Debug.Log("画像のダウンロード終了");


        if (request.result == UnityWebRequest.Result.ConnectionError
        || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
            return sprite;
        }

        try
        {
            // https://www.hanachiru-blog.com/entry/2019/07/12/233000
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero); ;
            // Debug.Log("ダウンロード完了");
            return sprite;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            return sprite;
        }
    }



}
