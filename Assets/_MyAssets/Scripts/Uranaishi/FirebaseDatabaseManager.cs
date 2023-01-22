using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.Events;
using System.Threading.Tasks;



public class FirebaseDatabaseManager : MonoBehaviour
{
    public static FirebaseDatabaseManager i;

    DatabaseReference reference;

    private void Awake()
    {
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        i = this;
    }

    public void SetUserData(Uranaishi uranaishi)
    {
        string json = JsonUtility.ToJson(uranaishi);
        reference.Child("users").Child(uranaishi.id).SetRawJsonValueAsync(json);

    }

    public async Task GetUserData(Uranaishi uranaishi)
    {


        await reference.Child("users").Child(uranaishi.id)
        .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot.GetRawJsonValue());
                JsonUtility.FromJsonOverwrite(snapshot.GetRawJsonValue(), uranaishi);
                // Do something with snapshot...
            }
        });
    }


}
