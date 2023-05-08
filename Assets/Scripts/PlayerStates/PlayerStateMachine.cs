using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : StateMachine
{
    public Vector3 Velocity;
    public float MovementSpeed { get;  set; } = 5f;
    public float DefaultSpeed { get;  private set; } 
    public float SprintSpeed { get; private set; } = 7f;
    public static int Hp { get;  set; } = 100;
    public float LookRotationDampFactor { get; private set; } = 10f;
    public Transform MainCamera { get; private set; }
    public InputReader InputReader { get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }

    void Start()
    {  
        DefaultSpeed = MovementSpeed;
        MainCamera = Camera.main.transform;

        InputReader = GetComponent<InputReader>();
        Animator = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();

        SwitchState(new PlayerMoveState(this));
    }


    public static void TakeDamage(int damage){
        Hp -= damage; 
        if(Hp <= 0)
         GameObject.FindGameObjectWithTag("Player").SetActive(false); 

    }
    
}
