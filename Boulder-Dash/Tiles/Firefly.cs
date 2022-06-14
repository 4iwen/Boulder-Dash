using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash.Tiles;

internal class Firefly : Tile
{
    public Firefly(TileType type, Flag flags, int step, int x, int y) : base(type, flags, step, x, y)
    {

    }

    public override void Update(int currentTick, Map map)
    {
        if (MovedThisTick)
            return;

        if (currentTick % Step != 0)
            return;

        if (X - 1 >= 0 &&
            X + 1 < map.TileMap.GetLength(0) &&
            Y - 1 >= 0 &&
            Y + 1 < map.TileMap.GetLength(1))
        {
            if (map.TileMap[X, Y + 1].Type == TileType.Amoeba ||
                map.TileMap[X + 1, Y].Type == TileType.Amoeba ||
                map.TileMap[X - 1, Y].Type == TileType.Amoeba ||
                map.TileMap[X, Y - 1].Type == TileType.Amoeba)
            {
                Explode(map);
            }
            else if (map.TileMap[X, Y + 1].Type == TileType.Rockford ||
                     map.TileMap[X + 1, Y].Type == TileType.Rockford ||
                     map.TileMap[X - 1, Y].Type == TileType.Rockford ||
                     map.TileMap[X, Y - 1].Type == TileType.Rockford)
            {
                Explode(map);
                Program.EndGame(Type);
            }
            else if (map.TileMap[X, Y - 1].Type == TileType.Boulder)
            {
                Boulder tile = map.TileMap[X, Y - 1] as Boulder;

                if (tile.Falling)
                    Explode(map);
            }
            else if (map.TileMap[X, Y + 1].Type != TileType.Space && map.TileMap[X - 1, Y].Type == TileType.Space)
            {
                map.TileMap[X - 1, Y] = map.TileMap[X, Y];
                map.TileMap[X, Y] = new Space(TileType.Space, Flag.Explodable, 1, X, Y);
                X--;
                MovedThisTick = true;
            }
            else if (map.TileMap[X - 1, Y].Type != TileType.Space && map.TileMap[X, Y - 1].Type == TileType.Space)
            {
                map.TileMap[X, Y - 1] = map.TileMap[X, Y];
                map.TileMap[X, Y] = new Space(TileType.Space, Flag.Explodable, 1, X, Y);
                Y--;
                MovedThisTick = true;
            }
            else if (map.TileMap[X, Y - 1].Type != TileType.Space && map.TileMap[X + 1, Y].Type == TileType.Space)
            {
                map.TileMap[X + 1, Y] = map.TileMap[X, Y];
                map.TileMap[X, Y] = new Space(TileType.Space, Flag.Explodable, 1, X, Y);
                X++;
                MovedThisTick = true;
            }
            else if (map.TileMap[X + 1, Y].Type != TileType.Space && map.TileMap[X, Y + 1].Type == TileType.Space)
            {
                map.TileMap[X, Y + 1] = map.TileMap[X, Y];
                map.TileMap[X, Y] = new Space(TileType.Space, Flag.Explodable, 1, X, Y);
                Y++;
                MovedThisTick = true;
            }
        }
    }

    private void Explode(Map map)
    {
        map.TileMap[X, Y] = new Space(TileType.Space, Flag.Explodable, 1, X, Y);

        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                if ((map.TileMap[X + x, Y + y].Flags & Flag.Explodable) != 0)
                    map.TileMap[X + x, Y + y] = new Space(TileType.Space, Flag.Explodable, 1, X + x, Y + y);
            }
        }
    }

}