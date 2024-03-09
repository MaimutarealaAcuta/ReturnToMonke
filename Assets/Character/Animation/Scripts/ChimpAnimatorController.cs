using UnityEngine;

public class ChimpAnimatorController : MonoBehaviour
{
    private Animator animator;
    private PlayerController player;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        animator.SetFloat("moveAmount", player.GetMoveAmount(), .15f, Time.deltaTime);
    }
}
