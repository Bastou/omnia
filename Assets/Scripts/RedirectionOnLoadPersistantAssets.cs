using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectionOnLoadPersistantAssets : MonoBehaviour
{

	public string sceneName;
	public MenuCtrl MenuCtrl;

	private GameObject NavigationManager;
	private GameObject GameControl;

	// Use this for initialization
	void Start()
	{
		if (sceneName.Length == 0)
		{
			// If no specific scene is declared, set the default scene to load
			sceneName = "Menu";
		}

		GameControl = GameObject.Find("GameControl");
		NavigationManager = GameObject.Find("NavigationManager");

		if (NavigationManager && GameControl)
		{
			DontDestroyOnLoad(NavigationManager);
			Debug.Log("All persistant objects loaded");
			MenuCtrl.LoadScene(sceneName);
		}
		else
		{
			Debug.Log("Error loading persistant objects");
		}
	}
}
