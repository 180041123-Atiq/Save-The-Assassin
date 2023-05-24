using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverNavigation : MonoBehaviour
{
    public GameObject mouseclick;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load_view_score_scene()
    {
        activate_mouse_click();
        SceneManager.LoadScene(6);
    }

    public void load_game_scene()
    {
        activate_mouse_click();
        SceneManager.LoadScene(3);
    }

    public void load_menu_scene()
    {
        activate_mouse_click();
        SceneManager.LoadScene(0);
    }

    public void activate_mouse_click()
    {
        mouseclick.SetActive(true);
        Invoke("deactivate_mouse_click",1f);
    }

    public void deactivate_mouse_click()
    {
        mouseclick.SetActive(false);
    }
}
