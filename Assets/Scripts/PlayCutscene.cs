using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutscene : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if (collider.name == "Player"){
            collider.GetComponent<PlayerStateMachine>().StartCutscene();
            Debug.Log("Valid trigger for cutscene.");
        }
    }
}
