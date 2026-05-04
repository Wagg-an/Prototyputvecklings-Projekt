using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class OvenController : InteractBaseClass
{

    Animator _ovenAnim;
    public bool open;

    public override void Interact()
    {
        if (!open)
        {
            _ovenAnim.SetBool("IsOpening", true);
        }
        else
        {
            _ovenAnim.SetBool("IsOpening", false);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ovenAnim = this.transform.GetComponent<Animator>();
        open = _ovenAnim.GetBool("IsOpening");
    }

    // Update is called once per frame
    void Update()
    {
        open = _ovenAnim.GetBool("IsOpening");
    }
}
