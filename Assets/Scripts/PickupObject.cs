using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PickupObject : MonoBehaviour
{
    public InputReader InputReader { get; private set; }

    void Start(){
        InputReader = GetComponent<InputReader>();
    }

    void OnTriggerEnter(Collider collider){
        //output dialogue to pick up object here
        Debug.Log("Press E to pick up object");
    }

    void OnTriggerStay(Collider collider){
        if (collider.name == "Player")
            if (InputReader.interact == true){
                gameObject.SetActive(false);
                InputReader.interact = false;
            }
    }
}
