using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash;

abstract class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public TileType Type { get; private set; }
    public int Step { get; private set; }
    public Flag Flags { get; private set; }
    public bool MovedThisTick { get; set; } = false;

    public Tile(TileType type, Flag flags, int step, int x, int y)
    {
        Type = type;
        Step = step;
        Flags = flags;
        X = x;
        Y = y;
    }

    public abstract void Update(int currentTick, Map map);
}
