using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAdditionalAnimation : MonoBehaviour
{
    [SerializeField]
    public GameObject nextAnimation;
    [SerializeField]
    public GameObject lastAnimation;

    public void playNextAnimation(){
        lastAnimation.SetActive(false);
        nextAnimation.SetActive(true);
    }
}
