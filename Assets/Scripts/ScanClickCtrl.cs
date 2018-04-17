using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScanClickCtrl : MonoBehaviour
{
    public string sceneName;


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
