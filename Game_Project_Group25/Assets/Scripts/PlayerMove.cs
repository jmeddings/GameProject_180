using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //player movment speed
    public float speed = 10;
    //repawn
    public int lives = 3;
    private Vector3 startPosition;
    private Rigidbody rigid_body;
    //text
    public Text livesText;
    public Text gameOverText;
    //timer
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigid_body = GetComponent<Rigidbody>();
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player Moving left and right
        Vector3 add_position = Vector3.zero;
        
        if(Input.GetKey("a"))
        {
            add_position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))
        {
            add_position += Vector3.right * Time.deltaTime * speed;
        }
        GetComponent<Transform>().position += add_position;
        //if (timerIsRunning)
        //{
         //   if (timeRemaining > 0)
         //   {
         //       timeRemaining -= Time.deltaTime;
         //   }
         //   else
         //   {
         //       timeRemaining = 0;
         //       timerIsRunning = false;
          //      SceneSwitch.instance.switchScene(1);
            //}
        //}
    }
    //respawn and lifes taken
    private void Respawn()
    {
        transform.position = startPosition;
        lives--;
        SetCountText();

        if (lives<=0)
        {
            this.enabled = false;
        }
    }
    //Text
    private void SetCountText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            gameOverText.text = "GameOver";
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag =="Enemy")
        {
            Respawn();
        }
        if(other.tag == "Exit")
        {
            SceneSwitch.instance.switchScene(1);
        }
    }
    
}
