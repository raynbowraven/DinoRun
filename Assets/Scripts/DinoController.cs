using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float JumpHeight = 0f;
    public GameObject GameOverPrefab;
    Rigidbody2D body = new Rigidbody2D();
    Vector2 jumpdir;
    AudioSource jumpsound;
    EnemySpawner enemySpawner;
    GameObject[] cactii;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumpdir = new Vector2(0,1*JumpHeight*100);
        jumpsound = GetComponent<AudioSource>();
        enemySpawner = GameObject.Find("BackgroundCanvas").GetComponent<EnemySpawner>();
    }
    


    // Update is called once per frame
    void Update()
    {
        if(body.velocity == Vector2.zero && Input.GetKeyDown("space")){
            DinoJump();
        }
    }

    void OnCollisionEnter2D(Collision2D CollidedObject)
    {
        if(CollidedObject.gameObject.name.StartsWith("Floor")){
            body.velocity = Vector2.zero;
        }
        else if(CollidedObject.gameObject.name.StartsWith("Cactus")){
            Debug.Log("Dino killed. Game over.");
            CollidedObject.gameObject.GetComponent<CactusControl>().MoveSpeed = 0f;
            GameOver();
            Destroy(CollidedObject.gameObject.GetComponent<Rigidbody2D>());
            Destroy(CollidedObject.gameObject.GetComponent<CactusControl>());
        }
    }

    void OnCollisionStay2D(Collision2D CollidedObject)
    {
        if(CollidedObject.gameObject.name == "Floor"){
            if(Input.GetKeyDown("space")){
                DinoJump();
            }
        }
        
    }

    void DinoJump()
    {
        body.AddForce(jumpdir);
        jumpsound.Play();
        Debug.Log("Dino jumped.");
    }

    void GameOver()
    {
        enemySpawner.GameOver = true;
        cactii = GameObject.FindGameObjectsWithTag("CactusObject");
        foreach(GameObject cactus in cactii)
        {
            Destroy(cactus.GetComponent<Rigidbody2D>());
            Destroy(cactus.GetComponent<CactusControl>());
        }
        body.velocity = Vector2.zero;
        Instantiate(GameOverPrefab);
        Destroy(GetComponent<Animator>());
        Destroy(body);
        Destroy(this);
    }

}
