using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // singleton pattern
    
    public static GameManager _instance { get; private set; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Monolith monolith;
    //public Player player;
    public SkillTree skillTree;
    public PlayerController playerController;
    public UIScript uiScript;
    public DNAScript dnaScript;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
