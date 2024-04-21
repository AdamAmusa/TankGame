using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public static Level instance;


    uint destructables;
    bool startNextLevel = false;
    float nextLevelTimer = 3;

    string[] levels = { "Level1", "Level2", "Level3" }; 
    int currentLevel = 1;




    private void Awake(){

        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <= 0)

            {
                Debug.Log("Loading next level");
                currentLevel++;
                if(currentLevel <= levels.Length){
                    string sceneName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else{
                    Debug.Log("Game Over!");
                }
                nextLevelTimer = 3;
                startNextLevel = false;
            }
            else{
                nextLevelTimer -= Time.deltaTime;     

            }
        }
    }

    public void addDestructable()
    {
        destructables++;
    }

    public void removeDestructables()
    {
        destructables--;
       // Debug.Log("Calling destructables!: " + destructables);
        if (destructables == 0)
        {
            startNextLevel = true;
            
        }
    }
}
