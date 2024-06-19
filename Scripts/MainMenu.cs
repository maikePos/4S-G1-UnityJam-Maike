using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu; 
    
   
    
   
    public bool isPaused; 


    // Start is called before the first frame update
    private void Start()
    {
       pauseMenu.SetActive(false); 
       
       


    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame(); 
            }
        }



    }





    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void QuitGame() 
    {
        Application.Quit(); 
    }

   
    
    public void PauseGame() 
    {
        pauseMenu.SetActive(true); 
        Time.timeScale = 0f; 

        isPaused = true; 
    }

    public void ResumeGame() 
    {
        pauseMenu.SetActive(false); 
        
       
        Time.timeScale = 1f; 

        isPaused = false; 
    }

    public void BackToMain() 
    {
        SceneManager.LoadScene("Main Menu"); 
    }

   
   
}
