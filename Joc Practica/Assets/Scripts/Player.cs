using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float playerWidth=.7f;
    [SerializeField] private float playerHeight = 2f;
    [SerializeField] private LayerMask counterLayerMask;
    private bool isWalking;
    private Vector3 lastInteractDir;
     private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;  
    }
    private void GameInput_OnInteractAction(object sender,System.EventArgs e)
    {
        Vector2 inputVector = gameInput.GetInputVector2Normalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //HAS CLEARCOUNTER
                clearCounter.Interact();
            }
        }
    }
    private void Update()
    {
        HandleMovement();
        HanleInteractions();

    }
    public bool IsWalking()
    {
        return isWalking;
    }

    private void HanleInteractions()
    {
        Vector2 inputVector = gameInput.GetInputVector2Normalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if(moveDir!=Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance,counterLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //HAS CLEARCOUNTER
                
            }
        }
        
    }
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetInputVector2Normalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;


        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, moveDir, moveDistance);
        if (!canMove)
        {
            //cant move forward

            //try move on x
            Vector3 xDirection = new Vector3(moveDir.x, 0, 0).normalized;
            bool canMoveX = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, xDirection, moveDistance);

            if (canMoveX)
            {
                //can move only on x
                canMove = true;
                moveDir = xDirection;
            }
            //i cant move on x try on z
            else
            {
                Vector3 zDirection = new Vector3(0, 0, moveDir.z).normalized;
                bool canMoveZ = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, zDirection, moveDistance);
                if (canMoveZ)
                {
                    //can move only on z
                    canMove = true;
                    moveDir = zDirection;
                }
                else
                {
                    //cant move in any direction
                }

            }

        }
        var step = moveDir * moveDistance;
        if (canMove)
        {
            transform.position += step;
        }


        isWalking = moveDir != Vector3.zero;
        //rotateSpeed = 10f;


        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        //Debug.Log(Time.deltaTime);
    }
}
