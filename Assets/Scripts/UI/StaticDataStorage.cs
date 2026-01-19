using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class StaticDataStorage
{
    private static int bestScore = 0;
    private static int shakeCount = 1;
    private static int setNumber = 1;

    private static bool musicStatus = false;
    private static bool soundStatus = false;

    public static int GetBestScore()
    {
        return bestScore;
    }
    
    public static void SetBestScore(int newScore)
    {
        bestScore = newScore;
    }

    public static int GetShakeCount()
    {
        return shakeCount;
    }

    public static void SetShakeCount(int newShakeCount)
    {
        shakeCount = newShakeCount;
    }

    public static int GetSetNumber()
    {
        return setNumber;
    }

    public static void SetSetNumber(int setNumberToSet)
    {
        setNumber = setNumberToSet;
    }

    public static bool GetMusicStatus()
    {
        return musicStatus;
    }

    public static void SetMusicStatus(bool statusToSet)
    {
        musicStatus=statusToSet;
    }

    public static bool GetSoundStatus()
    {
        return soundStatus;
    }

    public static void SetSoundStatus(bool statusToSet)
    {
         soundStatus = statusToSet;
    }
}
