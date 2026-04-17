using UnityEngine;

public class DoorToHallway : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("key"))
        {
            Destroy(other.gameObject);

            animator.SetTrigger("OpenDoor");

        }
    }

}
