using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scores : MonoBehaviour
{
    private static int score;

    public void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

    }
    public int getScore()
    {
        return score;
    }

    public void addScore()
    {
        score += 100;
    }
}
