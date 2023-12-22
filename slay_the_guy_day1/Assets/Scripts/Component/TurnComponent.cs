using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnComponent : MonoBehaviour
{
    private bool isMyTurn;
    private TurnState state;

    public bool IsMyTurn { get => isMyTurn; set => isMyTurn = value; }
    public TurnState State { get => state; set => state = value; }
}
