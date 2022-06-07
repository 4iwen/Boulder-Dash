using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Boulder_Dash;

static class Program
{
    public static void Main()
    {
        InitWindow(1280, 704 + 32, "Boulder Dash");
        SetTargetFPS(60);

        Map map = new(path: "map.txt");

        while (!WindowShouldClose())
        {
            BeginDrawing();
            ClearBackground(Color.BLACK);
            DrawFPS(8, 8);

            map.Update();
            map.Render();

            EndDrawing();
        }

        CloseWindow();
    }
}