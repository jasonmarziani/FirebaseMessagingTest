using Firebase;
using System;
using UnityEngine;

public class FirebaseManager 
{

  	private DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    private const string NumberOpensKey = "FirebaseManager.NumberOpensKey";

    private int NumberOpens
    {
        get { return PlayerPrefs.GetInt(NumberOpensKey, 0); }
        set { PlayerPrefs.SetInt(NumberOpensKey, value); }
    }

    public void Init(Action completion) 
    {
        dependencyStatus = FirebaseApp.CheckDependencies();
        if (dependencyStatus != DependencyStatus.Available) 
        {
            FirebaseApp.FixDependenciesAsync().ContinueWith(task => 
            {
                dependencyStatus = FirebaseApp.CheckDependencies();
                if (dependencyStatus == DependencyStatus.Available) 
                {
					if (NumberOpens > 2) 
					{
						Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
						Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
					} 
					else 
					{
						NumberOpens++;
					}
                    if (completion != null) completion.Invoke();
                } 
                else 
                {
                    Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        } 
		else 
		{
            if (completion != null) completion.Invoke();
        }
    }
		
	public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token) 
	{
		UnityEngine.Debug.Log("*** Received Registration Token: " + token.Token);
	}

	public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e) 
	{
		UnityEngine.Debug.Log("*** Received a new message from: " + e.Message.From);
		UnityEngine.Debug.Log("*** message data: " + e.Message.Data);
		UnityEngine.Debug.Log("*** message raw: " + e.Message.RawData);
	}

}
