using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private GameObject workerPrefab;
    public GameObject WorkerPrefab { get { return workerPrefab; } }

    [SerializeField] private TMP_Text LevelText;
    // Start is called before the first frame update
    void Start()
    {
        Setlevel(workerPrefab);
    }
    public void Setlevel(GameObject UnitObj)
    {
         Unit U = UnitObj.GetComponent<Unit>();
         LevelText.text = ("Lv. "+U.UnitLevel.ToString());
    }

}
