using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Bullet : MonoBehaviour
{

  public Vector2 direction = new Vector2(1,0);
  public float speed = 2;
  public Vector2 velocity;

  public bool isEnemy = false;

    void Update(){
      velocity = direction * speed;
        Destroy(this.gameObject, 2f);
    }
  


void FixedUpdate()
{
    Vector2 pos = transform.position;

    pos += velocity * Time.fixedDeltaTime;  

    transform.position = pos;

}

}
