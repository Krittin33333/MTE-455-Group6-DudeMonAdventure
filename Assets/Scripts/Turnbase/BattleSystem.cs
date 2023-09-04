using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START , PLAYERTURN , ENEMYTURN , WON ,LOST }
public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject PlayerPrefabs;
    public GameObject EnemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD PlayerHUD;
    public BattleHUD EnemyHUD;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        GameObject playerGo =  Instantiate(PlayerPrefabs , playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

       GameObject enemyGo = Instantiate(EnemyPrefab , enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        PlayerHUD.setHUD(playerUnit);
        EnemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    IEnumerator PlayerAttack()
    {
       bool isDead = enemyUnit.TakeDamage(playerUnit.Damage);

        EnemyHUD.SetHP(enemyUnit.CurrentHP);

        yield return new WaitForSeconds(1f);

        if (isDead )
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.Damage);

        PlayerHUD.SetHP(playerUnit.CurrentHP);

        yield return new WaitForSeconds(1f);

        if (isDead ) 
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {

    }

    public void PlayerTurn()
    {

    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine (PlayerAttack());
    }

}
