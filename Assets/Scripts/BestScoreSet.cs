using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "Best score: " + StaticDataStorage.GetBestScore();
    }

   
}
