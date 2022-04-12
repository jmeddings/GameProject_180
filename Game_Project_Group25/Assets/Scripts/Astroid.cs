using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public GameObject AstroidPrefab;
    public int astroidSpeed;
    //Move down
    public GameObject upPoint;
    public GameObject downPoint;
    private Vector3 upPos;
    private Vector3 downPos;
    public bool goingDown;
    // Start is called before the first frame update
    void Start()
    {
        upPos = upPoint.transform.position;
        downPos = downPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (GetComponent<Transform>().position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }
    private void Move()
    {
        if (goingDown)
        {
            if(transform.position.y <= upPos.y)
            {
                goingDown = false;
            }
            else
            {
                transform.position += Vector3.up * Time.deltaTime * astroidSpeed;
            }
        }
        else
        {
            if(transform.position.y <= downPos.y)
            {
                goingDown = true;
            }
            else
            {
                transform.position += Vector3.down * Time.deltaTime * astroidSpeed;
            }
        }
    }

}
