using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalk : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction lookAction;
    public CinemachineCamera virtualCamera;
    private Vector2 _rotation;

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
        Vector3 move = new Vector3(direction.x, 0, direction.y);
        move = transform.TransformDirection(move);
        transform.position += move * speed * Time.deltaTime;
    }

    void RotatePlayer()
    {
        Vector2 mouseDelta = lookAction.ReadValue<Vector2>();
        _rotation.x += -mouseDelta.y * mouseSpeed * 0.05f;
        _rotation.y += mouseDelta.x * mouseSpeed * 0.1f;
        transform.rotation = Quaternion.Euler(0, _rotation.y, 0);
    }
}
