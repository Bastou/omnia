using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is used to transition between scenes. This includes triggering all the things that need to happen on transition such as data persistence.
/// </summary>
public class SceneController : MonoBehaviour
{
    public static SceneController Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = FindObjectOfType<SceneController>();

            if (instance != null)
                return instance;

            Create ();

            return instance;
        }
    }

    public static bool Transitioning
    {
        get { return Instance.m_Transitioning; }
    }

    protected static SceneController instance;

    public static SceneController Create ()
    {
        GameObject sceneControllerGameObject = new GameObject("SceneController");
        instance = sceneControllerGameObject.AddComponent<SceneController>();

        return instance;
    }

    protected Scene m_CurrentZoneScene;
    protected bool m_Transitioning;

    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

            

//            if (initialSceneTransitionDestination != null)
//            {
//                
//                ScreenFader.SetAlpha(1f);
//                StartCoroutine(ScreenFader.FadeSceneIn());
//                
//            }
//            else
//            {
//                m_CurrentZoneScene = SceneManager.GetActiveScene();
//                m_ZoneRestartDestinationTag = SceneTransitionDestination.DestinationTag.A;
//            }
    }
        
    public void LoadScene(string newSceneName)
    {
        StartCoroutine(Transition(newSceneName));
    }

    private IEnumerator Transition(string newSceneName)
    {
        m_Transitioning = true;
        
        yield return StartCoroutine(ScreenFader.FadeSceneOut(ScreenFader.FadeType.Loading));
        //yield return new WaitForSeconds(2f);
        //yield return SceneManager.LoadSceneAsync(newSceneName);
        AsyncOperation operation = SceneManager.LoadSceneAsync (newSceneName);
        yield return StartCoroutine(ScreenFader.ProgressBarUpdate(operation));
            
        //SetupNewScene(transitionType, entrance);
            
        yield return StartCoroutine(ScreenFader.FadeSceneIn());
            
        m_Transitioning = false;
    }

}