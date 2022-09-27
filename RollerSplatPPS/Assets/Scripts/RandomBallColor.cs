using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBallColor : MonoBehaviour
{
    public List<Material> materials;
    int random;
    MeshRenderer materialMesh;
    public static Action changeGameGridColor;
    public ScriptableBool red, green, blue, purple;
    public GameObject redTrail, greenTrail, blueTrail, purpleTrail;
    private void Awake()
    {
        blue.isTrue = false;
        green.isTrue = false;
        purple.isTrue = false;
        red.isTrue = false;
        ///////////////
        random = UnityEngine.Random.Range(0, materials.Count); 
        materialMesh = gameObject.GetComponent<MeshRenderer>();
        materialMesh.material = materials[random];
        if (random == 0)
        {
            blue.isTrue = true;
            // Inactivate other trails
            redTrail.gameObject.SetActive(false);
            greenTrail.gameObject.SetActive(false);
            purpleTrail.gameObject.SetActive(false);
        }
        else if (random == 1)
        {
            green.isTrue = true;
            // Inactivate other trails
            redTrail.gameObject.SetActive(false);
            blueTrail.gameObject.SetActive(false);
            purpleTrail.gameObject.SetActive(false);
        }
        else if (random == 2)
        {
            purple.isTrue = true;
            // Inactivate other trails
            redTrail.gameObject.SetActive(false);
            greenTrail.gameObject.SetActive(false);
            blueTrail.gameObject.SetActive(false);
        }
        else if (random == 3)
        {
            red.isTrue = true;
            // Inactivate other trails
            blueTrail.gameObject.SetActive(false);
            greenTrail.gameObject.SetActive(false);
            purpleTrail.gameObject.SetActive(false);
        }
        changeGameGridColor?.Invoke();
    }
}
