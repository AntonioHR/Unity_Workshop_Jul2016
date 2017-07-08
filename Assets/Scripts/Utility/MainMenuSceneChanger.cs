using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneChanger : MonoBehaviour {
    public int gameSceneIndex = 0;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void GoToGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneIndex);
    }
}
