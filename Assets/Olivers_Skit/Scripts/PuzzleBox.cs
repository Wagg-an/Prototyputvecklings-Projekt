using UnityEngine;

public class PuzzleBox : MonoBehaviour
{
    private int keyCount = 0;
    public Animator animator;
    private string forms;
    private void OnTriggerEnter(Collider other)
    {
        forms = other.name;

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
        if (forms == "redCube")
        {
            animator.SetTrigger("Key1");
        }
        else if (forms == "blueCylinder")
        {
            animator.SetTrigger("Key2");
        }
        else if (forms == "yellowTriangle")
        {
            animator.SetTrigger("Key3");
        }

        if(keyCount == 3)
        {
            animator.SetTrigger("Open");
        }
    }
}
