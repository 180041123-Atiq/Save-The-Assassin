using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Congrats : MonoBehaviour
{
    public GameObject mouseclick;
    
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("LatestScore");
        int highscore = PlayerPrefs.GetInt("HighScore");

        scoreText.text = "Your Score : " + score;
        highscoreText.text = "Highscore : " + highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load_menu_scene()
    {
        mouseclick.SetActive(true);
        Invoke("deactivate_mouse_click",1f);
    }

    public void deactivate_mouse_click()
    {
        mouseclick.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
