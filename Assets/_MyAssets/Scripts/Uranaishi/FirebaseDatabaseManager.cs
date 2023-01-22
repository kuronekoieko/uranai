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
        //reference.Child("users").Push().SetRawJsonValueAsync(json);
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


    public async Task<Uranaishi[]> GetUranaishiAry(int count)
    {

        List<Uranaishi> uranaishiList = new List<Uranaishi>();


        await reference.Child("users").LimitToFirst(count)
        .GetValueAsync().ContinueWithOnMainThread(async task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {

                // https://www.project-unknown.jp/entry/firebase-login-vol3_1#DataSnapshot-snapshot--taskResult
                DataSnapshot snapshot = task.Result;
                IEnumerator<DataSnapshot> result = snapshot.Children.GetEnumerator();

                while (result.MoveNext())
                {
                    DataSnapshot data = result.Current;
                    Uranaishi uranaishi = new Uranaishi();
                    JsonUtility.FromJsonOverwrite(data.GetRawJsonValue(), uranaishi);
                    uranaishiList.Add(uranaishi);
                    Debug.Log(uranaishi.id);
                }
            }
        });
        Debug.Log("bbb");

        return uranaishiList.ToArray();
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
    }

}
