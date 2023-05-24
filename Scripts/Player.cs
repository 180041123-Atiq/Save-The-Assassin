using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    private bool isMoving;
    public float player_speed;
    public static Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isMoving = false;
        player_speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player_moving_up();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player_moving_left();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player_moving_right();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player_moving_down();
        }
        else
        {
            player_stops_moving();
        }
    }

    private void player_moving_up()
    {
        if (!isMoving)
        {
            isMoving = true;
            trigger_animation();
        }
        
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);
        transform.position += (new Vector3(0, 1, 0) * Time.deltaTime * player_speed);
    }

    private void player_moving_left()
    {
        if (!isMoving)
        {
            isMoving = true;
            trigger_animation();
        }
        
        transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        transform.position += (new Vector3(-1, 0, 0) * Time.deltaTime * player_speed);
    }

    private void player_moving_right()
    {
        if (!isMoving)
        {
            isMoving = true;
            trigger_animation();
        }
        
        transform.rotation = Quaternion.Euler(Vector3.forward * 270);
        transform.position += (new Vector3(1, 0, 0) * Time.deltaTime * player_speed);
    }

    private void player_moving_down()
    {
        if (!isMoving)
        {
            isMoving = true;
            trigger_animation();
        }
        
        transform.rotation = Quaternion.Euler(Vector3.forward * 180);
        transform.position += (new Vector3(0, -1, 0) * Time.deltaTime * player_speed);
    }

    private void player_stops_moving()
    {
        if (isMoving)
        {
            isMoving = false;
            trigger_animation();
        }
    }

    private void trigger_animation()
    {
        anim.SetTrigger("Move");
    }

    public void trigger_dead_animation()
    {
        anim.SetTrigger("Explode");
    }
}
