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
    public Collider col { get; private set; }
    public PlayerStateMachine playerStateMachine;
    [SerializeField]
    public bool preventMovement = true;
    [SerializeField]
    public bool removeAfterFinish = true;
    
    void Start()
    {   
        col = GetComponent<Collider>(); 
        InputReader = GetComponent<InputReader>();
    }

    void OnTriggerEnter(Collider other)
    {   
        textComponent.text= string.Empty;
        if (other.CompareTag("Player")) 
        {  
            collide = true;
            //col.isTrigger =  stopMovement ? false : true ;
            StartDialogue();
        }
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

    public void StartDialogue()
    {   
        index = 0;
        if (preventMovement){
            playerStateMachine = GameObject.Find("Player").GetComponent<PlayerStateMachine>();
            playerStateMachine.DisableMovement();
        }
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {    
        lines[index] = lines[index].Contains("\\") ? lines[index].Replace("\\", "\n") :lines[index];

        foreach (char x in lines[index].ToCharArray())
        {
            textComponent.text += x;
       
            yield return new WaitForSeconds(textSpeed);            
        }
    }

    public void NextLine()
    {
        if(index<lines.Length-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {   
            textComponent.text = string.Empty;
            if (removeAfterFinish)
                gameObject.SetActive(false);
            
            if (preventMovement){
                playerStateMachine.EnableMovement();
            }
        }

    }

}
