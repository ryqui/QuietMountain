using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDialogScript : MonoBehaviour
{
    [SerializeField]
    public GameObject outputDialog;

    public void OutputDialog(){
        outputDialog.GetComponent<Dialogue>().StartDialogue();
    }

    public void RemoveDialogue(){
        Debug.Log("Removing cutscene dialogue");
        //outputDialog.GetComponent<Dialogue>().NextLine();
        outputDialog.GetComponent<Dialogue>().textComponent.text = string.Empty;
        outputDialog.SetActive(false);
    }
}
