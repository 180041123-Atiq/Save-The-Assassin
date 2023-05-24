using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    public GameObject deathsound;
    public GameObject gunshot;
    public GameObject explode;
    public GameObject doorway;
    public GameObject player;
    public GameObject gamemusic;

    private int score;
    private int health;

    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text directionText;
    public TMP_Text timerText;

    public int timer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        health = 1;
        timer = 150;
        InvokeRepeating("maintain_timer",1f,1);
    }

    public void maintain_timer()
    {
        if (timer <= 0)
        {
            Floor.instance.trigger_bomb();
            explode.SetActive(true);
            Invoke("load_game_over_scene",2f);
        }
        timerText.text = "Time Left : "+timer.ToString() + "s";
        timer--;
    }

    public void load_game_over_scene()
    {
        explode.SetActive(false);
        PlayerPrefs.SetInt("LatestScore",score);
        SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {
        updating_direction();
        updating_highscore();
        updating_latestscore();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void updating_highscore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
    }

    public void updating_latestscore()
    {
        PlayerPrefs.SetInt("LatestScore",score);
    }

    public void updating_direction()
    {
        double angle = Math.Atan2(doorway.transform.position.y - player.transform.position.y,doorway.transform.position.x - player.transform.position.x);

        double dangle = (180.0f / Math.PI) * angle;

        if (dangle < 0)
        {
            dangle += 360.0f;
        }

        if (0 <= dangle && dangle <= 29)
        {
            directionText.text = "Direction : "+"Right";
        }
        else if (30 <= dangle && dangle <= 59)
        {
            directionText.text = "Direction : Top-Right";
        }
        else if (60 <= dangle && dangle <= 119)
        {
            directionText.text = "Direction : Top";
        }
        else if (120 <= dangle && dangle <= 149)
        {
            directionText.text = "Direction : Top-Left";
        }
        else if (150 <= dangle && dangle <= 209)
        {
            directionText.text = "Direction : Left";
        }
        else if (210 <= dangle && dangle <= 239)
        {
            directionText.text = "Direction : Bottom-Left";
        }
        else if (240 <= dangle && dangle <= 299)
        {
            directionText.text = "Direction : Bottom";
        }
        else if (300 <= dangle && dangle <= 329)
        {
            directionText.text = "Direction : Bottom-Right";
        }
        else if (330 <= dangle && dangle <= 359)
        {
            directionText.text = "Direction : Right";
        }
    }
    

    public void enemy_getting_destroyed()
    {
        deathsound.SetActive(true);
        Invoke("deactivate_deathsound",2f);
    }

    public void deactivate_deathsound()
    {
        deathsound.SetActive(false);
    }

    public void player_getting_destroyed()
    {
        if (health <= 1)
        {
            gunshot.SetActive(true);
            Player.instance.trigger_dead_animation();
            Invoke("player_getting_really_destroyed",2f);
        }
        else
        {
            gunshot.SetActive(true);
            deducting_health();
            Invoke("gunshot_deactivate",1f);
        }
    }

    public void gunshot_deactivate()
    {
        gunshot.SetActive(false);
    }

    public void player_getting_really_destroyed()
    {
        gunshot.SetActive(false);
        Destroy(player);
        PlayerPrefs.SetInt("LatestScore",score);
        SceneManager.LoadScene(4);
    }
    
    public void adding_score(int scoreToadd)
    {
        score += scoreToadd;
        scoreText.text = "Score : " + score;
    }

    public void adding_health()
    {
        health++;
        healthText.text = "Health : " + health;
    }

    public void deducting_health()
    {
        health--;
        healthText.text = "Health : " + health;
    }
}
    
