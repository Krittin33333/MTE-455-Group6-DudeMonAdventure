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

    [SerializeField] protected int maxHP;
    public int MaxHP { get { return maxHP; } set { maxHP = value; } }

    [SerializeField] protected int currentHP;
    public int CurrentHP { get { return currentHP; } set { currentHP = value; } }

    [SerializeField] protected GameObject targetStructure;
    public GameObject TargetStructure { get { return targetStructure; } set { targetStructure = value; } }

    [SerializeField] protected UnitState state;
    public UnitState State { get { return state; } set { state = value; } }



    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
             return true;
        else
            return false;

        
    }
}
