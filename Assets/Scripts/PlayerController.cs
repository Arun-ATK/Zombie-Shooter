using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public float moveSpeed;
    public float smoothMoveTime;
    private Vector3 moveDirection;
    private float smoothMoveMagnitude;
    private float velocity;

    [Header("Player Input")]
    private PlayerInput playerControls;
    private InputAction move;

    private Rigidbody rb;

    private void Awake()
    {
        playerControls = new PlayerInput();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        float moveMagnitude = moveDirection.normalized.magnitude;

        smoothMoveMagnitude = Mathf.SmoothDamp(smoothMoveMagnitude, moveMagnitude, ref velocity, smoothMoveTime);

        moveDirection *= smoothMoveMagnitude;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
    }
}
