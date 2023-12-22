using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardBaseComponent : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private int attack;

    public int Cost { get => cost; set => cost = value; }
    public int Attack { get => attack; set => attack = value; }
}
