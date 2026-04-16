using UnityEngine;

public class GateOpenScript : InteractBaseClass
{
    public bool Open = false;
    bool hasOpened = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Open && !hasOpened)
        {
            Interact();
        }
    }

    override public void Interact()
    {
        if (!hasOpened)
        {
            gameObject.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            hasOpened = true;
        }
        

    }
}
