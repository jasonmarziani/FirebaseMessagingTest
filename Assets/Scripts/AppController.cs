using UnityEngine;

public class AppController : MonoBehaviour 
{

    public static AppController Instance { get { return _instance; } }
    private static AppController _instance;
    private FirebaseManager _firebaseManager;
	private Invites _invites;

    private void Awake() 
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
		Application.targetFrameRate = 60;
		SetupFirebase();
    }
		
    private void SetupFirebase()
    {
        _firebaseManager = new FirebaseManager();
        _firebaseManager.Init(() => {
			_invites = new Invites();
		});
    }

}
