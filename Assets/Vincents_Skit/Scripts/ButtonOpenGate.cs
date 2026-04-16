using UnityEngine;

public class ButtonOpenGate : InteractBaseClass
{
    public InteractBaseClass gate;

    override public void Interact()
    {
        gate.Interact();
    }
}
