using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundsSlider;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundsSource;

    public void OnEnable()
    {
        musicSlider.value =  StaticDataStorage.GetMusicStatus() ? 1 : 0; 
        soundsSlider.value = StaticDataStorage.GetSoundStatus() ? 1 : 0;

        Debug.Log(StaticDataStorage.GetMusicStatus() + "  " + StaticDataStorage.GetSoundStatus());


    }

    public void onMusicSliderChange()
    {
        if (musicSlider.value == 1)
        {
            musicSource.enabled = false;
            StaticDataStorage.SetMusicStatus(false);
        }
        else
        {
            musicSource.enabled = true;
            StaticDataStorage.SetMusicStatus(true);
        }
        
        Camera.main.GetComponent<SaveSerial>().SaveGame();
    }

    public void onSoundsSliderChange()
    {
        if (soundsSlider.value == 1)
        {
            soundsSource.enabled = false;
            StaticDataStorage.SetSoundStatus(false);
        }
        else
        {
            soundsSource.enabled = true;
            StaticDataStorage.SetSoundStatus(true);
        }
       
        Camera.main.GetComponent<SaveSerial>().SaveGame();
    }
    
    void onVibrationSliderChange()
    {

    }

    public void menuButtonPressed()
    {
        Camera.main.GetComponent<SaveSerial>().SaveGame();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
