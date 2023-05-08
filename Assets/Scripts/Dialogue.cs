using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(InputReader))]

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string [] lines ; 
    public float textSpeed;
    private int index;
    private bool collide = false;
    public InputReader InputReader { get; private set; }
    public bool stopMovement = true; 
    public Collider col { get; private set; }
    
    void Start()
    {   col = GetComponent<Collider>(); 
        InputReader = GetComponent<InputReader>();
    }
  void OnTriggerEnter(Collider other)
    {   
        textComponent.text= string.Empty;
        if (other.CompareTag("Player")) 
        {  collide = true;
            col.isTrigger = stopMovement ? false : true ;
            StartDialogue();}
    }

    // Update is called once per frame
    void Update()
    {
        if(InputReader.interact == true && collide)
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
            InputReader.interact = false;
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
