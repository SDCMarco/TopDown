using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSpot : MonoBehaviour
{
    public float healingRate=50;
    public List<Character> healingCharacters;
    private void OnTriggerEnter(Collider other)
    {
        Character characterEntrato = other.GetComponent<Character>();
        if(characterEntrato != null)
        {
            if (healingCharacters.Contains(characterEntrato) == false)
            {
                healingCharacters.Add(characterEntrato);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Character characterUscito = other.GetComponent<Character>();
        if(characterUscito != null)
        {
            healingCharacters.Remove(characterUscito);
        }
    }

    private void Update()
    {
        foreach(Character character in healingCharacters)
        {
            character.ChangeHp(healingRate*Time.deltaTime);
        }
    }
}
