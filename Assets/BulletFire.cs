using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletFire : MonoBehaviour
{

    AudioManager audioManager;
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private Transform bulletParent;

    

    public InputActionAsset playerControls;

    private InputAction fire;

    Vector2 direction;

    


    public int bulletSpeed = 4;


    private void Awake()
    {

        fire = playerControls.FindAction("Fire");
    }

    void OnEnable()
    {

        fire.Enable();
        fire.performed += Fire;
        
    }

    void OnDisable()
    {
        fire.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;
    }


    public void Fire(InputAction.CallbackContext context)
    {
        
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.direction = direction;
        Debug.Log("Fired");
        audioManager.PlayFire();
       // bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }

}
