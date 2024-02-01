using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEvent : MonoBehaviour
{
    [SerializeField] List<int> encounters;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (encounters.Count > 0)
        {
            int r = Random.Range(0, encounters.Count);
        }
    }
}
