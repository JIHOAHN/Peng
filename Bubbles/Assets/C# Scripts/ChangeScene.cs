using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void Link (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        sceneName = "Squares";
    }

    public void SecondLink (string description)
    {
        SceneManager.LoadScene(description);
        description = "Description";
    }

    public void Menu (string main)
    {
        SceneManager.LoadScene(main);
        main = "MainMenu";
    }

}
