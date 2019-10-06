using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilesResourcesLoader
{
    private const string PathHorizontal = "horizontal";
    private const string StartStop = "start_stop";

    public static Tile GetPathHorizontalTile()
    {
        return GetTileByName(PathHorizontal);
    }

    public static Tile GetStartStopTile()
    {
        return GetTileByName(StartStop);
    }

    private static Tile GetTileByName(string name)
    {
        return (Tile) Resources.Load(name, typeof(Tile));
    }
}