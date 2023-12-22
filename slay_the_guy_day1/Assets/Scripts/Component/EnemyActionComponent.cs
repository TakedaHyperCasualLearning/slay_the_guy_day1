using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionComponent : MonoBehaviour
{
    [SerializeField] private int attack;
    [SerializeField] private int defense;

    public int Attack { get => attack; set => attack = value; }
    public int Defense { get => defense; set => defense = value; }
}
