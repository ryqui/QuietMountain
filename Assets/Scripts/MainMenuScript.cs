using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame ()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
     public void Credits ()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
     public void Menu ()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }
}
