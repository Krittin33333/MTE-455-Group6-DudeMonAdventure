using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Office : MonoBehaviour
{
    [SerializeField] private int money;
    public int Money { get { return money; } set { money = value; } }

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
        instance = this;
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

 public bool ToHireStaff(GameObject workerObj)
    {
        if (money <= 0)
            return false;

        workerObj.transform.parent = staffParent.transform;

        Worker w = workerObj.GetComponent<Worker>();

        workerObj.SetActive(true);
        w.Hired = true; //Hire this worker
        w.ChangeCharSkin(); //Show 3D model
        w.SetToWalk(rallyPosition.transform.position);

        money -= w.DailyWage;
        AddStaff(w);

        //Update UI
        MainUI.instance.UpdateResourceUI();

        return true;
    }

    public bool ToFireStaff(GameObject staffObj)
    {
        staffObj.transform.parent = LaborMarket.instance.WorkerParent.transform;
        //move Staff obj back to Labor Market



        Worker w = staffObj.GetComponent<Worker>();
        w.Hired = false; //Fire this staff

        if (w.TargetStructure != null)
        {
            Farm f = w.TargetStructure.GetComponent<Farm>();
            if (f != null)
                f.CurrentWorkers.Remove(w); //Remove from this farm
        }

        w.TargetStructure = null; //Quit working
        w.SetToWalk(spawnPosition.transform.position);

        FireStaff(w);
        MainUI.instance.UpdateResourceUI();

        return true;
    }
        public void FireStaff(Worker w)
    {
        workers.Remove(w);
        dailyCostWages -= w.DailyWage;
    }
        

    public void AddStaff(Worker w)
    {
        workers.Add(w);
        dailyCostWages += w.DailyWage;
    }

    private void DeductMoney(int cost)
    {
        Office.instance.Money -= cost;
        MainUI.instance.UpdateResourceUI();
    }
}
