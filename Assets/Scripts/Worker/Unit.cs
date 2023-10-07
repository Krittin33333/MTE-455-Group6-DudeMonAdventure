using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    Idle,
    Walk,
    Die

}

public class Unit : MonoBehaviour
{
    [SerializeField] protected string unitName;
    public string UnitName { get { return unitName; } set { unitName = value; } }

    [SerializeField] protected int unitLevel;
    public int UnitLevel { get { return unitLevel; } set { unitLevel = value; } }

    [SerializeField] protected int damage;
    public int Damage { get { return damage; } set { damage = value; } }

    [SerializeField] protected int damage2;
    public int Damage2 { get { return damage2; } set { damage2 = value; } }

    [SerializeField] protected int damage3;
    public int Damage3 { get { return damage3; } set { damage3 = value; } }

    [SerializeField] protected int maxHP;
    public int MaxHP { get { return maxHP; } set { maxHP = value; } }

    [SerializeField] protected int currentHP;
    public int CurrentHP { get { return currentHP; } set { currentHP = value; } }

    [SerializeField] protected UnitState state;
    public UnitState State { get { return state; } set { state = value; } }

    private int HPbase = 33;
    private int Atkbase = 6;

    public static Unit instance;

    void Awake()
    {
        SetStausHP();
        SetAttack();
        instance = this;
    }

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
             return true;
        else
            return false;

        
    }
    public bool TakeDamage2(int damage2)
    {
        currentHP -= damage2*2;

        if (currentHP <= 0)
            return true;
        else
            return false;


    }
    public bool TakeDamage3(int damage3)
    {
        currentHP -= damage3*MaxHP;

        if (currentHP <= 0)
            return true;
        else
            return false;


    }
    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public void SetStausHP()
    {
        maxHP = (int)(HPbase * (1 + (0.095 * unitLevel) - 0.095));
        currentHP = maxHP;

    }

    public void SetAttack()
    {
        damage = (int)(Atkbase * (1 + (0.095 * unitLevel) - 0.095));
    }
}
