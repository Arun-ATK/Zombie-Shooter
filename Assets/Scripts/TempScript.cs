using UnityEngine;
using UnityEngine.InputSystem;

public class TempScript : MonoBehaviour
{
    private PlayerInput playerInputSystem;
    private InputAction lookInputAction;
    
    private void Awake()
    {
        playerInputSystem = new PlayerInput();
    }

    private void OnEnable()
    {
        lookInputAction = playerInputSystem.Player.Look;
        lookInputAction.performed += OnMousePos;
        lookInputAction.Enable();
    }

    private void OnDisable()
    {
        lookInputAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMousePos(InputAction.CallbackContext context)
    {
        Vector3 mousePosOnScreen = context.ReadValue<Vector2>();
        mousePosOnScreen.z = Camera.main.transform.position.y;
        Vector3 mousePosOnWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);


        print(mousePosOnWorld);
    }
}
