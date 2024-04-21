using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    BulletFire[] bulletFire;

    AudioManager audioManager;
    GameObject shield;
    public bool isSpray;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();
        bulletFire = GetComponentsInChildren<BulletFire>();
        BasicFire();
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void BasicFire()
    {
        bulletFire[0].enabled = true;
        bulletFire[1].enabled = false;
        bulletFire[2].enabled = false;
    }

    void EnableSpray(Collider2D other)
    {
        Destroy(other.gameObject);
        isSpray = true;
        for (int i = 0; i < bulletFire.Length; i++)
        {
            bulletFire[i].enabled = true;
        }
    }

    bool isShieldActive()
    {
        return shield.activeSelf;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (bullet.isEnemy)
            {
                audioManager.PlayDestroy();
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }

        Damage damage = other.GetComponent<Damage>();
        if (damage != null)
        {
            if (isShieldActive())
            {
                DeactivateShield();
            }
            else
            {
                audioManager.PlayDestroy();
                Destroy(gameObject);
            }
            Destroy(damage.gameObject);
        }


        if (other.tag == "SprayPowerUp")
        {
            EnableSpray(other);
        }
        if(other.tag == "ShieldPowerUp")
        {
            Debug.Log("Shield");
            ActivateShield();
            Destroy(other.gameObject);
        }







    }


    void ActivateShield()
    {
        shield.SetActive(true);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
    }
}
