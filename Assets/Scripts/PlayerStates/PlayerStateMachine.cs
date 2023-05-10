using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : StateMachine
{
    public Vector3 Velocity;
    public float MovementSpeed { get;  set; } = 5f;
    public float DefaultSpeed { get;  private set; } 
    public float SprintSpeed { get; private set; } = 7f;
    public static int Hp { get;  set; } = 1;
    public float LookRotationDampFactor { get; private set; } = 10f;
    public Transform MainCamera { get; private set; }
    public InputReader InputReader { get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }
    [SerializeField]
    private CinemachineFreeLook freeLook;

    public GameObject MainCameraObject;
    public GameObject CutsceneCamera;
    public GameObject CutscenePlayerCamera;

    private Vector3 prevVelocity;
    private float prevDefaultSpeed;

    void Start()
    {  
        DefaultSpeed = MovementSpeed;
        MainCamera = Camera.main.transform;

        InputReader = GetComponent<InputReader>();
        Animator = GameObject.Find("Harry").GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();

        SwitchState(new PlayerMoveState(this));
    }


    public static void TakeDamage(int damage){
        Hp -= damage; 
        if(Hp <= 0)
        { 
         GameObject.FindGameObjectWithTag("Player").SetActive(false); 
         SceneManager.LoadScene(4);  

        }

    }
    
    public void DisableMovement(){
        Debug.Log("Disabling player movement.");
        prevVelocity = Velocity;
        prevDefaultSpeed = DefaultSpeed;
        MovementSpeed = 0f;
        DefaultSpeed = 0f;
        SprintSpeed = 0f;
        Velocity = new Vector3(0f,0f,0f);
        freeLook.enabled = false;
    }

    public void EnableMovement(){
        Debug.Log("Enabling player movement.");
        Velocity = prevVelocity;
        MovementSpeed = 5f;
        DefaultSpeed = prevDefaultSpeed;
        SprintSpeed = 7f;
        Velocity = prevVelocity;
        freeLook.enabled = true;
    }

         void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("ToAlley")) 
             SceneManager.LoadScene(3);   
    }



}
