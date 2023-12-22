using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUISystem : MonoBehaviour
{
    private GameEvent gameEvent;
    private GameObject playerObject;
    private List<ManaUIComponent> manaUIComponentList = new List<ManaUIComponent>();

    public ManaUISystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        this.playerObject = player;
        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < manaUIComponentList.Count; i++)
        {
            ManaUIComponent manaUIComponent = manaUIComponentList[i];
            CharacterBaseComponent characterBaseComponent = playerObject.GetComponent<CharacterBaseComponent>();
            if (!manaUIComponent) continue;

            manaUIComponent.ManaText.text = characterBaseComponent.Mana.ToString() + " / " + characterBaseComponent.ManaMax.ToString();
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        ManaUIComponent manaUIComponent = gameObject.GetComponent<ManaUIComponent>();

        if (manaUIComponent == null) return;

        manaUIComponentList.Add(manaUIComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        ManaUIComponent manaUIComponent = gameObject.GetComponent<ManaUIComponent>();

        if (manaUIComponent == null) return;

        manaUIComponentList.Remove(manaUIComponent);
    }
}

