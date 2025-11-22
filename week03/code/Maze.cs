using System;
using System.Collections.Generic;

public class Maze
{
    // Dictionary to store maze structure
    // Key: (x, y) coordinate
    // Value: (canMoveLeft, canMoveRight, canMoveUp, canMoveDown)
    private readonly Dictionary<(int, int), (bool, bool, bool, bool)> _mazeMap;
    
    // Current position in the maze
    public int CurrX { get; private set; }
    public int CurrY { get; private set; }

    public Maze(Dictionary<(int, int), (bool, bool, bool, bool)> mazeMap)
    {
        _mazeMap = mazeMap;
        CurrX = 1;
        CurrY = 1;
    }

    /// <summary>
    /// Move left in the maze if possible
    /// </summary>
    public bool MoveLeft()
    {
        // Check if current position exists in maze
        if (!_mazeMap.ContainsKey((CurrX, CurrY)))
            return false;
        
        // Get the valid movements from current position
        var (canMoveLeft, _, _, _) = _mazeMap[(CurrX, CurrY)];
        
        // If we can move left, update position
        if (canMoveLeft)
        {
            CurrX--;
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// Move right in the maze if possible
    /// </summary>
    public bool MoveRight()
    {
        // Check if current position exists in maze
        if (!_mazeMap.ContainsKey((CurrX, CurrY)))
            return false;
        
        // Get the valid movements from current position
        var (_, canMoveRight, _, _) = _mazeMap[(CurrX, CurrY)];
        
        // If we can move right, update position
        if (canMoveRight)
        {
            CurrX++;
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// Move up in the maze if possible
    /// </summary>
    public bool MoveUp()
    {
        // Check if current position exists in maze
        if (!_mazeMap.ContainsKey((CurrX, CurrY)))
            return false;
        
        // Get the valid movements from current position
        var (_, _, canMoveUp, _) = _mazeMap[(CurrX, CurrY)];
        
        // If we can move up, update position
        if (canMoveUp)
        {
            CurrY--;
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// Move down in the maze if possible
    /// </summary>
    public bool MoveDown()
    {
        // Check if current position exists in maze
        if (!_mazeMap.ContainsKey((CurrX, CurrY)))
            return false;
        
        // Get the valid movements from current position
        var (_, _, _, canMoveDown) = _mazeMap[(CurrX, CurrY)];
        
        // If we can move down, update position
        if (canMoveDown)
        {
            CurrY++;
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// Display the current position
    /// </summary>
    public void ShowStatus()
    {
        Console.WriteLine($"Current position: ({CurrX}, {CurrY})");
    }
}
