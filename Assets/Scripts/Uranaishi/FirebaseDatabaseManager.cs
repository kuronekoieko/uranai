using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

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

}
