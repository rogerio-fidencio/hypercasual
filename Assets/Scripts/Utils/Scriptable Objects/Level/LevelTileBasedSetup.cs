using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/level")]
public class LevelTileBasedSetup : ScriptableObject
{
    [Header("Tiles")]
    public List<LevelTileBase> levelTilesStart;
    public List<LevelTileBase> levelTiles;
    public List<LevelTileBase> levelTilesEnd;

    public int tileNumberStart;
    public int tileNumber;
    public int tileNumberEnd;
}
