using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [Header("Level Data")]
    //All the level prefabs
    [SerializeField]private GameObject[] selectableLevels;

    //final list of levels
    private List<GameObject> outputLevels = new List<GameObject>();

    //How many levels per stage in the game
    private const int levelsPerStage = 4;
}
