using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenField : MonoBehaviour
{
    private int regenZoneRadiusLevel = 0;
    private const int regenZoneRadiusModifier = 100;

    [SerializeField]
    private int healValue = 10;

    [SerializeField]
    private int healCooldownSec = 5;

    private bool coolingDown = false;

    public Texture2D[] regenFieldTextures;

    public void Update()
    {
        // rotate regen field
        transform.Rotate(Vector3.up, 25 * Time.deltaTime, Space.World);
    }

    public void increaseRegenRadius()
    {
        regenZoneRadiusLevel++;

        transform.localScale += new Vector3(1, 1, 0) * regenZoneRadiusLevel * regenZoneRadiusModifier;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (coolingDown) return;            
            CharacterStats player = other.gameObject.GetComponent<CharacterStats>();
            if (!player.IsAtMaxHealth())
            {
                coolingDown = true;
                player.Heal(healValue);
                HealAnim();
            }
        }
    }

    IEnumerator HealAnimRoutine()
    {
        for (int i = regenFieldTextures.Length; i >= 0; i--)
        {
            if(i-1 >=0)
                GetComponent<Renderer>().material.mainTexture = regenFieldTextures[i-1];
            coolingDown = (i > 0);
            yield return new WaitForSeconds(i==2 ? healCooldownSec : 1);
        }
    }

    private void HealAnim()
    {       
        StartCoroutine(HealAnimRoutine());
    }
}
