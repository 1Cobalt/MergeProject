using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Fruitcon : MonoBehaviour
{
    private string inthecloud = "y";
    private string timeToCheck = "n";

   
    void Start()
    {
        if (transform.position.y < 3.5f)
        {
            inthecloud = "n";
        }
    }
    void OnEnable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (inthecloud == "y")
        {
            GetComponent<Transform>().position = Cloudcon.cloudxPos;
        }
        
        if (!Cloudcon.touchStarted || Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            inthecloud = "n";
            StartCoroutine(chkGameOver());
         
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            Cloudcon.spawnPos = transform.position;
            Cloudcon.newfruit = "y";
            Cloudcon.Instance.popSound.Play();
            Camera.main.GetComponent<SaveSerial>().SaveGame();

            ParticleSystem temp = Instantiate(Cloudcon.Instance.destroyParticles, transform.position, Quaternion.identity);
            temp.transform.position = transform.position;
            Destroy(temp, 4.0f);

            Cloudcon.whichFruit = int.Parse(gameObject.tag);
            Cloudcon.score += int.Parse(gameObject.tag);
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Border" && timeToCheck == "y")
        {
            Cloudcon.GameOver();
        }
    }

    IEnumerator chkGameOver()
    {
        yield return new WaitForSeconds(2.0f);
        timeToCheck = "y";
    }
}
