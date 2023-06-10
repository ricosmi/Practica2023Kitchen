using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;


    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions=new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed; 
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        OnInteractAction?.Invoke(this,EventArgs.Empty); //if(OnInteractAction!=null) 
    }

    public Vector2 GetInputVector2Normalized()
    {
        
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        

        inputVector = inputVector.normalized;
        //Debug.Log(inputVector);
        return inputVector;
    }
    
}
