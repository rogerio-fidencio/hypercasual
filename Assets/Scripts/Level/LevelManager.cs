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
    [SerializeField] private List<GameObject> tiles;
    [SerializeField] private int tileNumber;

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
        for (int i = 0; i < tileNumber; i++)
        {
            SpawnTile();
        }
    }

    private void SpawnTile()
    {
        var tile = tiles[Random.Range(0, tiles.Count)];
        var spawnedTile = Instantiate(tile, container).GetComponent<LevelTileBase>();

        if (_spawnedTiles.Count > 0)
        {
            var lastTile = _spawnedTiles[_spawnedTiles.Count - 1];

            spawnedTile.transform.position = lastTile.tileEnd.position;
        }

        _spawnedTiles.Add(spawnedTile);
    }
    #endregion

}
