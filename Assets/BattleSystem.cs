using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, WATING }
public class BattleSystem : MonoBehaviour
{
    public TheGame theGame;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerPosition;
    public Transform enemyPosition;

    FigthingUnit playerUnit;
    FigthingUnit enemyUnit;

    public BattleState state;
    public Text dialogueText;
    public GameObject figthUi;
    public GameObject playerGO;
    public GameObject enemyGO ;
    public battleHUD playerBattleHUD;
    public battleHUD enemyBattleHUD;
    public void StartBatte(GameObject Enemypref)
    {
        enemyPrefab = Enemypref;
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        figthUi.SetActive(true);
        playerGO = Instantiate(playerPrefab, playerPosition);
        playerUnit = playerGO.GetComponent<FigthingUnit>();
        enemyGO = Instantiate(enemyPrefab, enemyPosition);
        enemyGO.transform.localPosition = new Vector3 (0f, 0f, 0f);
        enemyUnit = enemyGO.GetComponent<FigthingUnit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + "approaches...";

        playerBattleHUD.SetHUD(playerUnit);
        enemyBattleHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    void PlayerTurn()
    {
        dialogueText.text = "Choose an action";
    }
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyBattleHUD.SetHP(enemyUnit.currentHp);
        dialogueText.text = "The attack is successful!";
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            StartCoroutine(endBattle());
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(1f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerBattleHUD.SetHP(playerUnit.currentHp);
        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            StartCoroutine(endBattle());
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    IEnumerator endBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            yield return new WaitForSeconds(2f);
            playerGO.SetActive(false);
            enemyGO.SetActive(false);
            figthUi.SetActive(false);
            theGame.disableFigthMode();
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated!";
        }
    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        state = BattleState.WATING;
        StartCoroutine(PlayerAttack());
    }
    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        playerBattleHUD.SetHP(playerUnit.currentHp);
        dialogueText.text = "You fell renewed strength!";
        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        state = BattleState.WATING;
        StartCoroutine(PlayerHeal());
    }
}
