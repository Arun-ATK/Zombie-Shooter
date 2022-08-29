using Weapons;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GunController : MonoBehaviour
{
    [Header("PlayerInput")]
    private PlayerInput playerControls;
    private InputAction fireInputAction;
    private InputAction lookInputAction;

    private Gun gun;

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
        gun = gameObject.AddComponent<Pistol>();
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
            if (context.ReadValue<float>() > 0.5) {
                gun.OnPress(gameObject);
            }
            else {
                gun.OnRelease(gameObject);
            }
        }
    }
}
