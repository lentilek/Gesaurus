using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveView : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    [SerializeField] private float movement, time;
    public void MoveToPotion()
    {
        screen.transform.DOMoveX(movement, time);
    }
    public void MoveToClient()
    {
        screen.transform.DOMoveX(0, time);
    }
}
