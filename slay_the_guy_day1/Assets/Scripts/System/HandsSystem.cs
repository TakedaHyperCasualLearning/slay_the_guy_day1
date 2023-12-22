using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsSystem
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private List<HandsComponent> handsComponentList = new List<HandsComponent>();

    public HandsSystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        this.playerObject = player;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    private void Initialize(HandsComponent handsComponent)
    {
        for (int i = 0; i < handsComponent.CardList.Count; i++)
        {
            gameEvent.AddComponentList(handsComponent.CardList[i].gameObject);
        }
    }

    public void OnUpdate()
    {
        for (int i = 0; i < handsComponentList.Count; i++)
        {
            HandsComponent handsComponent = handsComponentList[i];
            TurnComponent turnComponent = playerObject.GetComponent<TurnComponent>();
            if (!handsComponent) continue;
            if (!turnComponent.IsMyTurn) continue;
            if (turnComponent.State != TurnState.Draw) continue;

            DrawCard(handsComponent, turnComponent);
        }
    }

    private void DrawCard(HandsComponent handsComponent, TurnComponent turnComponent)
    {
        List<CardBaseComponent> cardList = gameEvent.DrawCard(handsComponent.CardList.Count);

        for (int i = 0; i < cardList.Count; i++)
        {
            CardBaseComponent card = cardList[i];
            card.Attack = cardList[i].Attack;
            card.Cost = cardList[i].Cost;
            handsComponent.CardList[i].SetActive(true);
            CardUIComponent cardUIComponent = handsComponent.CardList[i].GetComponent<CardUIComponent>();
            cardUIComponent.EffectText.text = card.Attack.ToString();
            cardUIComponent.CostText.text = card.Cost.ToString();
            Debug.Log(card.Cost);
        }

        turnComponent.State = TurnState.Play;
    }

    private void AddComponentList(GameObject gameObject)
    {
        HandsComponent handsComponent = gameObject.GetComponent<HandsComponent>();

        if (handsComponent == null) return;

        handsComponentList.Add(handsComponent);

        Initialize(handsComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        HandsComponent handsComponent = gameObject.GetComponent<HandsComponent>();

        if (handsComponent == null) return;

        handsComponentList.Remove(handsComponent);
    }
}
