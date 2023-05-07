using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MouseDelta;
    public Vector2 MoveComposite;
    public bool interact;

    private Controls controls;

    private void OnEnable(){
        if (controls != null) return;
        
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    public void OnDisable(){
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context){
        MoveComposite = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context){
        interact = true;
    }

    public void OnSprint(InputAction.CallbackContext context){
        if (!context.performed) return;
        return;
    }

    public void OnLook(InputAction.CallbackContext context){
        MouseDelta = context.ReadValue<Vector2>();
    }
}
