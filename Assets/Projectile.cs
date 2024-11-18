using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 20;
    public float timeToLive = 3;
    public Character shooter;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timeToLive);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject oggettoConCuiHoColliso = collision.gameObject;

        if(oggettoConCuiHoColliso.GetComponent<Character>() != null)
        {
            if(AreTheyEnemies(shooter, oggettoConCuiHoColliso.GetComponent<Character>()))
            {
                Destroy(gameObject);
                oggettoConCuiHoColliso.GetComponent<Character>().ChangeHp(-damage);
            }
        }

        if(oggettoConCuiHoColliso.GetComponent<Projectile>() != null)
        {
            if(AreTheyEnemies(shooter, oggettoConCuiHoColliso.GetComponent<Projectile>().shooter))
            {
                Destroy(gameObject);
                Destroy(oggettoConCuiHoColliso);
            }
        }
    }

    internal void InitializeProjectile(Character character)
    {
        shooter = character;
        GetComponent<MeshRenderer>().material.color = (shooter.team == ETeam.Buoni) ? Color.blue : Color.red;
    }

    private bool AreTheyEnemies(Character shooter, Character victim)
    {
        return shooter.team != victim.team;
    }
}
