using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickableScript : MonoBehaviour
{
    private Vector3 initialPos;

    public void Start()
    {
        initialPos = transform.position;
    }

    public void Update()
    {
        transform.Rotate(Vector3.up, 90 * Time.deltaTime, Space.World);

        transform.position = initialPos + new Vector3(0, Mathf.Sin(Time.time * 2) * 0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUp();
            Destroy(gameObject);
        }
    }

    protected abstract void PickUp();
}
