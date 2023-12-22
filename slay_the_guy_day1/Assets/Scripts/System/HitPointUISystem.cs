using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointUISystem
{
    private GameEvent gameEvent;
    private List<HitPointUIComponent> hitPointUIComponentList = new List<HitPointUIComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();

    public HitPointUISystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;

        gameEvent.AddComponentList += OnAddComponentList;
        gameEvent.RemoveComponentList += OnRemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < hitPointUIComponentList.Count; i++)
        {
            HitPointUIComponent hitPointUIComponent = hitPointUIComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];
            if (!hitPointUIComponent) continue;

            hitPointUIComponent.HitPointText.text = characterBaseComponent.HitPoint.ToString();
        }
    }

    private void OnAddComponentList(GameObject gameObject)
    {
        HitPointUIComponent hitPointUIComponent = gameObject.GetComponent<HitPointUIComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (hitPointUIComponent == null || characterBaseComponent == null) return;

        hitPointUIComponentList.Add(hitPointUIComponent);
        characterBaseComponentList.Add(characterBaseComponent);
    }

    private void OnRemoveComponentList(GameObject gameObject)
    {
        HitPointUIComponent hitPointUIComponent = gameObject.GetComponent<HitPointUIComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (hitPointUIComponent == null || characterBaseComponent == null) return;

        hitPointUIComponentList.Remove(hitPointUIComponent);
        characterBaseComponentList.Remove(characterBaseComponent);
    }
}
