using UnityEngine;
using UnityEngine.InputSystem;

public class P_Raycast_Drag : MonoBehaviour
{

    float size = 3f;

    GameObject draggedObject;
    float dragDistance;
    [SerializeField] LayerMask draggableLayer;


    CharacterController cc;

    InputActionMap player;
    InputAction click;
    
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        player = InputSystem.actions.FindActionMap("Player");
        click = player.FindAction("Attack");

        player.Enable();
        
    }

    
    void Update()
    {
        Raycast();
    }

    void Raycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(ray.origin, ray.direction * size, Color.red, 0.001f);

        if(click.WasPressedThisFrame())
        {
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, size, draggableLayer))
            {
                draggedObject = hit.collider.gameObject;

                
                dragDistance = hit.distance;
            }
        }

        if (click.IsPressed() && draggedObject != null)
        {
            Vector3 newPosition = ray.origin + ray.direction * dragDistance;
            draggedObject.transform.position = newPosition;
        }

        
        if (click.WasReleasedThisFrame())
        {
            draggedObject = null;
        }
       
            
    }
}
