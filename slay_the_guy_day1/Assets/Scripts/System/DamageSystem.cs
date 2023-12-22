using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DamageSystem
{
    private GameEvent gameEvent;
    private List<DamageComponent> damageComponentList = new List<DamageComponent>();
    private List<CharacterBaseComponent> characterBaseComponentList = new List<CharacterBaseComponent>();

    public DamageSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;

        gameEvent.AddComponentList += OnAddComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < damageComponentList.Count; i++)
        {
            DamageComponent damageComponent = damageComponentList[i];
            CharacterBaseComponent characterBaseComponent = characterBaseComponentList[i];
            if (!damageComponent) continue;

            if (!damageComponent.IsDamage) continue;
            Debug.Log(damageComponent.gameObject.name);

            if (characterBaseComponent.Defense > damageComponent.Damage)
            {
                damageComponent.Damage = 0;
            }
            else
            {
                damageComponent.Damage -= characterBaseComponent.Defense;
            }
            characterBaseComponent.HitPoint -= damageComponent.Damage;
            characterBaseComponent.Defense = 0;
            damageComponent.Damage = 0;
            damageComponent.IsDamage = false;
            if (characterBaseComponent.HitPoint <= 0)
            {
                characterBaseComponent.HitPoint = 0;
                characterBaseComponent.gameObject.SetActive(false);
                Debug.Log("GameOver");
            }
        }
    }

    private void OnAddComponentList(GameObject gameObject)
    {
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (damageComponent == null || characterBaseComponent == null) return;

        damageComponentList.Add(damageComponent);
        characterBaseComponentList.Add(characterBaseComponent);
    }

    private void OnRemoveComponentList(GameObject gameObject)
    {
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();
        CharacterBaseComponent characterBaseComponent = gameObject.GetComponent<CharacterBaseComponent>();

        if (damageComponent == null || characterBaseComponent == null) return;

        damageComponentList.Remove(damageComponent);
        characterBaseComponentList.Remove(characterBaseComponent);
    }


}
