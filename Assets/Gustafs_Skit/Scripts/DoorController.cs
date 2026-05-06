using UnityEngine;

public class KitchenExit : MonoBehaviour
{
    Animator _kitchenExitAnim;
    public bool open;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("key"))
        {
            Destroy(other.gameObject);

            _kitchenExitAnim.SetBool("IsOpening", true);

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _kitchenExitAnim = this.transform.GetComponent<Animator>();
        open = _kitchenExitAnim.GetBool("IsOpening");
    }

    // Update is called once per frame
    void Update()
    {
        open = _kitchenExitAnim.GetBool("IsOpening");

       
    }
}