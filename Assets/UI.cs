using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{

    public TextMeshProUGUI scoreIndicator;

    Scores scoreObject;
    // Start is called before the first frame update

    public void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        scoreObject = GameObject.FindAnyObjectByType<Scores>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreIndicator.text = "Score: " + scoreObject.getScore();
    }
}
