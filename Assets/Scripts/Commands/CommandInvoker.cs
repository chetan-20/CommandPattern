using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker 
{
    private Stack<ICommand> commandRegistry = new Stack<ICommand>();
   
    private bool CommandBelongsToActivePlayer()
    {
        if((commandRegistry.Peek() as UnitCommand).commandData.actorPlayerID == GameService.Instance.PlayerService.ActivePlayerID)
        {
            return true;
        }
        else return false;
    }
    private bool registryEmpty() 
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
        if(!registryEmpty() && CommandBelongsToActivePlayer())
        commandRegistry.Pop().Undo();
    }
}
