using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SafePuzzleCode : MonoBehaviour
{
    private string CorrectCode = "DBFA";
    public Animator animator;
    public SafePuzzle safePuzzle;
    private GameObject PlayerC;
    private GameObject PuzzleC;
    private GameObject SafeCanvas;

    public TMP_Text displayText;
    private int charAmount;

    private string currentInput = "";

    public void AddChar(string Char)
    {
        charAmount++;
        currentInput += Char;
        //displayText.text = currentInput;

        Debug.Log(currentInput);
        Debug.Log(charAmount);
       
    }
    public void CheckAwnser()
    {
        if (currentInput == CorrectCode)
        {
            animator.SetTrigger("OpenSafe");
            Debug.Log("CorrectCode");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SafeCanvas.SetActive(false);
            PlayerC.SetActive(true);
            PuzzleC.SetActive(false);
        }
        else if(currentInput != CorrectCode)
        {
            Debug.Log("Current WasNot Correct");
            currentInput = "";
            charAmount = 0;
        }
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerC = safePuzzle.PlayerCamera;
        PuzzleC = safePuzzle.PuzzleCamera;
        SafeCanvas = safePuzzle.SafeCanvas;
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = currentInput;
        if (charAmount == 4)
        {
            CheckAwnser();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESCAPE");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SafeCanvas.SetActive(false);
            PlayerC.SetActive(true);
            PuzzleC.SetActive(false);
        }
    }
}
