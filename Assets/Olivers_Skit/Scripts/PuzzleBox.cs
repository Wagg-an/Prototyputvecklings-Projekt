using UnityEngine;

public class PuzzleBox : MonoBehaviour
{
    public int keyCount = 0;
    public Animator animator;
    private string form = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("key"))
        {
            form = other.name;
            Destroy(other.gameObject);
            keyCount++;

            Debug.Log(form);
            Debug.Log("Key collected: " + keyCount);

            TriggerAnimation();
        }
    }

    void TriggerAnimation()
    {
        if (form == "redCube")
        {
            animator.SetTrigger("Key1");
        }
        else if (form == "blueCylinder")
        {
            animator.SetTrigger("Key2");
        }
        else if (form == "yellowTriangle")
        {
            animator.SetTrigger("Key3");
        }

        if(keyCount == 3)
        {
            animator.SetTrigger("Open");
        }
    }
}
