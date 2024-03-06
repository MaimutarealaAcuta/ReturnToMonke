using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isPC;
    private Vector2 move, mouseLook, gamepadLook;
    private Vector3 rotationTarget;

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

    private void Update()
    {
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

        transform.Translate(speed * Time.deltaTime * movement, Space.World);
    }

    private void movePlayer()
    {
        Vector3 movement = new(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(speed * Time.deltaTime * movement, Space.World);
    }
}
