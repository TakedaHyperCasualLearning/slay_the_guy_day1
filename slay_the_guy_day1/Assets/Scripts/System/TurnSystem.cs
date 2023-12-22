using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public enum TurnState
{
    None,
    Start,
    Draw,
    Play,
    Battle,
    End,
}

public class TurnSystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private GameObject enemyObject;
    private List<TurnComponent> turnComponentList = new List<TurnComponent>();

    public TurnSystem(GameEvent gameEvent, GameObject player, GameObject enemy)
    {
        this.gameEvent = gameEvent;
        this.playerObject = player;
        this.enemyObject = enemy;

        gameEvent.AddComponentList += OnAddComponentList;
        gameEvent.RemoveComponentList += OnRemoveComponentList;
    }
    private void Initialization(TurnComponent turnComponent)
    {
        if (turnComponent.gameObject == playerObject)
        {
            turnComponent.IsMyTurn = true;
            turnComponent.State = TurnState.Start;
            return;
        }

        turnComponent.IsMyTurn = false;
        turnComponent.State = TurnState.None;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < turnComponentList.Count; i++)
        {
            TurnComponent turnComponent = turnComponentList[i];
            if (!turnComponent) continue;
            if (turnComponent.gameObject == playerObject) continue;
            TurnComponent turn = playerObject.GetComponent<TurnComponent>();

            if (!turn.IsMyTurn && !turnComponent.IsMyTurn)
            {
                turnComponent.IsMyTurn = true;

                turnComponent.State = TurnState.Battle;
                Debug.Log("EnemyTurn");
            }

            if (!turn.IsMyTurn && turnComponent.State == TurnState.None && turnComponent.IsMyTurn)
            {
                turn.IsMyTurn = true;
                turn.State = TurnState.Draw;
                turn.GetComponent<CharacterBaseComponent>().Mana = turn.GetComponent<CharacterBaseComponent>().ManaMax;
                turnComponent.IsMyTurn = false;
                turnComponent.State = TurnState.None;
                Debug.Log("PlayerTurn");
            }
        }
    }

    private void OnAddComponentList(GameObject gameObject)
    {
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();

        if (turnComponent == null) return;

        turnComponentList.Add(turnComponent);

        Initialization(turnComponent);
    }

    private void OnRemoveComponentList(GameObject gameObject)
    {
        TurnComponent turnComponent = gameObject.GetComponent<TurnComponent>();

        if (turnComponent == null) return;

        turnComponentList.Remove(turnComponent);
    }
}
