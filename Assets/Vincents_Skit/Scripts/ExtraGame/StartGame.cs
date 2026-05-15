using UnityEngine;

public class StartGame : InteractBaseClass
{
    public Camera camera2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        camera2.targetDisplay = 0;
    }
}
