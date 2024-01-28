using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    public event EventHandler OnExpChanged;
    public event EventHandler OnLevelChanged;

    private int level;
    private int exp;
    private int expToNextLevel;

    public LevelSystem(int _level, int _exp, int _expToNextLevel)
    {
        level = _level;
        exp = _exp;
        expToNextLevel = _expToNextLevel;
    }

    public LevelSystem()
    {
        this.level = 0;
        this.exp = 0;
        this.expToNextLevel = 100;
    }

    public void AddExp(int _exp)
    {
        Debug.Log("Added " + _exp);
        exp += _exp;
        if(exp >= expToNextLevel)
        {
            level ++;
            exp -= expToNextLevel;
            OnLevelChanged?.Invoke(this, EventArgs.Empty);
        }
        OnExpChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UpdateMaxExp()
    {
        this.expToNextLevel += (int) this.expToNextLevel * 1 / 2;
        Debug.Log("Exp to next level: " + expToNextLevel);
    }

    public int GetCurrentLevel()
    {
        return level;
    }

    public float GetExpNormalized()
    {
        return (float) exp / expToNextLevel;
    }
}
