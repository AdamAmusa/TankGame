using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinningGame : MonoBehaviour
{

   public TextMeshProUGUI scoreText;

   public Scores scores; 
    // Start is called before the first frame update
    void Start()
    {
        scores = GameObject.Find("Scores").GetComponent<Scores>();
        scoreText.text = "Your Score is: " + scores.getScore();
    }

 
}
