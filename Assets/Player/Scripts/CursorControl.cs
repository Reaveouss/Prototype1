using UnityEngine;
using UnityEngine.InputSystem;

public class CursorControl : MonoBehaviour
{
    private Vector2 lookInput;
    private InputSystem_Actions controls;
    public float rotationSpeed = 1.0f;
    private Quaternion targetAngle;
    private Quaternion currentAngle;
    private float timer;
    /*
     * private void OnEnable()
    {
        controls = new InputSystem_Actions();
        controls.Player.Look.performed += OnLook;
        controls.Player.Look.canceled += ctx => lookInput = Vector2.zero;
        controls.Enable();
    }
    */
    private void Update()
    {
        timer += Time.deltaTime;
        if (transform.rotation != targetAngle)
        {
            transform.rotation = Quaternion.Slerp(currentAngle, targetAngle, rotationSpeed * timer);
        }
        if (transform.rotation == targetAngle)
        {
            timer = 0;
        }
    }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();

        if (!(lookInput.y == 0 && lookInput.x == 0))
        {
            float angle = Mathf.Atan2(lookInput.y, lookInput.x) * Mathf.Rad2Deg;
            targetAngle = Quaternion.Euler(new Vector3(0, 0, angle));
            currentAngle = transform.rotation;
            
        }
    }
}
