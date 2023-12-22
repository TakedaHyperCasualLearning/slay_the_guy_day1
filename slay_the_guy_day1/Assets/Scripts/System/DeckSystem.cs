using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSystem
{
    private GameEvent gameEvent;
    private List<DeckComponent> deckComponentList = new List<DeckComponent>();

    public DeckSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
        gameEvent.DrawCard += DrawCard;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < deckComponentList.Count; i++)
        {
            DeckComponent deckComponent = deckComponentList[i];
            if (!deckComponent) continue;

            if (deckComponent.CardList.Count == 0)
            {
            }
        }
    }

    private List<CardBaseComponent> DrawCard(int num)
    {
        List<CardBaseComponent> temDeckComponentList = new List<CardBaseComponent>();
        DeckComponent deckComponent = deckComponentList[0];
        for (int i = 0; i < num; i++)
        {
            temDeckComponentList.Add(deckComponent.DeckCardList[i]);
        }
        return temDeckComponentList;
    }

    private void Initialize(DeckComponent deckComponent)
    {
        for (int i = 0; i < deckComponent.CardCount; i++)
        {
            CardBaseComponent card = new CardBaseComponent();
            card.Attack = Random.RandomRange(1, 3);
            card.Cost = Random.RandomRange(0, 3);
            deckComponent.DeckCardList.Add(card);
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();

        if (deckComponent == null) return;

        deckComponentList.Add(deckComponent);

        Initialize(deckComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        DeckComponent deckComponent = gameObject.GetComponent<DeckComponent>();

        if (deckComponent == null) return;

        deckComponentList.Remove(deckComponent);
    }
}
