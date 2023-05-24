using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionNavigation : MonoBehaviour
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

    public void load_MenuScene()
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
