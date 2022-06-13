using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash.Tiles;

internal class Rockford : Tile
{
    public Rockford(TileType type, Flag flags, int step, int x, int y) : base(type, flags, step, x, y)
    {
        
    }

    public override void Update(int currentTick, Map map)
    {
        if (MovedThisTick)
            return;

        if (currentTick % Step != 0)
            return;

        (int x, int y) direction = Input.GetDirection() switch
        {
            Direction.Up => (0, -1),
            Direction.Down => (0, 1),
            Direction.Left => (-1, 0),
            Direction.Right => (1, 0),
            _ => (0, 0)
        };

        if (direction == (0, 0))
            return;

        /*
        Console.WriteLine(
            $"Rockford:\n" +
            $" Last position:\n" +
            $"  X:{X}\n" +
            $"  Y:{Y}\n" +
            $" Moving to:\n" +
            $"  X:{X + direction.x}\n" +
            $"  Y:{Y + direction.y}"
            );
        */

        if (X + direction.x >= 0 &&
            X + direction.x < map.TileMap.GetLength(0) &&
            Y + direction.y >= 0 &&
            Y + direction.y < map.TileMap.GetLength(1))
        {

            if (map.TileMap[X + direction.x, Y + direction.y].Type == TileType.Exit && map.CollectedDiamonds == map.TotalDiamonds)
                return;

            if ((map.TileMap[X + direction.x, Y + direction.y].Flags & Flag.Consumable) != 0 && map.TileMap[X + direction.x, Y + direction.y].Type == TileType.Diamond)
                map.CollectedDiamonds++;

            if ((map.TileMap[X + direction.x, Y + direction.y].Flags & Flag.Solid) != 0)
                return;
             
            map.TileMap[X + direction.x, Y + direction.y] = map.TileMap[X, Y];
            map.TileMap[X, Y] = new Space(TileType.Space, Flag.None, 1, X, Y);
            X += direction.x;
            Y += direction.y;
            MovedThisTick = true;
        }
    }
}