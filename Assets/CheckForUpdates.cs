using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Collections.Generic;
using System.Collections;

public class CheckForUpdates : MonoBehaviour
{
    public static DatabaseReference reference;
    private Dictionary<string, object> dataBase;
    private bool dataBaseIsReady = false;
    void Awake()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://weightbreaker-29157830.firebaseio.com/");
        CheckForGoogleServicesUpdate();
    }



    // Start is called before the first frame update
    void Start()
    {
        InitializeDatabaseObject();
        StartCoroutine("CheckForGameVersion");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator CheckForGameVersion()
    {
        yield return new WaitUntil(() => dataBaseIsReady);
        Debug.Log(dataBase["version"].ToString()== Application.version);


    }
    private void CheckForGoogleServicesUpdate()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                reference = FirebaseDatabase.DefaultInstance.RootReference;
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void InitializeDatabaseObject()
    {
        reference.GetValueAsync().ContinueWith(task =>
        {

            if (task.IsFaulted)
            {
                Debug.Log(task.Result);
            }
            else if (task.IsCompleted)
            {

                DataSnapshot snapshot = task.Result;
                dataBase = snapshot.GetValue(true) as Dictionary<string, object>;
                dataBaseIsReady = true;
            }
            else
            {
                Debug.Log(task.Result);
            }
        });

    }
}
