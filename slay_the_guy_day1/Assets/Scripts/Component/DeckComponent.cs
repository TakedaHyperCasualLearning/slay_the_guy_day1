using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckComponent : MonoBehaviour
{
    [SerializeField] List<GameObject> cardList = new List<GameObject>();
    private List<CardBaseComponent> deckCardList = new List<CardBaseComponent>();
    [SerializeField] int cardCount = 10;

    public List<GameObject> CardList { get => cardList; set => cardList = value; }
    public List<CardBaseComponent> DeckCardList { get => deckCardList; set => deckCardList = value; }
    public int CardCount { get => cardCount; set => cardCount = value; }
}
