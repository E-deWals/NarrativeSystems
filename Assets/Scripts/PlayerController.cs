using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] CinemachineCamera cam;
    [SerializeField] private float movementSpeed = 10;
    Animator animator;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Move(Vector2 movementVector)
    {
        transform.forward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        animator.SetFloat("Speed", movementVector.magnitude);
        move = move * movementSpeed * Time.deltaTime;
        characterController.Move(move);
    }
}

