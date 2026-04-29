using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class FridgeController : InteractBaseClass
{

    Animator _fridgeAnim;
    public bool open;

    public override void Interact()
    {
        if (!open)
        {
            _fridgeAnim.SetBool("IsOpening", true);
        }
        else
        {
            _fridgeAnim.SetBool("IsOpening", false);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _fridgeAnim = this.transform.GetComponent<Animator>();
        open = _fridgeAnim.GetBool("IsOpening");
    }

    // Update is called once per frame
    void Update()
    {
        open = _fridgeAnim.GetBool("IsOpening");
    }
}
