using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Lore;
    
    
    
    public void LoadScene(string SampleScene)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReadLore()
    {
       Lore.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}