using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNight : MonoBehaviour
{
    public GameObject lightObject;
    public Light light;
    public bool DisableOnCollide = true;
    private bool collided;
    public Animator animator;

    public void Awake(){
        lightObject = GameObject.Find("Lighter");
        light = lightObject.GetComponent<Light>();
        collided = false;
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }
    
    void OnTriggerEnter(Collider collider){
        if (collided == false && collider.name == "Player"){
            StartCoroutine(ChangeLight());
            
            if (DisableOnCollide == true)
                collided = true;
        }
    }

    private IEnumerator ChangeLight(){
        if (light.intensity > 0){
            animator.SetBool("HoldLighter", false);
            while (light.intensity > 0){
                light.intensity -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else{
            animator.SetBool("HoldLighter", true);
            while (light.intensity < 1.2){
                light.intensity += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
