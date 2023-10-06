using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private GameObject workerPrefab;
    public GameObject WorkerPrefab { get { return workerPrefab; } }

    [SerializeField] private int ievelenemy;
    public int Levelenemy { get { return ievelenemy; } set { ievelenemy = value; } }

    [SerializeField] private GameObject enemyPrefab;
    public GameObject EnemyPrefab { get { return enemyPrefab; } }

    [SerializeField] private TMP_Text LevelText;

    public static LevelUI instance;

    void Start()
    {
        instance = this;
        Setlevel(workerPrefab);
    }
    public void Setlevel(GameObject UnitObj)
    {
         Unit U = UnitObj.GetComponent<Unit>();

         enemyPrefab = UnitObj;
         Levelenemy = U.UnitLevel;
         LevelText.text = ("Lv. "+Levelenemy);
    }

}
