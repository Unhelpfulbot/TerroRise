using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarCompleted : MonoBehaviour
{
    [SerializeField] GameObject gameController;
    private void Awake()
    {
        gameController.GetComponent<GameControl>().CompletedPillar += 1;
    }
}
