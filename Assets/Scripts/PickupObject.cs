using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PickupObject : MonoBehaviour
{
    public InputReader InputReader { get; private set; }

    [SerializeField]
    public GameObject pickupDialogue;
    [SerializeField]
    public bool removeObject = true;

    void Start(){
        InputReader = GetComponent<InputReader>();
    }

    void OnTriggerEnter(Collider collider){
        pickupDialogue.SetActive(true);
    }

    void OnTriggerExit(Collider collider){
        pickupDialogue.SetActive(false);
    }

    void OnTriggerStay(Collider collider){
        if (collider.name == "Player")
            if (InputReader.interact == true && removeObject){
                gameObject.SetActive(false);
                pickupDialogue.SetActive(false);
                InputReader.interact = false;
            }
    }
}
