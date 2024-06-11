using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayService 
{
    private Stack<ICommand> replayCommandStack;
    public ReplayState ReplayState { get; private set; }
}
