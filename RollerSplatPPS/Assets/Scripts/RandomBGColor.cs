using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBGColor : MonoBehaviour
{
    public List<Color> colors;
    int random;
    RawImage image;
    void Start()
    {
        image = gameObject.GetComponent<RawImage>();
        random = Random.Range(0, colors.Count);
        image.color = colors[random];
    }
}
