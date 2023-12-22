using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndUISystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private List<TurnEndUIComponent> turnEndUIComponentList = new List<TurnEndUIComponent>();


    public TurnEndUISystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        this.playerObject = player;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(TurnEndUIComponent turnEndUIComponent)
    {
        turnEndUIComponent.TurnEndUI.onClick.AddListener(OnClickTurnEndButton);
    }

    public void OnUpdate()
    {
        for (int i = 0; i < turnEndUIComponentList.Count; i++)
        {
            TurnEndUIComponent turnEndUIComponent = turnEndUIComponentList[i];
            if (!turnEndUIComponent) continue;

            // turnEndUIComponent.Turn += Time.deltaTime;
        }
    }

    private void OnClickTurnEndButton()
    {
        Debug.Log("TurnEnd");
        TurnComponent turnComponent = playerObject.GetComponent<TurnComponent>();
        turnComponent.IsMyTurn = false;
        turnComponent.State = TurnState.None;
    }

    private void AddComponentList(GameObject gameObject)
    {
        TurnEndUIComponent turnEndUIComponent = gameObject.GetComponent<TurnEndUIComponent>();

        if (turnEndUIComponent == null) return;

        turnEndUIComponentList.Add(turnEndUIComponent);

        Initialize(turnEndUIComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        TurnEndUIComponent turnEndUIComponent = gameObject.GetComponent<TurnEndUIComponent>();

        if (turnEndUIComponent == null) return;

        turnEndUIComponentList.Remove(turnEndUIComponent);
    }
}
