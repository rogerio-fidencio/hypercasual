using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] private Transform container;

    [SerializeField] private int _index;
    private GameObject currentLevel;

    [SerializeField] private List<LevelTileBasedSetup> levelTileBasedSetups;

    [Header("Animation")]
    [SerializeField] private Ease scaleTileEase = Ease.InOutBack;
    [SerializeField] private float scaleTileDuration = .2f;
    [SerializeField] private float scaleTileDelayTime =.2f;
    

    private List<LevelTileBase> _spawnedTiles = new List<LevelTileBase>();
    private LevelTileBasedSetup _currSetup;

    private void Awake()
    {
        CreateLevelTiles();
    }

    private void ResetIndex()
    {
        _index = 0;
    }

    #region
    
    private void CreateLevelTiles()
    {
        clearSpawnedTiles();

        if (currentLevel != null) 
        { 
            _index++;

            if (_index >= levelTileBasedSetups.Count)
            {
                ResetIndex();
            }
        }

        _currSetup = levelTileBasedSetups[_index];

        for (int i = 0; i < _currSetup.tileNumberStart; i++)
        {
            SpawnTile(_currSetup.levelTilesStart);
        }

        for (int i = 0; i < _currSetup.tileNumber; i++)
        {
            SpawnTile(_currSetup.levelTiles);
        }

        for (int i = 0; i < _currSetup.tileNumberEnd; i++)
        {
            SpawnTile(_currSetup.levelTilesEnd);
        }
        
        ColorManager.Instance.ChangeColorByType(_currSetup.ArtType);

        StartCoroutine(ScaleTiles());
    }

    private void clearSpawnedTiles()
    {
        for (int i = _spawnedTiles.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedTiles[i]);
        }

        _spawnedTiles.Clear();
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

        foreach (var piece in spawnedTile.GetComponentsInChildren<ArtPiece>())
        {
            piece.changeArtModel(ArtManager.Instance.getArtSetupByArtType(_currSetup.ArtType).model);
        }

        _spawnedTiles.Add(spawnedTile);
    }
    
    private IEnumerator ScaleTiles()
    {
        foreach (var spawnedTile in _spawnedTiles)
        {
            spawnedTile.transform.localScale = Vector3.zero;
        }
        
        yield return null;

        for (int i = 0; i < _spawnedTiles.Count; i++)
        {
            _spawnedTiles[i].transform.DOScale(1, scaleTileDuration).SetEase(scaleTileEase);
            yield return new WaitForSeconds(scaleTileDelayTime);
        }
        
        CoinAnimationManager.Instance.StartAnimation();
    }
    
    #endregion

}
