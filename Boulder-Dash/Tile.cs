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

    public Flag Flags { get; private set; }

    public Tile(TileType type, Flag flags, int step)
    {
        Type = type;
        Step = step;
        Flags = flags;
    }

    public abstract void Update();
}
