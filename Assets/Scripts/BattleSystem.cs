using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public SceneChanger Manager;
	///public Transform playerBattleStation;
	//public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;
	public Button att;
	public Button heal;
	public Text dialogueText;
	public GameObject Final;
	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

	public static bool ganado = false;

	// Start is called before the first frame update
	void Start()
	{
		
		SceneChanger Cambio = Instantiate(Manager);
		state = BattleState.START;
		StartCoroutine(SetupBattle());
		att.interactable = false;
		heal.interactable = false;
	}
    private void Update()
    {
		
        if(state != BattleState.PLAYERTURN)
        {
			att.interactable = false;
			heal.interactable = false;
        }
        else
        {
			att.interactable = true;
			heal.interactable = true;
		}
    }
    IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab/*, playerBattleStation*/);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemyPrefab/*, enemyBattleStation*/);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = "Un " + enemyUnit.unitName + " salvaje aparece...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(1.5f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(Unit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "Atacas a "+ enemyUnit.unitName+" causando "+ Unit.damage + " puntos de daño!";

		yield return new WaitForSeconds(0.5f);

		if(isDead)
		{
			state = BattleState.WON;
			ganado = true;
			StartCoroutine(EndBattle());
			
			if (SceneManager.GetActiveScene().name == "FinalBattle")
			{
				Final.SetActive(true);
				yield return new WaitForSeconds(120f);
			}
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}	

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " ataca a " + playerUnit.unitName + " causando " + (enemyUnit.enemyDamage - Unit.defence)+" puntos de daño!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.enemyDamage-Unit.defence);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);
		print("dragon ded" + isDead);
		if(isDead)
		{
			state = BattleState.LOST;
			ganado = false;
			EndBattle();
			
			
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	IEnumerator EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "Derrotaste a "+ enemyUnit.unitName+ "!";
			yield return new WaitForSeconds(1f);
			if (SceneManager.GetActiveScene().name == "FinalBattle") Final.SetActive(true);
            else	{ 
						Manager.ChangeScene("Level2");
					}

		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "Fuiste vencido por"+ enemyUnit.unitName + "!";
			yield return new WaitForSeconds(1f);
			Manager.ChangeScene("Level2");
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Elige tu proxima accion!";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(25);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "Te sientes revitalizado ! (+25HP)" ;

		yield return new WaitForSeconds(1.5f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}
