using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class OpenDoor : MonoBehaviour
{
    public InputReader InputReader { get; private set; }
    private bool isOpen;

    void Start(){
        InputReader = GameObject.Find("Player").GetComponent<InputReader>();
        isOpen = false;
    }

    void OnTriggerEnter(Collider collider){
        //output dialogue to open gate here
        Debug.Log("Press E to open gate.");
    }

    void OnTriggerStay(Collider collider){
        if (collider.name == "Player")
            if (InputReader.interact == true){

                StartCoroutine(rotateDoor());
                InputReader.interact = false;
            }
    }

    private IEnumerator rotateDoor(){
        gameObject.GetComponent<Collider>().enabled = false;
        for (int i=0; i<90; i++){
            if (isOpen)
                gameObject.transform.rotation = Quaternion.Euler(0,90-i, 0);
            else
                gameObject.transform.rotation = Quaternion.Euler(0, 0+i, 0);
            yield return new WaitForSeconds(0.01f);
        }
        if (isOpen)
            isOpen = false;
        else
            isOpen = true;
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
