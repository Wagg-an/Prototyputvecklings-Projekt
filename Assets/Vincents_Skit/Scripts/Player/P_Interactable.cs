using UnityEngine;
using UnityEngine.InputSystem;

public class P_Interactable : MonoBehaviour
{
    CharacterController cc;

    InputActionMap player;
    InputAction interact;

    [SerializeField] LayerMask interactableLayer;

    GameObject selectedObj;

    float size = 3f;
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        player = InputSystem.actions.FindActionMap("Player");
        interact = player.FindAction("Interact");

        player.Enable();

    }

    
    void Update()
    {
        Raycast();
    }

    public void Raycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, size, interactableLayer))
        {
            if(interact.WasPressedThisFrame())
            {
                selectedObj = hit.transform.gameObject;
                selectedObj.GetComponent<InteractBaseClass>().Interact();
            }
                
        }
    }

}   
