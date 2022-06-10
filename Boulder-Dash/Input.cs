using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Boulder_Dash;

static class Input
{
    public static Direction GetDirection()
    {
        if (IsKeyDown(KeyboardKey.KEY_UP)) return Direction.Up;
        else if (IsKeyDown(KeyboardKey.KEY_DOWN)) return Direction.Down;
        else if (IsKeyDown(KeyboardKey.KEY_LEFT)) return Direction.Left;
        else if (IsKeyDown(KeyboardKey.KEY_RIGHT)) return Direction.Right;
        else return Direction.None;
    }
}
