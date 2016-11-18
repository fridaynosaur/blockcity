using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnvironmentLoader : MonoBehaviour
{
    public string sceneName;

	// Use this for initialization
	void Start ()
    {
        LoadEnvironment(sceneName);
	}

    private void LoadEnvironment(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            return;
        }

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
