using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bulletPrefab;
    Vector2 direction;

    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0;
    float shootTimer = 0.0f;    
    float delayTimer = 0.0f;

    public bool isActive = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!isActive){
            return;
        }

        
        direction = (transform.localRotation * Vector2.right).normalized;


        if(autoShoot){
            
            if(delayTimer >= shootDelaySeconds){
                //Debug.Log("Fire");
                if(shootTimer >= shootIntervalSeconds){
                    
                    Fire();
                    shootTimer = 0;
                }
                else{
                    shootTimer += Time.deltaTime;
                }
        }
        else{
            delayTimer -= Time.deltaTime;
        }
    }
    }






    public void Fire()
    {
        GameObject go = Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();    
        bulletPrefab.direction = direction;

    }
}
