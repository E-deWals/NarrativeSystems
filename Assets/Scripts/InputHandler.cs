using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public PlayerController characterController;
    public StirringGame stirringGame;
    [SerializeField] private CinemachineInputAxisController inputController;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction mouseAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("RMB");
        mouseAction = InputSystem.actions.FindAction("Look");
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

    public void ExportMousePosition()
    {
        stirringGame.CheckIfCircle(mouseAction.ReadValue<Vector2>());
    }


}
