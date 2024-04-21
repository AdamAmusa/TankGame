using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Damage : MonoBehaviour
{

    bool canBeDestroyed = false;
    Scores scoreObject;
    
   
    // Start is called before the first frame update

    


    void Start()
    {
        
        Level.instance.addDestructable();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 10){
            canBeDestroyed = true;
            Gun[] gunObjects = transform.GetComponentsInChildren<Gun>();
            foreach(Gun gun in gunObjects){
                gun.isActive = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!canBeDestroyed){
            return;
        }

        Bullet bullet = other.GetComponent<Bullet>();  
        if(bullet != null){

            if(!bullet.isEnemy){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            scoreObject = GameObject.FindObjectOfType<Scores>();
            scoreObject.addScore();
            Debug.Log(scoreObject.getScore());
            }
           
        }
    }

    private void OnDestroy(){
        //Debug.Log("Destroyed");
        
        Level.instance.removeDestructables();
    }
}
