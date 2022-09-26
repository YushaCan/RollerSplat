using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    GridCell gridCell;
    MeshRenderer mesh;
    public static Action ForOccupiedCount;
    Color gridColor;
    public ScriptableBool red, green, blue, purple;
    private void OnEnable()
    {
        RandomBallColor.changeGameGridColor += ChangeGridColor;
    }
    private void OnDisable()
    {
        RandomBallColor.changeGameGridColor -= ChangeGridColor;
    }
    private void Awake()
    {
        gridCell = gameObject.GetComponent<GridCell>();
        mesh = gameObject.GetComponent<MeshRenderer>();
    }
    void ChangeGridColor()
    {
        if (red.isTrue)
        {
            gridColor = Color.red;
        }
        else if (blue.isTrue)
        {
            gridColor = Color.blue;
        }
        else if (green.isTrue)
        {
            gridColor = Color.green;
        }
        else if (purple.isTrue)
        {
            gridColor = Color.magenta;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !gridCell.isOccupied)
        {
            gridCell.isOccupied = true;
            mesh.material.color = gridColor;
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
