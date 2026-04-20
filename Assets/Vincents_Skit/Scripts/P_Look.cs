using UnityEngine;
using UnityEngine.InputSystem;

public class P_Look : MonoBehaviour
{
    [SerializeField] float mouseSens = 150f;
    float xRot;

    InputActionMap player;
    InputAction look;
    
    void Start()
    {
        player = InputSystem.actions.FindActionMap("Player");
        look = player.FindAction("Look");
        player.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        
    }

    
    void Update()
    {
        Look();
        
    }

    void Look()
    {
        Vector2 lookValue = look.ReadValue<Vector2>();
        float xLook = lookValue.x * mouseSens * Time.deltaTime;
        float yLook = lookValue.y * mouseSens * Time.deltaTime;

        xRot -= yLook;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        transform.parent.Rotate(Vector3.up, xLook, Space.World);
    }

}
