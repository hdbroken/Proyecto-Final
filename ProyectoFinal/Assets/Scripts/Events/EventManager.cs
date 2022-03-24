using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventManager
{
    
    public static Action onPlayerDie;

    public static Action<bool> onPauseGame;

    public static Action<bool> onPauseGameWithMenu;

    public static Action onWinLevel;    
}
