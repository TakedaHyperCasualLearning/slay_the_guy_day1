using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnEndUIComponent : MonoBehaviour
{
    [SerializeField] private Button turnEndUI;

    public Button TurnEndUI { get => turnEndUI; set => turnEndUI = value; }
}
