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
    public CharacterStats characterStats;
    public SkillTree skillTree;
    public PlayerController playerController;
    public UIScript uiScript;
    public DNAScript dnaScript;
}
