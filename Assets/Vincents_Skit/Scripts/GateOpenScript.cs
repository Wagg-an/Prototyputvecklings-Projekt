using UnityEngine;

public class GateOpenScript : MonoBehaviour
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
            open();
        }
    }

    void open()
    {
        gameObject.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
        hasOpened = true;

    }
}
