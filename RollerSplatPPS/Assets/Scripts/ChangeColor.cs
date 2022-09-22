using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    GridCell gridCell;
    MeshRenderer mesh;
    public static Action ForOccupiedCount;
    private void Awake()
    {
        gridCell = gameObject.GetComponent<GridCell>();
        mesh = gameObject.GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !gridCell.isOccupied)
        {
            gridCell.isOccupied = true;
            mesh.material.color = Color.blue;
            ForOccupiedCount?.Invoke();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") && !gridCell.isOccupied)
        {
            gridCell.isOccupied = true;
            ForOccupiedCount?.Invoke();
        }
    }
}
