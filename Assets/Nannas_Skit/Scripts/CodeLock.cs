using UnityEngine;
using UnityEngine.InputSystem;

public class CodeLockInteract : InteractBaseClass
{
    public GameObject lockCanvas;

    void Start()
    {
        if (lockCanvas != null)
        {
            lockCanvas.SetActive(false);
        }
    }

    public override void Interact()
    {
        if (lockCanvas != null)
        {
            lockCanvas.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Debug.LogError("CANVAS FUNKAR INTE");
        }
    }
}