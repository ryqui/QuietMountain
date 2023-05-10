using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDiner : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
