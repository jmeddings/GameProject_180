using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text livesText;
    public Text gameOverText;
    public int lives = 3;
    private Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {

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
}
