using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash.Tiles;

internal class Amoeba : Tile
{
    Random r = new();

    public Amoeba(TileType type, Flag flags, int step, int x, int y) : base(type, flags, step, x, y)
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
            int dir = r.Next(0, 4);

            if (dir == 0)
            {
                if (map.TileMap[X + 1, Y].Type == TileType.Space || map.TileMap[X + 1, Y].Type == TileType.Dirt)
                {
                    var newTile = new Amoeba(TileType.Amoeba, Flag.Solid, 200, X + 1, Y);
                    newTile.MovedThisTick = true;
                    map.TileMap[X + 1, Y] = newTile;

                    map.TotalAmoeba++;
                }
            }
            else if (dir == 1)
            {
                if (map.TileMap[X, Y - 1].Type == TileType.Space || map.TileMap[X, Y - 1].Type == TileType.Dirt)
                {
                    var newTile = new Amoeba(TileType.Amoeba, Flag.Solid, 200, X, Y - 1);
                    newTile.MovedThisTick = true;
                    map.TileMap[X, Y - 1] = newTile;

                    map.TotalAmoeba++;
                }
            }
            else if (dir == 2)
            {
                if (map.TileMap[X, Y + 1].Type == TileType.Space || map.TileMap[X, Y + 1].Type == TileType.Dirt)
                {
                    var newTile = new Amoeba(TileType.Amoeba, Flag.Solid, 200, X, Y + 1);
                    newTile.MovedThisTick = true;
                    map.TileMap[X, Y + 1] = newTile;

                    map.TotalAmoeba++;
                }
            }
            else if (dir == 3)
            {

                if (map.TileMap[X - 1, Y].Type == TileType.Space || map.TileMap[X - 1, Y].Type == TileType.Dirt)
                {
                    var newTile = new Amoeba(TileType.Amoeba, Flag.Solid, 200, X - 1, Y);
                    newTile.MovedThisTick = true;
                    map.TileMap[X - 1, Y] = newTile;

                    map.TotalAmoeba++;
                }
            }
        }
        MovedThisTick = true;
    }
}