using Command.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker 
{
    private Stack<ICommand> commandRegistry = new Stack<ICommand>();
    public CommandInvoker () => SubscribeToEvents();

    private void SubscribeToEvents()
    {
        GameService.Instance.EventService.OnReplayButtonClicked.AddListener(SetReplayStack);
    }

    private void SetReplayStack()
    {
        GameService.Instance.ReplayService.SetCommandStack(commandRegistry);
        commandRegistry.Clear();
    }

    private bool CommandBelongsToActivePlayer()
    {
        if((commandRegistry.Peek() as UnitCommand).commandData.actorPlayerID == GameService.Instance.PlayerService.ActivePlayerID)
        {
            return true;
        }
        else return false;
    }
    private bool RegistryEmpty() 
    {
        if (commandRegistry.Count == 0)
            return true;
        else return false;
    }
    public void ExecuteCommand(ICommand commandToExecute)=>commandToExecute.Execute();    
    public void RegisterCommand(ICommand commandToRegister)=>commandRegistry.Push(commandToRegister);    
    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
    }
    public void Undo()
    {
        if(!RegistryEmpty() && CommandBelongsToActivePlayer())
        commandRegistry.Pop().Undo();
    }
}
