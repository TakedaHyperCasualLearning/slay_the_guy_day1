using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseComponent : MonoBehaviour
{
    [SerializeField] private int hitPoint;
    [SerializeField] private int hitPointMax;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int mana;
    [SerializeField] private int manaMax;

    public int HitPoint { get => hitPoint; set => hitPoint = value; }
    public int HitPointMax { get => hitPointMax; set => hitPointMax = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Defense { get => defense; set => defense = value; }
    public int Mana { get => mana; set => mana = value; }
    public int ManaMax { get => manaMax; set => manaMax = value; }
}
