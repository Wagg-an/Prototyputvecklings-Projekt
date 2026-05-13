using UnityEngine;
using TMPro;

public class GamemOdeSpaceShit : MonoBehaviour
{
    public static GamemOdeSpaceShit instance;

    public GameObject hud;
    public Camera thisCam;
    public GameObject spawner;
    public GameObject spaceShip;

    public TMP_Text scoreDisp;     
    int score;


    bool eventTrigger = false;

    void Start()
    {
        spawner.SetActive(false);
        spaceShip.SetActive(false);
    }
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if(thisCam.targetDisplay == 0 && !eventTrigger)
        {
            startGame();
            eventTrigger = true;
        }
    }

    void startGame()
    {
        spaceShip.SetActive(true);
        spawner.SetActive(true);
    }

    void loose()
    {

    }

    public void addScore(int value)
    {
        int.TryParse(scoreDisp.text, out score);     
        score += value;

        scoreDisp.text = score.ToString();
    }

    

}
