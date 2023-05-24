using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float type;
    private float enemy_speed;
    private string[] directions1 = {"up","right","down","left"};
    private string[] directions2 = {"up","left","down","right"};
    private int direction_index;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy_speed = 2f;
        direction_index = 0;
        direction_index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.W))
        {
            direction_index = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction_index = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction_index = 2;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction_index = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy_stops_moving();
        }*/

        switch (type==1?directions1[direction_index]:directions2[direction_index]) 
        {
            case "up":
                enemy_moving_up();
                break;
            case "left":
                
                enemy_moving_left();
                break;
            case "right":
                enemy_moving_right();
                break;
            case "down":
                enemy_moving_down();
                break;
            default:
                Debug.Log("There is some error in Update Switch");
                break;
        }
        
    }

    private void enemy_moving_up()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);
        transform.position += (new Vector3(0,1,0) * Time.deltaTime * enemy_speed);
    }

    private void enemy_moving_left()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        transform.position += (new Vector3(-1,0,0) * Time.deltaTime * enemy_speed);
    }

    private void enemy_moving_right()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * 270);
        transform.position += (new Vector3(1,0,0) * Time.deltaTime * enemy_speed);
    }

    private void enemy_moving_down()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * 180);
        transform.position += (new Vector3(0,-1,0) * Time.deltaTime * enemy_speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "enemy" ||
            other.gameObject.tag == "coin" || other.gameObject.tag == "health" ||
            other.gameObject.tag == "doorway")
        {
            direction_index = (direction_index + 1) % 4;
        }

        if (other.gameObject.tag == "player")
        {
            Debug.Log("Enemy is doomed");
            Destroy(gameObject);
            GameManager.instance.adding_score(10);
            GameManager.instance.enemy_getting_destroyed();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log("Trigger got activated & player is doom");
            GameManager.instance.player_getting_destroyed();
        }
        
    }
    
}
