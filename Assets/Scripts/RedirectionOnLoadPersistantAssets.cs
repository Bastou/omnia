using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectionOnLoadPersistantAssets : MonoBehaviour {
	
	public string sceneName;

	private GameObject NavigationManager;
	private GameObject GameControl;

	// Use this for initialization
	void Start ()
	{
		sceneName = "Menu";
		GameControl = GameObject.Find("GameControl");
		NavigationManager = GameObject.Find("NavigationManager");

		if (NavigationManager && GameControl)
		{
			DontDestroyOnLoad (NavigationManager);
			loadScene();
			Debug.Log("All persistant assets loaded");
		}
		else
		{
			Debug.Log("Error loading persistant GameObject");
		}
		
	}
	
	
	// Refacto pour appeler loadScene dans NavigationManager
	public void loadScene()
	{
		if (sceneName != null || sceneName != "")
		{
			print("loadScene : " + sceneName);
			SceneManager.LoadScene (sceneName);    
		}
		else
		{
			print("loadScene : sceneName null");
		}
	} 
}
