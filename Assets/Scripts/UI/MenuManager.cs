using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject[] elementsToHide;
    public GameObject[] elementsToShow;
   

    public void HideAndShowElements()
    {
        for(int i = 0; i<elementsToHide.Length; i++)
        {
            elementsToHide[i].SetActive(false);
        }
        for (int i = 0; i < elementsToShow.Length; i++)
        {
            elementsToShow[i].SetActive(true);
        }

        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 1.1f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        Camera.main.GetComponent<SaveSerial>().SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

 

    public void LeaveGame()
    {
        Application.Quit();
    }
}
