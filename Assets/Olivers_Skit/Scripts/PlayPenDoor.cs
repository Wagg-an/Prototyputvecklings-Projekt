using UnityEngine;

public class PlayPenDoor : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("OpenTheDoor");
        }
    }
}
