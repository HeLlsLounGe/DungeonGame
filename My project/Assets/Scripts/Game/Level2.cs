using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    void Update()
    {
        FindObjectOfType<RandomEvent>().currLvl = 2;
    }
}
