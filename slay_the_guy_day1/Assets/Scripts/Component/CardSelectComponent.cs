using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectComponent : MonoBehaviour
{
    private int cost;
    private string costMax;

    public int Cost { get => cost; set => cost = value; }
    public string CostMax { get => costMax; set => costMax = value; }
}
