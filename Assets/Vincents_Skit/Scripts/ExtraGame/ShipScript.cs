using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class ShipScript : MonoBehaviour
{
    //shooting
    public GameObject bulletPrefab;
    public float waitTime = 0.5f;
    public float force = 10f;
    public Transform shootPoint;

    bool canShoot = true;
    public bool isShooting = false;

    //other
    CharacterController cc;
    public float speed = 20f;
    
    InputActionMap player;
    InputAction walk;

    Vector3 movement;
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        player = InputSystem.actions.FindActionMap("Player");
        walk = player.FindAction("Move");

        player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }


    void move()
    {
        
        Vector2 move = walk.ReadValue<Vector2>();

        movement = new Vector3(move.x, 0f, 0f);
        if(movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        if(move.y > 0)
        {
            shoot();
        }
        movement = gameObject.transform.TransformDirection(movement);
        cc.Move(movement * speed * Time.deltaTime);
    }

    void shoot()
    {
        if(canShoot)
        {
            
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(shootPoint.up * force, ForceMode.Impulse);
            canShoot = false;
            StartCoroutine(bulletWaitTimer());
        }
        
    }

    IEnumerator bulletWaitTimer()
    { 
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }
}
