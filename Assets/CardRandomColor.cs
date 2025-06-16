using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRandomColor : MonoBehaviour
{
    public GameObject Card;

    void Start()
    {
        ChangeCardColor(GetRandomColor());
    }

    Color GetRandomColor()
    {
        int randomColorIndex = Random.Range(0, 3);
        
        Color randomColor;
        switch (randomColorIndex)
        {
            case 0:
                randomColor = Color.red;
                break;
            case 1: 
                randomColor = Color.blue;
                break;
            case 2:
                randomColor = Color.yellow;
                break;
            default:
                randomColor = Color.red;
                break;
        }

        return randomColor;
    }

    void ChangeCardColor(Color _cardColor)
    {
        Renderer renderer = Card.GetComponent<Renderer>();
        if (renderer)
        {
            renderer.material.color = _cardColor;
        }
    }
}
