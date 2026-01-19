using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shake : MonoBehaviour
{
    public GameObject Jar;
    public Animation animation;
    public TextMeshProUGUI shakeText;

    void Update()
    {
        shakeText.text = ""+StaticDataStorage.GetShakeCount();
    }

    public void ShakeJar()
    {
        if (StaticDataStorage.GetShakeCount() > 0)
        {
            animation.Play();
            StaticDataStorage.SetShakeCount(StaticDataStorage.GetShakeCount() - 1);
        }
    }
}
