using Firebase.Invites;
using System.Threading.Tasks;
using UnityEngine;

public class Invites 
{

	public Invites()
	{
		FirebaseInvites.InviteReceived += OnInviteReceived;
		FirebaseInvites.InviteNotReceived += OnInviteNotReceived;
		FirebaseInvites.ErrorReceived += OnErrorReceived;
	}

	private void OnInviteReceived(object sender, Firebase.Invites.InviteReceivedEventArgs e) 
	{
		if (e.InvitationId != "") {
			Firebase.Invites.FirebaseInvites.ConvertInvitationAsync(e.InvitationId).ContinueWith(HandleConversionResult);
		} 
	}

	private void HandleConversionResult(Task convertTask)
	{
		if (convertTask.IsCanceled) {
			Debug.Log("Firebase Invite: Conversion canceled.");
		} else if (convertTask.IsFaulted) {
			Debug.Log("Firebase Invite: Conversion encountered an error:");
			Debug.Log(convertTask.Exception.ToString());
		} else if (convertTask.IsCompleted) {
			Debug.Log("Firebase Invite: Conversion completed successfully!");
		}
	}

	private void OnInviteNotReceived(object sender, System.EventArgs e) 
	{
		Debug.Log("FirebaseManager: No Invite or Deep Link received on start up");
	}

	private void OnErrorReceived(object sender, Firebase.Invites.InviteErrorReceivedEventArgs e) 
	{
		Debug.LogError("FirebaseManager: Error occurred received the invite: " + e.ErrorMessage);
	}
}
