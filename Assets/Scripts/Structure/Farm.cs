using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FarmStage
{
    seedState,
    seedlingsState,
    growState,
    harvesState
}

public class Farm : Structure
{
    [SerializeField] private FarmStage stage = FarmStage.seedState;
    public FarmStage Stage { get { return stage; } }

    [SerializeField] private int maxStaffNum = 3;
    public int MaxStaffNum { get { return maxStaffNum; } set { maxStaffNum = value; } }

    [SerializeField] private int timeRequired; //Day until harvest
    [SerializeField] private int timePassed; //Day passed since last harvest

    private float WorkTimer = 0f;
    private float WorkTimeWait = 1f;

    [SerializeField] private float produceTimer = 0f;
    private int secondsPerDay = 10;

    [SerializeField] private GameObject FarmUI;

    [SerializeField] private List<Worker> currentWorkers;
    public List<Worker> CurrentWorkers { get { return currentWorkers; } set { currentWorkers = value; } }

    [SerializeField] private GameObject[] Stages;

    // Update is called once per frame
    void Update()
    {
        CheckPlowing();
        CheckSowing();
        CheckMaintaining();
        CheckHarvesting();
        CheckTimeForWork();
    }

    public void CheckPlowing()
    {
        if ((hp >= 100) && (stage == FarmStage.seedState))
        {
            stage = FarmStage.seedlingsState;
            hp = 1;
            //ChangeStage(0);
            
        }
    }

    public void CheckSowing()
    {
        if ((hp >= 100) && (stage == FarmStage.seedlingsState))
        {
            functional = true; //Plant will auto grow
            stage = FarmStage.growState;
            hp = 1;
           // ChangeStage(1);
        }
    }

    public void CheckMaintaining()
    {
        if ((hp >= 100) && (stage == FarmStage.growState))
        {
            produceTimer += Time.deltaTime;
            timePassed = Mathf.CeilToInt(produceTimer / secondsPerDay);

            if ((functional == true) && (timePassed >= timeRequired))
            {
                produceTimer = 0;
                stage = FarmStage.harvesState;
                hp = 1;
               // ChangeStage(2);
            }
        }
    }

    public void CheckHarvesting()
    {
        if ((hp >= 100) && (stage == FarmStage.harvesState))
        {
            HarvestResult();
            Debug.Log("CheckHarvestResult!!");
            Debug.Log(stage);
            // ChangeStage(3);
            hp = 1;
            stage = FarmStage.seedState;
            

        }
    }

    public void AddStaffToFarm(Worker w)
    {
        currentWorkers.Add(w);
    }

    private void Working()
    {
        hp += 20;
    }

    public void CheckTimeForWork()
    {
        WorkTimer += Time.deltaTime;

        if (WorkTimer >= WorkTimeWait && hp <= 110)
        {
            WorkTimer = 0;
            Working();
        }
    }


    /* public void DisableAllStage()
     {
         for (int i = 0; i < Stages.Length; i++)
             Stages[i].SetActive(false);
         // Debug.Log(1);
     }*/

    /* private void ChangeStage(int i)
     {
         DisableAllStage();
         Stages[i].SetActive(true);
     }*/

     public void HarvestResult()
     {
         Office.instance.Money += 100000;
        MainUI.instance.UpdateResourceUI();
     }




}

