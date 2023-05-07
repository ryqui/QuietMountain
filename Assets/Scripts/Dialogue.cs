using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string [] lines ; 
    public float textSpeed;
    private int index;
    private bool collide = false;
    

  void OnTriggerEnter(Collider other)
    {      textComponent.text= string.Empty;
        if (other.CompareTag("Player")) 
        {  collide = true;
            StartDialogue();}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && collide)
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text=lines[index];
            }
        }
    }

    void StartDialogue()
    {   index =0;
 
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char x in lines[index].ToCharArray())
        {
            textComponent.text += x;
            yield return new WaitForSeconds(textSpeed);            
        }
    }

void NextLine()
{
    if(index<lines.Length-1)
    {
        index++;
        textComponent.text= string.Empty;
        StartCoroutine(TypeLine());
    }
    else
    {   textComponent.text= string.Empty;
        gameObject.SetActive(false);
    }

}

}
