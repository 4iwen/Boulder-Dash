using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash;

abstract class Tile
{
    public TileType Type { get; private set; }

    public int Step { get; private set; } 

    public Tile(TileType type, int step)
    {
        Type = type;
    }
}
