using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    [Header("Level Data")]
    //All the level prefabs
    [SerializeField]private GameObject[] selectableLevels;

    //final list of levels
    private List<GameObject> outputLevels = new List<GameObject>();

    //How many levels per stage in the game
    [SerializeField] private int levelsPerStage = 4;
    private GameManager gameManager;
    [SerializeField] private LevelUI inGameUI;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void GenerateLevels()
    {
        outputLevels.Clear();

        var stage1 = GetLevelDifficulty(Level.level1);
        var stage2 = GetLevelDifficulty(Level.level2);
        var stage3 = GetLevelDifficulty(Level.level3);
        var stage4 = GetLevelDifficulty(Level.level4);

        outputLevels.AddRange(GetRandomLevels(stage1, levelsPerStage));
        outputLevels.AddRange(GetRandomLevels(stage2, levelsPerStage));
        outputLevels.AddRange(GetRandomLevels(stage3, levelsPerStage));
        outputLevels.AddRange(GetRandomLevels(stage4, levelsPerStage));
    }

    private List<GameObject> GetLevelDifficulty(Level stage)
    {
        return selectableLevels.Where(levels => levels.GetComponent<LevelData>()?.level == stage).ToList();
    }

    private List<GameObject> GetRandomLevels(List<GameObject> levelSource, int count)
    {
        List<GameObject> result = new List<GameObject>();

        if(levelSource.Count == 0)
        {
            Debug.LogWarning("No Levels To Select From");
            return result;
        }

        List<GameObject> shuffledLevels = levelSource.OrderBy(x => Random.value).ToList();

        int index = 0;

        for(int i = 0; i < count; i++)
        {
            result.Add(shuffledLevels[index]);

            index++;

            if(index >= shuffledLevels.Count)
            {
                index = 0;
            }
        }

        return result;
    }

    void GetCurrentLevel()
    {
        
    }

    void GetNextLevel()
    {
        
    }

    void LoadLevel(GameObject LevelToLoad)
    {
        if (gameManager.levelFinished)
        {
            inGameUI.EnablePrompt();
        }
    }
}
