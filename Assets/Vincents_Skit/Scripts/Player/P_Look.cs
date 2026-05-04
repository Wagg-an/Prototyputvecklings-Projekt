using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class P_Look : MonoBehaviour
{
    [SerializeField] float mouseSens = 150f;
    float mouseSenseUpdated;
    float xRot;

    public Slider slide;
    
    public TMP_Text displaySenseText;


    InputActionMap player;
    InputAction look;
    
    void Start()
    {
        player = InputSystem.actions.FindActionMap("Player");
        look = player.FindAction("Look");
        player.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        
        mouseSenseUpdated = mouseSens;
        displaySenseText.text = (Mathf.Round(slide.value * 100)).ToString() + "%";;
    }

    
    void Update()
    {
        Look();
    }

    void Look()
    {
        Vector2 lookValue = look.ReadValue<Vector2>();
        float xLook = lookValue.x * mouseSenseUpdated * Time.deltaTime;
        float yLook = lookValue.y * mouseSenseUpdated * Time.deltaTime;

        xRot -= yLook;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        transform.parent.Rotate(Vector3.up, xLook, Space.World);
    }

    public void changeSense()
    {
        mouseSenseUpdated = slide.value * mouseSens;
        displaySenseText.text = (Mathf.Round(slide.value * 100)).ToString() + "%";

    }

}
