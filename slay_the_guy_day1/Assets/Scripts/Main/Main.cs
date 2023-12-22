using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject turnEndUI;
    [SerializeField] private GameObject Deck;
    [SerializeField] private GameObject Hands;
    [SerializeField] private GameObject ManaUI;

    private GameEvent gameEvent = new GameEvent();

    private CardSelectSystem cardSelectSystem;
    private DamageSystem damageSystem;
    private EnemyAttackSystem enemyAttackSystem;
    private HitPointUISystem hitPointUISystem;
    private TurnEndUISystem turnEndUISystem;
    private TurnSystem turnSystem;
    private DeckSystem deckSystem;
    private HandsSystem handsSystem;
    private ManaUISystem manaUISystem;

    void Start()
    {
        cardSelectSystem = new CardSelectSystem(gameEvent, enemy, player);
        damageSystem = new DamageSystem(gameEvent);
        enemyAttackSystem = new EnemyAttackSystem(gameEvent, player);
        hitPointUISystem = new HitPointUISystem(gameEvent);
        turnEndUISystem = new TurnEndUISystem(gameEvent, player);
        turnSystem = new TurnSystem(gameEvent, player, enemy);
        deckSystem = new DeckSystem(gameEvent);
        handsSystem = new HandsSystem(gameEvent, player);
        manaUISystem = new ManaUISystem(gameEvent, player);

        // gameEvent.AddComponentList?.Invoke(card);
        gameEvent.AddComponentList?.Invoke(enemy);
        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(turnEndUI);
        gameEvent.AddComponentList?.Invoke(Deck);
        gameEvent.AddComponentList?.Invoke(Hands);
        gameEvent.AddComponentList?.Invoke(ManaUI);
    }

    void Update()
    {
        cardSelectSystem.OnUpdate();
        damageSystem.OnUpdate();
        enemyAttackSystem.OnUpdate();
        hitPointUISystem.OnUpdate();
        turnEndUISystem.OnUpdate();
        turnSystem.OnUpdate();
        deckSystem.OnUpdate();
        handsSystem.OnUpdate();
        manaUISystem.OnUpdate();
    }
}
