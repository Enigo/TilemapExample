using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameZone : MonoBehaviour
{
    public int Level;

    private const int FieldLineSize = 11;
    private const int FieldTotalTiles = FieldLineSize * FieldLineSize;
    private Dictionary<int, LevelsData.LevelData> _levelsData;

    private void Start()
    {
        _levelsData = GetComponent<LevelsDataLoader>().ReadLevelsData();

        SetupTiles();
    }

    private void SetupTiles()
    {
        var baseLevel = GetComponentsInChildren<Tilemap>()[0];
        var localTilesPositions = new List<Vector3Int>(FieldTotalTiles);
        foreach (var pos in baseLevel.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            localTilesPositions.Add(localPlace);
        }

        SetupPath(localTilesPositions, baseLevel);
    }

    private void SetupPath(List<Vector3Int> localTilesPositions, Tilemap baseLevel)
    {
        var path = _levelsData[Level].path;
        var pathHorizontalTile = TilesResourcesLoader.GetPathHorizontalTile();
        var first = path.First();
        var last = path.Last();
        foreach (var localPosition in localTilesPositions.GetRange(first, Math.Abs(first - last)))
        {
            baseLevel.SetTile(localPosition, pathHorizontalTile);
        }

        var startStopTile = TilesResourcesLoader.GetStartStopTile();
        baseLevel.SetTile(localTilesPositions[first], startStopTile);
        baseLevel.SetTile(localTilesPositions[last], startStopTile);
    }
}