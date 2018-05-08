using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ScreenFader : MonoBehaviour
{
    // Enumeration du type de fade
    public enum FadeType
    {
        Black, Loading,
    }
        
    // Public screenFader instance || create it
    public static ScreenFader Instance
    {
        get
        {
            if (s_Instance != null)
                return s_Instance;

            s_Instance = FindObjectOfType<ScreenFader> ();

            if (s_Instance != null)
                return s_Instance;

            Create ();

            return s_Instance;
        }
    }
        
    // Public Flag is fading
    public static bool IsFading
    {
        get { return Instance.m_IsFading; }
    }
        
    // Protected instance
    protected static ScreenFader s_Instance;
        
    // Instanciate screenfader
    public static void Create ()
    {
        ScreenFader controllerPrefab = Resources.Load<ScreenFader> ("ScreenFader");
        s_Instance = Instantiate (controllerPrefab);
    }

    // Canvas groups
    public CanvasGroup faderCanvasGroup;
    public CanvasGroup loadingCanvasGroup ;
    public Slider LoadingProgressBar;
    public float fadeDuration = 1f;
        
    // Is currently fading 
    protected bool m_IsFading;
        
    // WTF ?
    const int k_MaxSortingLayer = 32767;

    void Awake ()
    {
        if (Instance != this)
        {
            Destroy (gameObject);
            return;
        }
        
        DontDestroyOnLoad (gameObject);
    }
        
    // Coroutine that take the final alpha and the canvas and update the canvas alpha
    protected IEnumerator Fade(float finalAlpha, CanvasGroup canvasGroup)
    {    
        // Set is fading to true
        m_IsFading = true; 
            
        // Block raycast for the canvas
        canvasGroup.blocksRaycasts = true;
            
        // Set the fade speed
        float fadeSpeed = Mathf.Abs(canvasGroup.alpha - finalAlpha) / fadeDuration;
            
        // while canvas alpha is not approx equal to final alpha set new alpha
        while (!Mathf.Approximately(canvasGroup.alpha, finalAlpha))
        {
            // Set alpha closer to final alpha
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, finalAlpha,
                fadeSpeed * Time.deltaTime);
                
            yield return null; // pause current execution until the end of frame
        }
        // set final alpha value
        canvasGroup.alpha = finalAlpha;
        // set fading false
        m_IsFading = false;
        // Set raycasts false
        canvasGroup.blocksRaycasts = false;
    }
        
    // Sate canvas group alpha
    public static void SetAlpha (float alpha)
    {
        Instance.faderCanvasGroup.alpha = alpha;
    }

    // Fade Scene In & fade current canvas out
    public static IEnumerator FadeSceneIn ()
    {
        CanvasGroup canvasGroup;
        if (Instance.faderCanvasGroup.alpha > 0.1f)
            canvasGroup = Instance.faderCanvasGroup;
        else
            canvasGroup = Instance.loadingCanvasGroup;
            
        yield return Instance.StartCoroutine(Instance.Fade(0f, canvasGroup));

        canvasGroup.gameObject.SetActive (false);
        
        // Reset slider
        if(canvasGroup == Instance.loadingCanvasGroup) 
            Instance.LoadingProgressBar.value = 0;
        
        print("Fade Scene In");
    }
        
    // Fade out scene and fade in fadetype canvas (default black)
    public static IEnumerator FadeSceneOut (FadeType fadeType = FadeType.Black)
    {
        CanvasGroup canvasGroup;
        switch (fadeType)
        {
            case FadeType.Black:
                canvasGroup = Instance.faderCanvasGroup;
                break;
            default:
                canvasGroup = Instance.loadingCanvasGroup;
                break;
        }
            
        canvasGroup.gameObject.SetActive (true);
            
        yield return Instance.StartCoroutine(Instance.Fade(1f, canvasGroup));
        
        print("Fade Scene Out");
    }

    public static IEnumerator ProgressBarUpdate(AsyncOperation operation)
    {
        //print(" has loading progress : " + LoadingProgressBar);
        //if (Instance.LoadingProgressBar) {
            while (!operation.isDone) {
                float progress = Mathf.Clamp01 (operation.progress / 0.9f);
                //Debug.Log (progress);
                Instance.LoadingProgressBar.value = progress;
                print("LoadingProgressBar.value : " + Instance.LoadingProgressBar.value);
                //yield return null;
                yield return new WaitForEndOfFrame();
            }
        //}
        Instance.LoadingProgressBar.value = 1;
    }
}