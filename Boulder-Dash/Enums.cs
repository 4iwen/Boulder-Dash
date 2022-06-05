using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dash;

public enum TileType
{
    Space = 0,
    Rockford,
    Dirt,
    Boulder,
    Diamond,
    Wall,
    TitaniumWall,
    Firefly,
    Butterfly,
    Amoeba,
    Exit
}

public enum Direction
{
    None = 0,
    Left,
    Right,
    Up,
    Down
}