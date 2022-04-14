using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text livesText;
    public Text gameOverText;
    public int lives = 3;
    private Vector3 startPosition;
    //timer text
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {

                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    private void SetCountText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            gameOverText.text = "GameOver";
        }
    }
    private void Respawn()
    {
        transform.position = startPosition;
        lives--;
        SetCountText();

        if (lives <= 0)
        {
            this.enabled = false;
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
