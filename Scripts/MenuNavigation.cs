using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
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

    public void load_instructionScene()
    {
        activate_mouse_click();
        SceneManager.LoadScene(1);
    }
    
    public void load_messageScene()
    {
        activate_mouse_click();
        SceneManager.LoadScene(2);
    }

    public void quit_game()
    {
        activate_mouse_click();
        Application.Quit();
    }

    public void activate_mouse_click()
    {
       mouseclick.SetActive(true);
       Invoke("deactivate_mouseclick",1f);
    }
    
    public void deactivate_mouseclick()
    {
        mouseclick.SetActive(false);
    }
}
