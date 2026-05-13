using UnityEngine;

public class StopHint : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("StopHint");
        }
    }
}
