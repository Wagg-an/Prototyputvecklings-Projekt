using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GamemOdeSpaceShit : MonoBehaviour
{
    public static GamemOdeSpaceShit instance;

    public GameObject hud;
    public GameObject redHud;
    public GameObject spawner;
    public GameObject spaceShip;

    public TMP_Text scoreDisp;     
    int score;

    public TMP_Text lifeDisp;  
    public int life = 5;

    bool once = false;

    void Start()
    {
        //spawner.SetActive(false);
        //spaceShip.SetActive(false);
        
    }
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void OnEnable() 
    {
        startGame();
    }

    void Update()
    {
        lifeDisp.text = life.ToString();
        if(life <= 0 && !once)
        {
            loose();
            once = true;
        }
    }

    public void startGame()
    {
        life = 5;
        once = false;
        hud.SetActive(false);
        spaceShip.SetActive(true);
        spawner.SetActive(true);
    }

    void loose()
    {
        spaceShip.SetActive(false);
        spawner.SetActive(false);
        hud.SetActive(true);
    }

    public void quit()
    {
        hud.SetActive(false);
    }

    public void addScore(int value)
    {
        int.TryParse(scoreDisp.text, out score);     
        score += value;

        scoreDisp.text = score.ToString();
    }

    public void hurting()
    {
        life -= 1;
        StartCoroutine(hurt());
    }

    IEnumerator hurt()
    {
        redHud.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        redHud.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        redHud.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        redHud.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        redHud.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        redHud.SetActive(false);
    }

}
