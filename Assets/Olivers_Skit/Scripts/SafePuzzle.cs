using UnityEngine;
using UnityEngine.InputSystem;

public class SafePuzzle : InteractBaseClass
{
    public GameObject SafeCanvas;
    public GameObject PlayerCamera;
    public GameObject PuzzleCamera;

    void Start()
    {
        if (SafeCanvas != null)
        {
            SafeCanvas.SetActive(false);
        }
    }

    public override void Interact()
    {
        if (SafeCanvas != null)
        {
            PlayerCamera.SetActive(false);
            PuzzleCamera.SetActive(true);
            SafeCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
        
    }

}
