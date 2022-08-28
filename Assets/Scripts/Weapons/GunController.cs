using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GunController : MonoBehaviour
{
    [Header("PlayerInput")]
    private PlayerInput playerControls;
    private InputAction fireInputAction;
    private InputAction lookInputAction;

    private void OnEnable()
    {
        fireInputAction = playerControls.Player.Fire;
        fireInputAction.performed += OnFire;
        fireInputAction.Enable();

        lookInputAction = playerControls.Player.Look;
        lookInputAction.Enable();
    }

    private void OnDisable()
    {
        fireInputAction.Disable();
        lookInputAction.Disable();
    }

    private void Awake()
    {
        playerControls = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        if (context.interaction is PressInteraction) {
            print("Fire pressed");
        }

        if (context.interaction is HoldInteraction) {
            print("Fire Held");
        }

        if (context.interaction is TapInteraction) {
            print("Fire tapped");
        }
    }
}
