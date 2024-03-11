using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public enum WaveState
    { 
        Starting,
        Spawning,
        Stopping,
        Pause
    };

    int[] waveStateTimes =
    {
        10,
        80,
        20,
        30
    };

    private WaveState currentState = WaveState.Pause;
    private int currentWave = 0;
    private Coroutine waveCycle;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    IEnumerator DoWaveCycle()
    {
        while(true)
        {
            currentWave++;
            foreach (var state in (WaveState[])Enum.GetValues(typeof(WaveState)))
            {
                setState(state);
                yield return new WaitForSeconds(waveStateTimes[(int)currentState]);
            }
        }        
    }

    public void StartWaveCycle()
    {
        waveCycle = StartCoroutine(DoWaveCycle());
    }
    
    public void StopWaveCycle()
    {
        if (waveCycle == null)
        {
            Debug.Log("WaveCycle coroutine not running.");
            return;
        }
        
        StopCoroutine(waveCycle);
    }
    
    private void setState(WaveState newState)
    {
        currentState = newState;

        // link to UI to display current state
        MonolithBubble monolithBubble = GameManager._instance.monolith.gameObject.GetComponentInChildren<MonolithBubble>();

        switch (currentState)
        {
            case WaveState.Starting:
                Debug.Log("Wave starting...");
                monolithBubble.ShowWaveText("Wave starting...");                
                break;
            case WaveState.Spawning:
                audioManager.changeMusic(audioManager.combatMusic);
                Debug.Log("Wave spawning...");
                GameManager._instance.spawnSystem.StartSpawning(currentWave);
                monolithBubble.ShowWaveText("WAVE " + currentWave);
                break;
            case WaveState.Stopping:
                Debug.Log("Wave stopping...");
                GameManager._instance.spawnSystem.StopSpawning();
                monolithBubble.ShowWaveText("Wave stopping...");
                break;
            case WaveState.Pause:
                audioManager.changeMusic(audioManager.waitingMusic);
                GameManager._instance.spawnSystem.CleanseEnemies();
                GameManager._instance.metrics.AddWaveSurvived();
                Debug.Log("Wave paused...");
                monolithBubble.ShowWaveText("You may rest... for now");
                break;
            default:
                break;
        }            
    }

    public int getCurrentWave() 
    { 
        return currentWave; 
    }
}
