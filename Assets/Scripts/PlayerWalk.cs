using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalk : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction lookAction;

    [SerializeField] float speed;
    [SerializeField] float mouseSpeed;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        lookAction = playerInput.actions.FindAction("Look");
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
    }

    void RotatePlayer()
    {
        Vector2 mouseDelta = lookAction.ReadValue<Vector2>();   
        Vector2 lookInput = mouseDelta * mouseSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * lookInput.x);
    }
}
