using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerPosition;
    public Transform enemyPosition;
    
    FigthingUnit playerUnit;
    FigthingUnit enemyUnit;

    public BattleState state;
    public Text dialogueText;
    public GameObject figthUi;

    public battleHUD playerBattleHUD;
    public battleHUD enemyBattleHUD;
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        figthUi.SetActive(true);
        GameObject playerGO = Instantiate(playerPrefab, playerPosition);
        playerUnit = playerGO.GetComponent<FigthingUnit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyPosition);
        enemyUnit = playerGO.GetComponent<FigthingUnit>();

        dialogueText.text = "A wild " + enemyUnit.name + "approaches...";

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
        dialogueText.text = "The attac is successful!";
        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.WON;
            endBattle();
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

        if(isDead)
        {
            state = BattleState.LOST;
            endBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void endBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated!";
        }
    }
    public void OnAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }

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
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());
    }
}
