using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectionOnLoadPersistantAssets : MonoBehaviour
{

	public string sceneName;
	//private MenuCtrl MenuCtrl;

	//private SceneController SceneController;
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
		//SceneController = GameObject.Find("SceneController").GetComponent<SceneController>();

		if (SceneController.Instance && GameControl)
		{
			//DontDestroyOnLoad(SceneController);
			Debug.Log("All persistant objects loaded");
			SceneController.Instance.LoadScene(sceneName);
		}
		else
		{
			Debug.Log("Error loading persistant objects");
		}
	}
}
