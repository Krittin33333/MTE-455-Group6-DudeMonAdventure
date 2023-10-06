using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstatus : MonoBehaviour
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
}
