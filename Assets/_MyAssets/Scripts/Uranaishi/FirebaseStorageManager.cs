using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Firebase.Storage;
using Firebase.Extensions;
using UnityEngine.Networking;
using System;
using UnityEngine.Events;


public class FirebaseStorageManager : MonoBehaviour
{
    public static FirebaseStorageManager i;
    StorageReference storageRef;

    private void Awake()
    {
        i = this;
        // Get a reference to the storage service, using the default Firebase App
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;


        // Create a root reference
        storageRef = storage.RootReference;


    }


    public void UploadFromLocalFile(Uranaishi uranaishi, string iconLocalFilePath)
    {
        // 画像を選択しなかったとき
        if (iconLocalFilePath == null) return;

        // File located on disk
        string localFile = iconLocalFilePath;

        // Create a reference to the file you want to upload
        StorageReference iconRef = storageRef.Child(uranaishi.id).Child("images").Child("icon.jpg");
        // uranaishi.iconStorageFilePath = iconRef.Path;

        // Upload the file to the path "images/rivers.jpg"
        iconRef.PutFileAsync(localFile)
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


    public void DownloadFile(Uranaishi uranaishi, UnityAction<Texture2D> onComplete)
    {

        StorageReference iconRef = storageRef.Child(uranaishi.id).Child("images").Child("icon.jpg");


        // Fetch the download URL
        iconRef.GetDownloadUrlAsync().ContinueWithOnMainThread(async task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("Download URL: " + task.Result.ToString());

                // ... now download the file via WWW or UnityWebRequest.
                Texture2D texture = await LoadTexture(task.Result.ToString());

                onComplete(texture);
            }
        });

    }


    private async Task<Texture2D> LoadTexture(string uri)
    {
        Texture2D texture = null;
        Debug.Log("画像のダウンロード開始");
        var request = UnityWebRequestTexture.GetTexture(uri);
        await request.SendWebRequest();
        Debug.Log("画像のダウンロード終了");


        if (request.result == UnityWebRequest.Result.ConnectionError
        || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
            return texture;
        }

        try
        {
            // https://www.hanachiru-blog.com/entry/2019/07/12/233000
            texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Debug.Log("ダウンロード完了");
            return texture;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            return texture;
        }
    }



}
