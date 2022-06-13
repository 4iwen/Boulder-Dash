using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash.Tiles;

internal class Boulder : Tile
{
    Random r = new();

    public bool Falling = false;
    public Boulder(TileType type, Flag flags, int step, int x, int y) : base(type, flags, step, x, y)
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
            if (map.TileMap[X, Y + 1].Type == TileType.Rockford && Falling)
            {
                Environment.Exit(0);
            }
            else if (map.TileMap[X, Y + 1].Type == TileType.Space)
            {
                map.TileMap[X, Y + 1] = map.TileMap[X, Y];
                map.TileMap[X, Y] = new Space(TileType.Space, Flag.None, 1, X, Y);
                Y++;
                MovedThisTick = true;
                Falling = true;
            }
            else
            {
                int dir = r.Next(0, 2); // generate random falling direction

                if (dir == 1)
                {
                    if (map.TileMap[X + 1, Y].Type == TileType.Space &&
                       (map.TileMap[X, Y + 1].Flags & Flag.Rounded) != 0 &&
                       map.TileMap[X + 1, Y + 1].Type == TileType.Space)
                    {
                        map.TileMap[X + 1, Y] = map.TileMap[X, Y];
                        map.TileMap[X, Y] = new Space(TileType.Space, Flag.None, 1, X, Y);
                        X++;
                        MovedThisTick = true;
                    }
                    else if (map.TileMap[X - 1, Y].Type == TileType.Space &&
                            (map.TileMap[X, Y + 1].Flags & Flag.Rounded) != 0 &&
                            map.TileMap[X - 1, Y + 1].Type == TileType.Space)
                    {
                        map.TileMap[X - 1, Y] = map.TileMap[X, Y];
                        map.TileMap[X, Y] = new Space(TileType.Space, Flag.None, 1, X, Y);
                        X--;
                        MovedThisTick = true;
                    }
                }
                else
                {
                    if (map.TileMap[X - 1, Y].Type == TileType.Space &&
                       (map.TileMap[X, Y + 1].Flags & Flag.Rounded) != 0 &&
                       map.TileMap[X - 1, Y + 1].Type == TileType.Space)
                    {
                        map.TileMap[X - 1, Y] = map.TileMap[X, Y];
                        map.TileMap[X, Y] = new Space(TileType.Space, Flag.None, 1, X, Y);
                        X--;
                        MovedThisTick = true;
                    }
                    else if (map.TileMap[X + 1, Y].Type == TileType.Space &&
                            (map.TileMap[X, Y + 1].Flags & Flag.Rounded) != 0 &&
                            map.TileMap[X + 1, Y + 1].Type == TileType.Space)
                    {
                        map.TileMap[X + 1, Y] = map.TileMap[X, Y];
                        map.TileMap[X, Y] = new Space(TileType.Space, Flag.None, 1, X, Y);
                        X++;
                        MovedThisTick = true;
                    }
                }
            }


        }
    }
}