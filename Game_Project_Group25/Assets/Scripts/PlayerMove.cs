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
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Enemy")
        {
            Respawn();
        }
        if (other.tag == "Exit")
        {
            Scene_Switch.instance.switchScene(1);
        }
        if (other.tag == "Exit2")
        {
            Scene_Switch.instance.switchScene(2);
        }
        if (other.tag == "Exit3")
        {
            Scene_Switch.instance.switchScene(3);
        }
    }
}
