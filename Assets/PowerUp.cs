using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject newProjectile;
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if(character != null)
        {
            character.GetHeldWeapon().prefabProjectile = newProjectile;
            Destroy(gameObject);
        }
    }

}
