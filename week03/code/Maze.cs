using System;
using System.Collections.Generic;

public class Maze
{
    // Key: (x, y)
    //
    // Value:
    // [0] = left
    // [1] = right
    // [2] = up
    // [3] = down
    private readonly Dictionary<(int, int), bool[]> _mazeMap;

    public int CurrX { get; private set; }
    public int CurrY { get; private set; }

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;

        // Posição inicial
        CurrX = 1;
        CurrY = 1;
    }

    public void MoveLeft()
    {
        if (!_mazeMap.ContainsKey((CurrX, CurrY)))
            throw new InvalidOperationException("Can't go that way!");

        if (!_mazeMap[(CurrX, CurrY)][0])
            throw new InvalidOperationException("Can't go that way!");

        CurrX--;
    }

    public void MoveRight()
    {
        if (!_mazeMap.ContainsKey((CurrX, CurrY)))
            throw new InvalidOperationException("Can't go that way!");

        if (!_mazeMap[(CurrX, CurrY)][1])
            throw new InvalidOperationException("Can't go that way!");

        CurrX++;
    }

    public void MoveUp()
    {
        if (!_mazeMap.ContainsKey((CurrX, CurrY)))
            throw new InvalidOperationException("Can't go that way!");

        if (!_mazeMap[(CurrX, CurrY)][2])
            throw new InvalidOperationException("Can't go that way!");

        CurrY--;
    }

    public void MoveDown()
    {
        if (!_mazeMap.ContainsKey((CurrX, CurrY)))
            throw new InvalidOperationException("Can't go that way!");

        if (!_mazeMap[(CurrX, CurrY)][3])
            throw new InvalidOperationException("Can't go that way!");

        CurrY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={CurrX}, y={CurrY})";
    }
}
