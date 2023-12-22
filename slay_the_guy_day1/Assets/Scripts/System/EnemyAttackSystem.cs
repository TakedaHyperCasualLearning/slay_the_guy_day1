using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem
{
    private GameEvent gameEvent;
    private GameObject player;
    private List<EnemyActionComponent> enemyActionComponentList = new List<EnemyActionComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();
    private List<TurnComponent> turnComponentList = new List<TurnComponent>();

    public EnemyAttackSystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        this.player = player;

        gameEvent.AddComponentList += OnAddComponentList;
        gameEvent.RemoveComponentList += OnRemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < enemyActionComponentList.Count; i++)
        {
            EnemyActionComponent enemyActionComponent = enemyActionComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];
            TurnComponent turnComponent = turnComponentList[i];
            if (!enemyActionComponent) continue;
            if (!turnComponent.IsMyTurn) continue;
            if (turnComponent.State != TurnState.Battle) continue;

            RandomAttackORDefense(enemyActionComponent, characterBaseComponent, turnComponent);
        }
    }

    private void RandomAttackORDefense(EnemyActionComponent enemyActionComponent, CharacterBaseComponent characterBaseComponent, TurnComponent turnComponent)
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            Debug.Log("Attack");
            DamageComponent damageComponent = player.GetComponent<DamageComponent>();
            damageComponent.Damage = enemyActionComponent.Attack;
            damageComponent.IsDamage = true;
        }
        else
        {
            Debug.Log("Defense");
            characterBaseComponent.Defense += enemyActionComponent.Defense;
        }

        turnComponent.State = TurnState.None;
    }

    private void OnAddComponentList(GameObject gameObject)
    {
        EnemyActionComponent enemyActionComponent = gameObject.GetComponent<EnemyActionComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();

        if (enemyActionComponent == null || characterBaseComponent == null || turnComponent == null) return;

        enemyActionComponentList.Add(enemyActionComponent);
        characterBaseComponentList.Add(characterBaseComponent);
        turnComponentList.Add(turnComponent);
    }

    private void OnRemoveComponentList(GameObject gameObject)
    {
        EnemyActionComponent enemyActionComponent = gameObject.GetComponent<EnemyActionComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();

        if (enemyActionComponent == null || characterBaseComponent == null || turnComponent == null) return;

        enemyActionComponentList.Remove(enemyActionComponent);
        characterBaseComponentList.Remove(characterBaseComponent);
        turnComponentList.Remove(turnComponent);
    }
}
