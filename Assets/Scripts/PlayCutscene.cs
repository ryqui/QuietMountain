using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutscene : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cutscenesToPlay = null;

    [SerializeField]
    private GameObject blackCamera = null;

    private int animationIndex = 0;

    private PlayerStateMachine player;
    private Collider collidedObject;
    
    public void OnTriggerEnter(Collider collider){
        collidedObject = collider;
        if (collider.name == "Player"){
            Activate();
        }
    }

    public void Activate(){
        if (cutscenesToPlay.Length == 0){
            Debug.Log("No animations provided");
            return;
        }

        player = collidedObject.GetComponent<PlayerStateMachine>();
        player.DisableMovement();
        
        cutscenesToPlay[animationIndex].SetActive(true);
        player.CutsceneCamera.SetActive(true);
        player.CutscenePlayerCamera.SetActive(true);
        player.MainCameraObject.SetActive(false);
    }

    public void PlayNextAnimation(){
        blackCamera.SetActive(true);
        cutscenesToPlay[animationIndex].SetActive(false);
        cutscenesToPlay[animationIndex+1].SetActive(true);
        blackCamera.SetActive(false);
        animationIndex++;
    }

    public void Deactivate(){
        cutscenesToPlay[animationIndex].SetActive(false);
        //RemoveDialogue();
        
        Debug.Log("Deactivating cutscene(s).");
        
        player.GetComponent<PlayerStateMachine>().EnableMovement();
        player.CutsceneCamera.SetActive(false);
        player.CutscenePlayerCamera.SetActive(false);
        player.MainCameraObject.SetActive(true);
        
        gameObject.SetActive(false);
    }

    public void PlayDialogue(){
        cutscenesToPlay[animationIndex].GetComponent<RunDialogScript>().OutputDialog();
    }

    public void RemoveDialogue(){
        cutscenesToPlay[animationIndex].GetComponent<RunDialogScript>().RemoveDialogue();
    }
} 
