using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBallColor : MonoBehaviour
{
    public List<Material> materials;
    int random;
    MeshRenderer materialMesh;
    void Start()
    {
        random = Random.Range(0, materials.Count); 
        materialMesh = gameObject.GetComponent<MeshRenderer>();
        materialMesh.material = materials[random];
    }
}
