using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CardSelectSystem
{
    private GameEvent gameEvent;
    private GameObject enemyObject;
    private GameObject playerObject;
    private List<CardSelectComponent> cardSelectComponentList = new List<CardSelectComponent>();
    private List<CardUIComponent> cardUIComponentList = new List<CardUIComponent>();
    private List<CardBaseComponent> cardBaseComponentList = new List<CardBaseComponent>();

    public CardSelectSystem(GameEvent gameEvent, GameObject enemyObject, GameObject playerObject)
    {
        this.gameEvent = gameEvent;
        this.enemyObject = enemyObject;
        this.playerObject = playerObject;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < cardSelectComponentList.Count; i++)
        {
            CardSelectComponent cardSelectComponent = cardSelectComponentList[i];
            CardUIComponent cardUIComponent = cardUIComponentList[i];
            CardBaseComponent cardBaseComponent = cardBaseComponentList[i];
            CharacterBaseComponent characterBaseComponent = playerObject.GetComponent<CharacterBaseComponent>();
            if (!cardSelectComponent) continue;

            if (!Input.GetMouseButtonDown(0)) continue;

            Debug.Log("cost:" + cardBaseComponent.Cost);

            if (!BoxToDot(cardUIComponent)) continue;

            if (characterBaseComponent.Mana < cardBaseComponent.Cost) continue;

            cardSelectComponent.gameObject.SetActive(false);
            DamageComponent damageComponent = enemyObject.GetComponent<DamageComponent>();
            damageComponent.Damage = cardBaseComponent.Attack;
            damageComponent.IsDamage = true;
            characterBaseComponent.Mana -= cardBaseComponent.Cost;
        }
    }

    private bool BoxToDot(CardUIComponent cardUIComponent)
    {
        Vector2 position = Camera.main.WorldToScreenPoint(cardUIComponent.transform.position) - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector2 size = Camera.main.WorldToScreenPoint(cardUIComponent.Size) - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        float rad = cardUIComponent.transform.rotation.z * Mathf.Deg2Rad;
        Vector2 vertex_left_up = new Vector2(
            (-size.x) * Mathf.Cos(rad) + (size.y * -Mathf.Sin(rad)),
            (-size.x) * Mathf.Sin(rad) + (size.y * Mathf.Cos(rad)));
        Vector2 vertex_right_up = new Vector2(
            size.x * Mathf.Cos(rad) + (size.y * -Mathf.Sin(rad)),
            size.x * Mathf.Sin(rad) + (size.y * Mathf.Cos(rad)));
        Vector2 vertex_left_down = new Vector2(
            (-size.x) * Mathf.Cos(rad) + ((-size.y) * -Mathf.Sin(rad)),
            (-size.x) * Mathf.Sin(rad) + ((-size.y) * Mathf.Cos(rad)));
        Vector2 vertex_right_down = new Vector2(
            size.x * Mathf.Cos(rad) + ((-size.y) * -Mathf.Sin(rad)),
            size.x * Mathf.Sin(rad) + ((-size.y) * Mathf.Cos(rad)));

        vertex_left_up += position;
        vertex_right_up += position;
        vertex_left_down += position;
        vertex_right_down += position;

        Vector2 left_down_to_left_up = vertex_left_up - vertex_left_down;
        Vector2 left_up_to_right_up = vertex_right_up - vertex_left_up;
        Vector2 right_up_to_right_down = vertex_right_down - vertex_right_up;
        Vector2 right_down_to_left_down = vertex_left_down - vertex_right_down;

        Vector2 mousePosition = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector2 left_down_to_mouse = mousePosition - vertex_left_down;
        Vector2 left_up_to_mouse = mousePosition - vertex_left_up;
        Vector2 right_up_to_mouse = mousePosition - vertex_right_up;
        Vector2 right_down_to_mouse = mousePosition - vertex_right_down;

        float crossCheck = left_down_to_left_up.x * left_down_to_mouse.y - left_down_to_mouse.x * left_down_to_left_up.y;
        if (crossCheck > 0) return false;
        crossCheck = left_up_to_right_up.x * left_up_to_mouse.y - left_up_to_mouse.x * left_up_to_right_up.y;
        if (crossCheck > 0) return false;
        crossCheck = right_up_to_right_down.x * right_up_to_mouse.y - right_up_to_mouse.x * right_up_to_right_down.y;
        if (crossCheck > 0) return false;
        crossCheck = right_down_to_left_down.x * right_down_to_mouse.y - right_down_to_mouse.x * right_down_to_left_down.y;
        if (crossCheck > 0) return false;

        return true;
    }

    private void AddComponentList(GameObject gameObject)
    {
        CardSelectComponent cardSelectComponent = gameObject.GetComponent<CardSelectComponent>();
        CardUIComponent cardUIComponent = gameObject.GetComponent<CardUIComponent>();
        CardBaseComponent cardBaseComponent = gameObject.GetComponent<CardBaseComponent>();

        if (cardBaseComponent == null || cardUIComponent == null || cardSelectComponent == null) return;

        cardSelectComponentList.Add(cardSelectComponent);
        cardUIComponentList.Add(cardUIComponent);
        cardBaseComponentList.Add(cardBaseComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        CardSelectComponent cardSelectComponent = gameObject.GetComponent<CardSelectComponent>();
        CardUIComponent cardUIComponent = gameObject.GetComponent<CardUIComponent>();
        CardBaseComponent cardBaseComponent = gameObject.GetComponent<CardBaseComponent>();

        if (cardBaseComponent == null || cardUIComponent == null || cardSelectComponent == null) return;

        cardSelectComponentList.Remove(cardSelectComponent);
        cardUIComponentList.Remove(cardUIComponent);
        cardBaseComponentList.Remove(cardBaseComponent);
    }
}

