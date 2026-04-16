using UnityEngine;

public class PuzzleBox : MonoBehaviour
{
    public int keyCount = 0;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("key"))
        {
            Destroy(other.gameObject);
            keyCount++;

            Debug.Log("Key collected: " + keyCount);

            TriggerAnimation();
        }
    }

    void TriggerAnimation()
    {
        if (keyCount == 1)
        {
            animator.SetTrigger("Key1");
        }
        else if (keyCount == 2)
        {
            animator.SetTrigger("Key2");
        }
        else if (keyCount == 3)
        {
            animator.SetTrigger("Key3");
        }
    }
}
