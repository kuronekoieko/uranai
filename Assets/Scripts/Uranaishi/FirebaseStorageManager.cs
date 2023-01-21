using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Firebase.Storage;

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
        // File located on disk
        string localFile = iconLocalFilePath;

        // Create a reference to the file you want to upload
        StorageReference iconRef = storageRef.Child(uranaishi.id).Child("images").Child("icon.jpg");
        uranaishi.iconStorageFilePath = iconRef.Path;

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

}
