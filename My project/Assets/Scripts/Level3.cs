using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    void Update()
    {
        FindObjectOfType<RandomEvent>().currLvl = 3;
    }
}
