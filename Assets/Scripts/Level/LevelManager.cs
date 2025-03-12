using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] private Transform container;

    [SerializeField] private List<GameObject> levels;

    [SerializeField] private int _index;
    private GameObject currentLevel;

    [Header("Tiles")]
    [SerializeField] private List<LevelTileBase> levelTilesStart;
    [SerializeField] private List<LevelTileBase> levelTiles;
    [SerializeField] private List<LevelTileBase> levelTilesEnd;
    [SerializeField] private int tileNumberStart;
    [SerializeField] private int tileNumber;
    [SerializeField] private int tileNumberEnd;

    private List<LevelTileBase> _spawnedTiles;

    private void Awake()
    {
        CreateLevelTiles();
    }

    private void SpawnNextLevel()
    {

        if (currentLevel != null)
        {
            Destroy(currentLevel);
            _index++;

            if (_index >= levels.Count)
            {
                ResetIndex();
            }
        }
        currentLevel = Instantiate(levels[_index], container);
        currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetIndex()
    {
        _index = 0;
    }

    #region

    private void CreateLevelTiles()
    {
        _spawnedTiles = new List<LevelTileBase>();
        for (int i = 0; i < tileNumberStart; i++)
        {
            SpawnTile(levelTilesStart);
        }

        for (int i = 0; i < tileNumber; i++)
        {
            SpawnTile(levelTiles);
        }

        for (int i = 0; i < tileNumberEnd; i++)
        {
            SpawnTile(levelTilesEnd);
        }
    }

    private void SpawnTile(List<LevelTileBase> list)
    {
        var tile = list[Random.Range(0, list.Count)];
        var spawnedTile = Instantiate(tile, container);

        if (_spawnedTiles.Count > 0)
        {
            var lastTile = _spawnedTiles[_spawnedTiles.Count - 1];

            spawnedTile.transform.position = lastTile.tileEnd.position;
        }

        _spawnedTiles.Add(spawnedTile);
    }
    #endregion

}
