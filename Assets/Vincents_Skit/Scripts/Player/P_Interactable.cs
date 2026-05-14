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

    public GameObject canvasTip;

    
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        player = InputSystem.actions.FindActionMap("Player");
        interact = player.FindAction("Interact");

        player.Enable();

    }

    
    void Update()
    {
        canvasTip.SetActive(false);
        Raycast();
    }

    void LateUpdate()
    {
        if (canvasTip.activeSelf)
        {
            canvasTip.transform.forward = Camera.main.transform.forward;
        }
    }

    public void Raycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, size, interactableLayer))
        {
            Bounds bounds = hit.collider.bounds;

            
            Vector3 basePos = bounds.center;

 
            float heightOffset = Mathf.Clamp(bounds.size.y * 0.5f, 0.5f, 2.0f);
            if(heightOffset >= 1)
            {
                heightOffset = -0.5f;
            }

            
            basePos += Vector3.up * heightOffset;

     
            Vector3 dirToCamera = (Camera.main.transform.position - basePos).normalized;
            float pushForward = 0.5f;

            Vector3 finalPos = basePos + dirToCamera * pushForward;

            canvasTip.transform.position = finalPos;
            canvasTip.SetActive(true);

            if(interact.WasPressedThisFrame())
            {
                selectedObj = hit.transform.gameObject;
                selectedObj.GetComponent<InteractBaseClass>().Interact();
            }
                
        }
        
    }

}   
