using System;
using UnityEngine;
using UnityEngine.Events;

public enum ETeam
{
    Buoni,
    Cattivi
}

public class Character : MonoBehaviour
{
    public UnityEvent<float,float> OnHpChange;
    public UnityEvent OnCharacterDeath;
    public ETeam team;
    public float hp;
    public float hpMax;

    public bool IsDead()
    {
        return hp <= 0;
    }

    public void ChangeHp(float deltaHp)
    {
        hp = Mathf.Clamp(hp + deltaHp, 0, hpMax);
        OnHpChange.Invoke(hp, hpMax);

        if(IsDead()) 
        {
            OnCharacterDeath.Invoke();
        }
    }

    

    private void Start()
    {

    }


    public void CharacterStartShoot()
    {
        GetHeldWeapon().StartShoot();
    }
    internal void CharacterEndShoot()
    {
        GetHeldWeapon().EndShoot();
    }

    public Weapon GetHeldWeapon()
    {
        return GetComponentInChildren<Weapon>();
    }

}
