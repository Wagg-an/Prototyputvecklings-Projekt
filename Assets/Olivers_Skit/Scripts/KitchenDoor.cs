using UnityEngine;

public class KitchenDoor : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "KitchenKey")
        {
            Destroy(other.gameObject);

            Debug.Log("");

            animator.SetTrigger("KitchenDoorOpen");
        }
    }
}
