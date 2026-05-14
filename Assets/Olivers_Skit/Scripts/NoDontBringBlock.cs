using UnityEngine;

public class NoDontBringBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "HallBlock")
        {
            Destroy(other.gameObject);

        }
    }
}
