using UnityEngine;

public class CodeLockInteract : MonoBehaviour
{
    public GameObject lockCanvas;

    void Start()
    {
        if (lockCanvas != null)
        {
            lockCanvas.SetActive(false);
        }
    }

    void OnMouseDown()
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