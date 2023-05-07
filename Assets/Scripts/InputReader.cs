using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MouseDelta;
    public Vector2 MoveComposite;
    public bool interact;
    public bool isSprinting;

    private Controls controls;

    private void OnEnable(){
        if (controls != null) return;
        
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
        interact = false;
        isSprinting = false;
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
        if (context.performed)
            isSprinting = true;
        else if (context.canceled)
            isSprinting = false;
    }

    public void OnLook(InputAction.CallbackContext context){
        MouseDelta = context.ReadValue<Vector2>();
    }
}
