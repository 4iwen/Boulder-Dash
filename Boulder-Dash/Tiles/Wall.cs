using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash.Tiles;

internal class Wall : Tile
{
    public Wall(TileType type, Flag flags, int step, int x, int y) : base(type, flags, step, x, y)
    {

    }

    public override void Update(int currentTick, Map map)
    {

    }
}