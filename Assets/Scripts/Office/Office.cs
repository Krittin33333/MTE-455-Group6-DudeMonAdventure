using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Office : MonoBehaviour
{
    [SerializeField] private int money;
    public int Money { get { return money; } set { money = value; } }

    [SerializeField] private int income;
    public int Income { get { return income; } set { income = value; } }

    [SerializeField] private int levelenemy;
    public int Levelenemy { get { return levelenemy; } set { levelenemy = value; } }

    [SerializeField] private GameObject enemyhitted;
    public GameObject Enemyhitted { get { return enemyhitted; } set { enemyhitted = value; } }

    [SerializeField] private int levelPlayer;
    public int LevelPlayer { get { return levelPlayer; } set { levelPlayer = value; } }

    [SerializeField] private List<Worker> workers = new List<Worker>();
    public List<Worker> Workers { get { return workers; } }


    [SerializeField] private int dailyCostWages;

    [SerializeField] private List<Structure> structures = new List<Structure>();
    public List<Structure> Structures { get { return structures; } }


    [SerializeField] private int availStaff;
    public int AvailStaff { get { return availStaff; } set { availStaff = value; } }

    [SerializeField] private GameObject staffParent;

    [SerializeField] private GameObject spawnPosition;
    public GameObject SpawnPosition { get { return spawnPosition; } }

    [SerializeField] private GameObject rallyPosition;

    public static Office instance;

    

    private void Awake()
    {
        if (instance == null)
        {
            // If there's no instance, this is the first one, so don't destroy it.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one.
            Destroy(gameObject);
        }
        if (levelPlayer <= 0) 
        {
            SetlevelPlayer();
        }

       
    }

    public void AddBuilding(Structure s)
    {
        structures.Add(s);
    }

    public void RemoveBuilding(Structure s)
    {
        structures.Remove(s);
        Destroy(s.gameObject);
    }

    public void SetlevelPlayer()
    {
        levelPlayer = Unit.instance.UnitLevel;
    }

    public void Setlevelenemy(GameObject UnitObj)
    {
        Unit U = UnitObj.GetComponent<Unit>();
        
        EnemyController.instance.player = null;

        U.transform.parent = staffParent.transform;

        Enemyhitted = UnitObj;
        Levelenemy = U.UnitLevel;
        //BattleSystem.instance.SetPrefapsenemy(UnitObj);
    }
}
