using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Boulder_Dash;

static class Program
{
    public static void Main()
    {
        InitWindow(1280, 704 + 32, "Boulder Dash");
        SetTargetFPS(60);

        Map map = new("map.txt");

        System.Timers.Timer inputTimer = new System.Timers.Timer(100);
        inputTimer.Elapsed += map.CheckInput;
        inputTimer.Start();

        while (!WindowShouldClose())
        {
            BeginDrawing();
            ClearBackground(Color.BLACK);
            map.Update();
            DrawFPS(8, 8);
            EndDrawing();
        }

        CloseWindow();
    }
}