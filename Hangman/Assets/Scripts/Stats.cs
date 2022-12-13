using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stats
{
    public int totalWins;
    public int totalLosses;
    public int gamesPlayed;
    public float winRatio;
    public int fastestTime = 9999; // in seconds
    public int checker;
    public float motivationLevel;
    public float actualML;
    public float totalML;
    public float centralTend;
    public void SaveStats(bool hasWonGame, float calculatedML, int data, int playtime)
    {

        StatsData statsList = SaveSystem.LoadStats();

        statsList.totalWins += (hasWonGame) ? 1 : 0;
        statsList.totalLosses += (!hasWonGame) ? 1 : 0;
        statsList.gamesPlayed = statsList.totalLosses + statsList.totalWins;
        statsList.winRatio = (float)Math.Round(((float)statsList.totalWins / statsList.gamesPlayed) * 100, 2);

        statsList.totalML += 3f;
        statsList.actualML += calculatedML;
        statsList.centralTend = (statsList.actualML / statsList.gamesPlayed);

        if (hasWonGame)
        {
            statsList.fastestTime = (playtime >= statsList.fastestTime) ? statsList.fastestTime : playtime;
        }


        statsList.motivationLevel = calculatedML;

        statsList.checker = data;

        SaveSystem.SaveStats(statsList);
    }

    public void InitStats()
    {
        SaveSystem.InitSave(this);
    }
    public void LoadStats()
    {
        StatsData data = SaveSystem.LoadStats();
    }
}
