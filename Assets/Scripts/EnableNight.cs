using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNight : MonoBehaviour
{
    public GameObject lightObject;
    public Light lightSource;
    public bool DisableOnCollide = true;
    private bool collided;
    public Animator animator;

    public void Awake(){
        lightObject = GameObject.Find("Lighter");
        lightSource = lightObject.GetComponent<Light>();
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
        if (lightSource.intensity > 0){
            animator.SetBool("HoldLighter", false);
            while (lightSource.intensity > 0 || RenderSettings.ambientIntensity < 1){
                lightSource.intensity -= (lightSource.intensity > 0 ? 0.01f : 0);
                RenderSettings.ambientIntensity += (RenderSettings.ambientIntensity < 1 ? 0.01f : 0);
                yield return new WaitForSeconds(0.01f);
            }
        }
        else{
            animator.SetBool("HoldLighter", true);
            while (lightSource.intensity < 1.2 || RenderSettings.ambientIntensity > 0){
                lightSource.intensity += (lightSource.intensity < 1.2 ? 0.01f : 0);
                RenderSettings.ambientIntensity -= (RenderSettings.ambientIntensity > 0 ? 0.01f : 0);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
