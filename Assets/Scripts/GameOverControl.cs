using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r")){
            
            SceneManager.LoadScene(scene.name);
            Debug.Log("Game restarted.");
        }
    }
}
