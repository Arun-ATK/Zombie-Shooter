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

    [Header("Rotation Variables")]
    public float rotationSpeed;

    [Header("Player Input")]
    private PlayerInput playerControls;
    private InputAction moveInputAction;
    private InputAction lookInputAction;

    private Rigidbody rb;

    private void Awake()
    {
        playerControls = new PlayerInput();
    }

    private void OnEnable()
    {
        moveInputAction = playerControls.Player.Move;
        moveInputAction.Enable();

        lookInputAction = playerControls.Player.Look;
        lookInputAction.performed += OnMousePos;
        lookInputAction.Enable();
    }

    private void OnDisable()
    {
        moveInputAction.Disable();
        lookInputAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
    }

    private void MovePlayer()
    {
        moveDirection = moveInputAction.ReadValue<Vector2>();
        float moveMagnitude = moveDirection.normalized.magnitude;

        smoothMoveMagnitude = Mathf.SmoothDamp(smoothMoveMagnitude, moveMagnitude, ref velocity, smoothMoveTime);
        moveDirection *= smoothMoveMagnitude;
    }

    private void OnMousePos(InputAction.CallbackContext context)
    {
        Vector3 mousePosOnScreen = context.ReadValue<Vector2>();
        mousePosOnScreen.z = Camera.main.transform.position.y;

        Vector3 turnDirection = (Camera.main.ScreenToWorldPoint(mousePosOnScreen) - transform.position).normalized;
        float turnAngle = Vector3.SignedAngle(transform.forward, turnDirection, transform.up);

        Quaternion turnQ = Quaternion.Euler(0, turnAngle * rotationSpeed, 0);
        transform.forward = turnQ * transform.forward;
    }
}
