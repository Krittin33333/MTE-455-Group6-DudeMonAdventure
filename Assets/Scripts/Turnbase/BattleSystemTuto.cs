using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public enum BattleState2 { START , PLAYERTURN , ENEMYTURN , WON ,LOST }
public class BattleSystemTuto : MonoBehaviour
{
    public BattleState2 state;
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

    public GameObject LoadingScene;

    public static BattleSystemTuto instance;

    public GameObject EffectButton;
    public GameObject EffectButton2;
    public GameObject EffectButton3;
    public GameObject EffectButton4;
    public GameObject EffectA;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        state = BattleState2.START;
        StartCoroutine(SetupBattle());
    }



    IEnumerator SetupBattle()
    {
        GameObject playerGo =  Instantiate(PlayerPrefabs , playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(EnemyPrefab , enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        dialogueText.text = enemyUnit.UnitName + " ป่าเข้าจู่โจม!!!";

        PlayerHUD.setHUD(playerUnit);
        EnemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState2.PLAYERTURN;
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
            state = BattleState2.WON;
            EndBattle();
            yield return new WaitForSeconds(2.5f);
            switchscene();
        }
        else
        {
            state = BattleState2.ENEMYTURN;
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
            state = BattleState2.WON;
            EndBattle();
            yield return new WaitForSeconds(2.5f);
            switchscene();
        }
        else
        {
            state = BattleState2.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerAttack3()
    {
        bool isDead = enemyUnit.TakeDamage3(playerUnit.Damage3);

        EnemyHUD.SetHP(enemyUnit.CurrentHP);
        dialogueText.text = "โจมตีสำเร็จ";
        CommandOff();
        yield return new WaitForSeconds(3.5f);

        if (isDead)
        {
            state = BattleState2.WON;
            EndBattle();
            Loading();
            yield return new WaitForSeconds(2.5f);
            switchscene();
        }
        else
        {
            state = BattleState2.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(3.5f);

        EffectButton.SetActive(false);
        EffectButton2.SetActive(false);
        EffectButton3.SetActive(false);
        EffectButton4.SetActive(false);

        if (!EffectA.activeInHierarchy)
            EffectA.SetActive(true);

        bool isDead = playerUnit.TakeDamage(enemyUnit.Damage);

        CommandOff();

        PlayerHUD.SetHP(playerUnit.CurrentHP);

        dialogueText.text = enemyUnit.UnitName + " ตี Dudemon ของคุณ";

        yield return new WaitForSeconds(2f);

        if (isDead ) 
        {
            state = BattleState2.LOST;
            
            EndBattleLost();
            Loading();
            yield return new WaitForSeconds(2.5f);
            switchscenelost();

        }
        else
        {
            state = BattleState2.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {

        if (state == BattleState2.WON)
        {
            dialogueText.text = "Dudemon ของคุณเอาชนะ " + enemyUnit.UnitName;
        }

    }

    public void Loading()
    {
        if (LoadingScene.activeSelf != true)
        {
            LoadingScene.SetActive(true);
        }
    }

    public void switchscene()
    {
        SceneManager.LoadScene(mapScene);
    }
    void EndBattleLost()
    {

        if (state == BattleState2.LOST)
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
        EffectA.SetActive(false);

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

        state = BattleState2.ENEMYTURN;
        StartCoroutine(EnemyTurn());



    }
    public void OnAttackButton()
    {
        if (state != BattleState2.PLAYERTURN)
            return;

        if (!EffectButton2.activeInHierarchy)
            EffectButton2.SetActive(true);

        StartCoroutine (PlayerAttack());
    }
    public void OnPunchButton()
    {
        if (state != BattleState2.PLAYERTURN)
            return;

        if (!EffectButton.activeInHierarchy)
            EffectButton.SetActive(true);

        StartCoroutine(PlayerAttack2());
        
    }

    public void OnBiteButton()
    {
        if (state != BattleState2.PLAYERTURN)
            return;

        if (!EffectButton3.activeInHierarchy)
            EffectButton3.SetActive(true);

        StartCoroutine(PlayerAttack3());

    }

    public void OnHealButton()
    {
        if (state != BattleState2.PLAYERTURN)
            return;

        if (!EffectButton4.activeInHierarchy)
            EffectButton4.SetActive(true);

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
