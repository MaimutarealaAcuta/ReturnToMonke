using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isPC;

    [SerializeField]
    private CharacterStats characterStats;

    private Vector2 move, mouseLook, gamepadLook;
    private Vector3 rotationTarget;
    
    private bool canMove = true;

    private void Update()
    {
        if (!canMove)
            return;
        if (isPC)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseLook);

            if (Physics.Raycast(ray, out hit))
            {
                rotationTarget = hit.point;
            }

            movePlayerWithAim();
        }
        else
        {
            if (gamepadLook.x == 0 && gamepadLook.y == 0)
            {
                movePlayer();
            }
            else
            {
                movePlayerWithAim();
            }
        }
    }

    private void movePlayerWithAim()
    {
        if (isPC)
        {
            var lookPos = rotationTarget - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            Vector3 aimDirection = new Vector3(rotationTarget.x, 0f, rotationTarget.z);

            if (aimDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
            }
        }
        else
        {
            Vector3 aimDirection = new Vector3(gamepadLook.x, 0f, gamepadLook.y);

            if (aimDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDirection), 0.15f);
            }
        }

        Vector3 movement = new(move.x, 0f, move.y);

        //transform.Translate(speed * Time.deltaTime * movement, Space.World);
        Translate(movement);
    }

    private void movePlayer()
    {
        Vector3 movement = new(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        //transform.Translate(speed * Time.deltaTime * movement, Space.World);
        Translate(movement);
    }

    public void toggleMovement()
    {
        canMove = !canMove;
    }
    
    private void Translate (Vector3 movement)
    {
        int agility = characterStats.GetStatValue("agility");

        Vector3 translation = agility * speed * Time.deltaTime * movement;

        transform.Translate(translation, Space.World);
    }

    #region Events

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValue<Vector2>();
    }

    public void OnGamepadLook(InputAction.CallbackContext context)
    {
        gamepadLook = context.ReadValue<Vector2>();
    }

    #endregion
}
