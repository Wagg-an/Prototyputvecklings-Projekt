using UnityEngine;
using UnityEngine.InputSystem;

public class P_Movement : MonoBehaviour
{
    CharacterController cc;
    public float startSpeed = 20f;
    float speed;
    
    InputActionMap player;
    InputAction walk;
    InputAction sprint;

    Vector3 movement;

    public ParticleSystem particle;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        player = InputSystem.actions.FindActionMap("Player");
        walk = player.FindAction("Move");
        sprint = player.FindAction("Sprint");

        player.Enable();
        
    }

   
    void Update()
    {
        move();
        
    }

    void move()
    {
        speed = startSpeed;
        if(sprint.IsPressed())
        {
            speed = startSpeed * 2;
            particle.Play();
        }
        
        Vector2 move = walk.ReadValue<Vector2>();
        float gravity = -9.82f * 100 * Time.deltaTime;
        movement = new Vector3(move.x, gravity, move.y);
        if(movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        movement = gameObject.transform.TransformDirection(movement);
        cc.Move(movement * speed * Time.deltaTime);
    }
}
