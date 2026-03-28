using UnityEngine;
using UnityEngine.InputSystem;

public class HumanMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController controller;

    private Vector3 moveDirection;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector3>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3( hInput, 0, vInput);

        if(moveDirection.magnitude >= 0.1)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        float hVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;
        animator.SetFloat("HVelocity", hVelocity);
    }
}
