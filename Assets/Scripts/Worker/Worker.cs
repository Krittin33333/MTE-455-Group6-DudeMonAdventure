using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;

public class Worker : Unit
{
    private int id;
    public int ID { get { return id; } set { id = value; } }

    [SerializeField] private bool hired = false;
    public bool Hired { get { return hired; } set { hired = value; } }

    [SerializeField] private string staffName;
    public string StaffName { get { return staffName; } set { staffName = value; } }

    [SerializeField] private int dailyWage;
    public int DailyWage { get { return dailyWage; } set { dailyWage = value; } }

    [SerializeField] private int charSkinID;
    public int CharSkinID { get { return charSkinID; } set { charSkinID = value; } }
    public GameObject[] charSkin;

    [SerializeField] private int charFaceID;
    public int CharFaceID { get { return charFaceID; } set { charFaceID = value; } }
    public Sprite[] charFacePic;

    protected NavMeshAgent navAgent;
    public NavMeshAgent NavAgent { get { return navAgent; } set { navAgent = value; } }

    private float distance;

    //Timer
    private float CheckStateTimer = 0f;
    private float CheckStateTimeWait = 0.5f;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckStaffState();
        
    }

    protected void CheckStaffState()
    {
        CheckStateTimer += Time.deltaTime;

        if (CheckStateTimer >= CheckStateTimeWait)
        {
            CheckStateTimer = 0;
            SwitchStaffState();
        }
    }

    protected void SwitchStaffState()
    {

        switch (state)
        {
            case UnitState.Walk:
                WalkUpdate();
                break;
        }
    }

    protected void WalkUpdate()
    {
        distance = Vector3.Distance(navAgent.destination, transform.position);

        if (distance <= 3f)
        {
            navAgent.isStopped = true;
            state = UnitState.Idle;
        }
    }

    public void SetToWalk(Vector3 dest)
    {
        state = UnitState.Walk;

        navAgent.SetDestination(dest);
        navAgent.isStopped = false;
    }

     public void InitiateCharID(int i)
    {
        charSkinID = i;
        charFaceID = i;
    }

    public void ChangeCharSkin()
    {
        for (int i = 0; i < charSkin.Length; i++)
        {
            if (i == charSkinID)
            {
                charSkin[i].SetActive(true);
            }
            else
            {
                charSkin[i].SetActive(false);
            }
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != targetStructure)
        {
            return;
        }

        Farm farm = other.gameObject.GetComponent<Farm>();

        if ((farm != null) && (farm.HP < 100))
        {
            switch (farm.Stage)
            {
                case FarmStage.seedState:
                    state = UnitState.Walk;
                    farm.CheckTimeForWork();
                    break;
                case FarmStage.seedlingsState:
                    state = UnitState.Walk;
                    farm.CheckTimeForWork();
                    break;
                case FarmStage.growState:
                    state = UnitState.Walk;
                    farm.CheckTimeForWork();
                    break;
                case FarmStage.harvesState:
                    state = UnitState.Walk;
                    farm.CheckTimeForWork();
                    break;
            }
        }
    }*/


}
