using UnityEngine;
using TMPro;
using System;

public class HUDManger : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    private float currentTime;
    private int currentScore = 0;

    public Action<int> AddToScore;

    public void Awake()
    {
        AddToScore += ChangeScore;
        ChangeScore(0);
    }

    public void FixedUpdate()
    {
        ChangeTime();
    }

    private void ChangeTime()
    {
        currentTime += Time.deltaTime;
        time.text = "Time: " + System.TimeSpan.FromSeconds(currentTime).ToString("hh':'mm':'ss':'ff");
    }

    private void ChangeScore(int add)
    {
        currentScore += add;
        score.text = "Score: " + currentScore;
    }
}
