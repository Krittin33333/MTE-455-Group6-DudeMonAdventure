using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerPrefabs;
    public Transform playerSpawnpoint;
    Unit playerUnit;

    void Start()
    {
        GameObject playerGo = Instantiate(PlayerPrefabs, playerSpawnpoint);
        playerUnit = playerGo.GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
