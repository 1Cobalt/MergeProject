using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cloudcon : MonoBehaviour
{
    public static Cloudcon Instance;

    
    public GameObject restartButton;
    public GameObject scoreText;
    public GameObject bestScoreText;
    public AudioSource popSound;
    public ParticleSystem destroyParticles;
    [SerializeField] private GameObject line;

    public Transform[] fruitObj;
    
    
    static public string spawnedYet = "y";
    private bool moveLeft = false;
    static public Vector2 cloudxPos;
    static public Vector2 spawnPos;
    
    static public string newfruit = "n";
    static public bool canSpawn = true;
    static private float compareToScreenValue;
    static public bool touchStarted = false;
    static public int whichFruit = 0;

    

    static private float swipeThreshold = 20f;

    

    static public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void OnEnable()
    {
        Instance = this;
        Cloudcon.Instance.bestScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Best score: " + StaticDataStorage.GetBestScore();
        canSpawn = true;
        newfruit = "n";
        moveLeft = false;
        touchStarted = false;
        this.GetComponent<AudioSource>().enabled = StaticDataStorage.GetSoundStatus();

        compareToScreenValue = Screen.width / 16.75f;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1.0f)
        {
            spawnFruit();
            replaceFruit();
            scoreSettler();



            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed && (Touchscreen.current.primaryTouch.position.ReadValue().y <= Camera.main.WorldToScreenPoint(this.transform.position).y))

            {
                Vector3 pos = Touchscreen.current.primaryTouch.position.ReadValue();


                if (canSpawn)
                touchStarted = true;

                Debug.Log(Touchscreen.current.primaryTouch.position.ReadValue());



                if ((pos.x / compareToScreenValue - 8.4f) < -5.5f)
                {
                    Instance.transform.position = new Vector3(-5.5f, Instance.transform.position.y, Instance.transform.position.z);
                }
                else if ((pos.x / compareToScreenValue - 8.4f) > 5.5f)
                {
                    Instance.transform.position = new Vector3(5.5f, Instance.transform.position.y, Instance.transform.position.z);
                }
                else
                {
                    Instance.transform.position = new Vector3((pos.x / compareToScreenValue) - 8.4f, Instance.transform.position.y, Instance.transform.position.z);

                }
            }



            cloudxPos = transform.position;



            if (!(Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed) && (spawnedYet == "y") && canSpawn && touchStarted)
            {
                touchStarted = false;
                spawnedYet = "n";
            }
        }
    }

    void scoreSettler()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "" + score;
        if (score >= StaticDataStorage.GetBestScore())
        {
            
            bestScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Best score: " + StaticDataStorage.GetBestScore();
            StaticDataStorage.SetBestScore(score);
        }
    }

    void spawnFruit()
    {
        if (spawnedYet == "n" && canSpawn)
        {
            canSpawn = false;
            StartCoroutine(spawntimer());
            spawnedYet = "y";
        
        }
    }

    void replaceFruit()
    {
        if (newfruit == "y")
        {
            newfruit = "n";
            Transform newFruit = Instantiate(fruitObj[whichFruit], spawnPos, fruitObj[0].rotation);
            newFruit.SetParent(this.transform.parent);
        }
    }

    public static void GameOver()
    {
        Time.timeScale = 0.0f;
        
        Instance.restartButton.gameObject.SetActive(true);
    }

    IEnumerator spawntimer()
    {
        line.SetActive(false);
        Transform newFruit = Instantiate(fruitObj[Random.Range(0, 2)], transform.position, fruitObj[0].rotation);
        newFruit.SetParent(this.transform.parent);

        yield return new WaitForSeconds(1.5f);
        line.SetActive(true);
        canSpawn = true;
    }
}
