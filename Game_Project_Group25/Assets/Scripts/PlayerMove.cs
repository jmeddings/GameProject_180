using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;
    //repawn
    public int lives = 3;
    private Vector3 startPosition;
    private Rigidbody rigid_body;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigid_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
    private void Respawn()
    {
        transform.position = startPosition;
        lives--;

        if (lives<=0)
        {
            this.enabled = false;
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag =="Enemy")
        {
            Respawn();
        }
    }
}
