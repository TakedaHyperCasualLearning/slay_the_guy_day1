using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardUIComponent : MonoBehaviour
{
    [SerializeField] private TextMeshPro titleText;
    [SerializeField] private TextMeshPro costText;
    [SerializeField] private TextMeshPro effectText;
    [SerializeField] private Vector2 size;

    public TextMeshPro TitleText { get => titleText; set => titleText = value; }
    public TextMeshPro CostText { get => costText; set => costText = value; }
    public TextMeshPro EffectText { get => effectText; set => effectText = value; }
    public Vector2 Size { get => size; set => size = value; }
}
