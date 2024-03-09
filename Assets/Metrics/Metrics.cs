using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Metrics : MonoBehaviour
{
    private int score = 0;
    private int wavesSurvived = 0;
    private int bananasEaten = 0;
    private int enemiesKilled = 0;
    private int spentDNA = 0;
    private float timePlayed = 0.0f;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;
        timePlayed += Time.deltaTime;
    }

    public void AddScore(int score)
    {
        this.score += score;
    }
    
    public void AddWaveSurvived()
    {
        wavesSurvived++;
        AddScore(100);
    }

    public void AddBanana()
    {
        bananasEaten++;
        AddScore(10);
    }

    public void AddEnemyKilled()
    {
        enemiesKilled++;
        AddScore(30);
    }

    public void AddSpentDNA(int dna)
    {
        spentDNA += dna;
    }

    public string getMetrics()
    {
        gameOver = true;
        AddScore((int)timePlayed * 10);
        AddScore(spentDNA / 2);

        StringBuilder sb = new StringBuilder();

        int hours = (int)timePlayed / 3600;
        int minutes = (int)(timePlayed - hours * 3600) / 60;
        int seconds = (int)(timePlayed - hours * 3600 - minutes * 60);

        sb.AppendLine("Time Played: " + (hours > 0 ? hours + "h " : "") + (minutes > 0 ? minutes + "m " : "") + seconds + "s");
        sb.AppendLine("Waves survived: " + wavesSurvived);
        sb.AppendLine("Bananas Eaten: " + bananasEaten);
        sb.AppendLine("Enemies Killed: " + enemiesKilled);
        sb.AppendLine("DNA spent: " + spentDNA);
        sb.AppendLine();
        sb.AppendLine("Score: " + score);

        return sb.ToString();
    }
}
