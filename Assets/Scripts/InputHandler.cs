using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public PlayerController characterController;
    [SerializeField] private CinemachineInputAxisController inputController;

    private InputAction moveAction;
    private InputAction lookAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("RMB");
    }

    private void Update()
    {
        Vector2 movementVector = moveAction.ReadValue<Vector2>();
        characterController.Move(movementVector);

        bool isclicked = lookAction.IsPressed();
        if (isclicked)
        {
            inputController.enabled = true;
            Cursor.visible = false;
        }
        else
        {
            inputController.enabled = false;
            Cursor.visible = true;
        }
    }


}
