using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class P_Raycast_Drag : MonoBehaviour
{

    float size = 3f;

    GameObject draggedObject;
    Rigidbody draggedRB;

    float dragDistance;

    [SerializeField] LayerMask draggableLayer;
    [SerializeField] float rotationSpeed;


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
        RotateHandle();
    }

    void Raycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(ray.origin, ray.direction * size, Color.red, 0.001f);

        if(click.WasPressedThisFrame())
        {
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, size))
            {
                if(((1 << hit.collider.gameObject.layer) & draggableLayer) != 0)
                {
                    draggedObject = hit.collider.gameObject;
                draggedRB = draggedObject.GetComponent<Rigidbody>();

                if (draggedRB != null)
                {
                    draggedRB.useGravity = false;
                    draggedRB.linearVelocity = Vector3.zero;
                }
                
                dragDistance = hit.distance;
                
                }
            }
        }
        
        if (click.IsPressed() && draggedObject != null && draggedRB != null)
        {
            
            Vector3 target = ray.origin + ray.direction * dragDistance;

            float radius = 0.1f;

            if (Physics.SphereCast(ray.origin, radius, ray.direction, out RaycastHit hit, dragDistance))
            {
                if (hit.collider.gameObject != draggedObject)
                {
                    target = hit.point + hit.normal * radius;
                }
            }

            draggedRB.MovePosition(target);
        }

        
        if (click.WasReleasedThisFrame())
        {
            if (draggedRB != null)
            {
                draggedRB.useGravity = true;
            }
            draggedObject = null;
            draggedRB = null;
        }
       
            
    }

    void RotateHandle()
    {
        float horizontal = 0f;
        float vertical = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            horizontal = 1f;
        }
        if (Input.GetKey(KeyCode.F))
        {
            vertical = 1f;
            Debug.Log("Pressing Rotate");
        }
        if (Input.GetKey(KeyCode.V))
        {
            vertical = -1f;
        }


        if(vertical != 0f)
        {
            Debug.Log("Rotate");
            draggedObject.transform.Rotate(
                Vector3.right,
                vertical * rotationSpeed * Time.deltaTime,
                Space.World
            );
        }
        if(horizontal != 0f)
        {
            Debug.Log("UpnDown");
            draggedObject.transform.Rotate(
                Vector3.up,
                horizontal * rotationSpeed * Time.deltaTime,
                Space.World
            );
        }
    }
}
