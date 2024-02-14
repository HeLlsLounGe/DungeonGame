using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    void Update()
    {
        FindObjectOfType<RandomEvent>().currLvl = 1;
    }
}
