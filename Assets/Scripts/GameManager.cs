using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] sets;
    public GameObject[] unions;
   


    void OnEnable()
    {
        for (int i = 0; i<sets.Length; i++)
        {
            if (i+1 == StaticDataStorage.GetSetNumber())
            {
                sets[i].gameObject.SetActive(true);
                unions[i].gameObject.SetActive(true);
            }
            else
            {
                sets[i].gameObject.SetActive(false);
                unions[i].gameObject.SetActive(false);
            }
        }

        Camera.main.GetComponent<AudioSource>().enabled = StaticDataStorage.GetMusicStatus();

    }
}
