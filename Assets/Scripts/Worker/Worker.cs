using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Worker : Unit
{
    private int id;
    public int ID { get { return id; } set { id = value; } }

    [SerializeField] private bool hired = false;
    public bool Hired { get { return hired; } set { hired = value; } }



  /*  private void OnTriggerStay(Collider other)
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
                case FarmStage.plowing:
                    state = UnitState.Plow;
                    farm.CheckTimeForWork();
                    break;
                case FarmStage.sowing:
                    state = UnitState.Sow;
                    farm.CheckTimeForWork();
                    break;
                case FarmStage.maintaining:
                    state = UnitState.Water;
                    farm.CheckTimeForWork();
                    break;
                case FarmStage.harvesting:
                    state = UnitState.Harvest;
                    farm.CheckTimeForWork();
                    break;
            }
        }
    }*/
}
