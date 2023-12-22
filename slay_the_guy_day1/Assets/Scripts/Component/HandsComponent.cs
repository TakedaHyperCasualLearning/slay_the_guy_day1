using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsComponent : MonoBehaviour
{
    [SerializeField] List<GameObject> cardList = new List<GameObject>();

    public List<GameObject> CardList { get => cardList; set => cardList = value; }
}
