using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class CodeLockUI : MonoBehaviour
{
    [Header("Code Settings")]
    public string correctCode = "ABCD";
    private string currentInput = "";

    [Header("UI")]
    public TMP_Text displayText;
    public Image screenImage;
    public Color normalColor = Color.green;
    public Color errorColor = Color.red;

    [Header("Door Animation")]
    public Animator doorAnimator;
    public string openTriggerName = "OpenDoor";
    private bool isOpened = false;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip errorSound;
    public AudioClip successSound;

    void Start()
    {
        UpdateDisplay();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseLock();
        }
    }


    public void PressLetter(string letter)
    {
        if (currentInput.Length >= 4) return;

        currentInput += letter;
        UpdateDisplay();
    }

    public void Delete()
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplay();
        }
    }

    public void ResetInput()
    {
        currentInput = "";
        UpdateDisplay();
    }

    public void Open()
    {
        if (currentInput == correctCode)
        {
            if (audioSource && successSound)
                audioSource.PlayOneShot(successSound);

            OpenDoor();
            CloseLock();
        }
        else
        {
            if (audioSource && errorSound)
                audioSource.PlayOneShot(errorSound);

            StartCoroutine(ErrorFlash());
            ResetInput();
        }
    }


    void UpdateDisplay()
    {
        if (displayText != null)
        {
            displayText.text = currentInput;
        }
    }

    IEnumerator ErrorFlash()
    {
        if (screenImage != null)
        {
            screenImage.color = errorColor;
            yield return new WaitForSeconds(0.5f);
            screenImage.color = normalColor;
        }
    }

    void OpenDoor()
    {
        if (isOpened) return;

        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger(openTriggerName);
            isOpened = true;
        }
        else
        {
            Debug.LogError("Door Animator is not assigned!");
        }
    }

    void CloseLock()
    {
        ResetInput();
        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}