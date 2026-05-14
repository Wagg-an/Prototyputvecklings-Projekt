using UnityEngine;

public class NoCheatingForYou : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "HallBlock")
        {
            Destroy(other.gameObject);
        }
    }
}
