using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModesScript : MonoBehaviour
{
    public void onSetButtonPressed(int setNumber)
    {
        StaticDataStorage.SetSetNumber(setNumber);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
}
