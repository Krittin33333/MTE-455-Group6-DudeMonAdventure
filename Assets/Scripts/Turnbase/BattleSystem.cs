﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public enum BattleState { START , PLAYERTURN , ENEMYTURN , WON ,LOST }
public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject PlayerPrefabs;
    public GameObject EnemyPrefab;
    public GameObject CommandPanel;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public Vector3 targetPosition = new Vector3(3.48f, -1f, 7.39f);
    public Vector3 targetRotation = new Vector3(0f, 224.791f, 0f);

    public TextMeshProUGUI dialogueText;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD PlayerHUD;
    public BattleHUD EnemyHUD;
    [SerializeField] string mapScene;
    [SerializeField] string mapScenelost;

    public static BattleSystem instance;

    private void Awake()
    {
        instance = this;
        SetHero();
    }

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    public void SetHero()
    {
        EnemyPrefab = Office.instance.Enemyhitted;
        Destroy(Office.instance.Enemyhitted);
    }


    IEnumerator SetupBattle()
    {
        GameObject playerGo =  Instantiate(PlayerPrefabs , playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(EnemyPrefab , enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        enemyUnit.transform.position = targetPosition;
        enemyUnit.transform.eulerAngles = targetRotation;

        dialogueText.text = enemyUnit.UnitName + " ป่าเข้าจู่โจม!!!";


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
        dialogueText.text = "โจมตีสำเร็จ";
        CommandOff();
        yield return new WaitForSeconds(0.5f);

        if (isDead )
        {   
            state = BattleState.WON;
            EndBattle();
            yield return new WaitForSeconds(2.5f);
            switchscene();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator PlayerAttack2()
    {
        bool isDead = enemyUnit.TakeDamage2(playerUnit.Damage2);

        EnemyHUD.SetHP(enemyUnit.CurrentHP);
        dialogueText.text = "โจมตีสำเร็จ";
        CommandOff();
        yield return new WaitForSeconds(0.5f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
            yield return new WaitForSeconds(2.5f);
            switchscene();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerAttack3()
    {
        bool isDead = enemyUnit.TakeDamage3(playerUnit.Damage3);

        EnemyHUD.SetHP(enemyUnit.CurrentHP);
        dialogueText.text = "โจมตีสำเร็จ";
        CommandOff();
        yield return new WaitForSeconds(0.5f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
            yield return new WaitForSeconds(2.5f);
            switchscene();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(0.5f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.Damage);

        CommandOff();

        PlayerHUD.SetHP(playerUnit.CurrentHP);

        dialogueText.text = enemyUnit.UnitName + " ตี Dudemon ของคุณ";

        yield return new WaitForSeconds(2f);

        if (isDead ) 
        {
            state = BattleState.LOST;
            
            EndBattleLost();
            yield return new WaitForSeconds(2.5f);
            switchscenelost();

        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {

        if (state == BattleState.WON)
        {
            dialogueText.text = "Dudemon ของคุณเอาชนะ " + enemyUnit.UnitName;
        }

    }

    public void switchscene()
    {
        SceneManager.LoadScene(mapScene);
    }
    void EndBattleLost()
    {

        if (state == BattleState.LOST)
        {
            dialogueText.text = "Dudemon ของคุณแพ้ " + enemyUnit.UnitName;
        }

    }
    public void switchscenelost()
    {
        SceneManager.LoadScene(mapScenelost);
    }

    public void PlayerTurn()
    {
        CommandOn();
        dialogueText.text = "เลือกท่าโจมตี";
    }
    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(2);
        CommandOff();
        PlayerHUD.SetHP(playerUnit.CurrentHP);
        dialogueText.text = "รักษา";

        //dialog

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());



    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine (PlayerAttack());
    }
    public void OnPunchButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack2());
        
    }

    public void OnBiteButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack3());

    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
        Debug.Log("HeeeHeee");
    }
    public void CommandOn()
    {
        if (CommandPanel.activeSelf != true)
        {
            CommandPanel.SetActive(true);
        }

    }
    public void CommandOff()
    {
        if (CommandPanel.activeSelf != false)
        {
            CommandPanel.SetActive(false);
        }

    }
}
