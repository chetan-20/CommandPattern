using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker 
{
    private Stack<ICommand> commandRegistry = new Stack<ICommand>();
    
    public void ExecuteCommand(ICommand commandToExecute)=>commandToExecute.Execute();    
    public void RegisterCommand(ICommand commandToRegister)=>commandRegistry.Push(commandToRegister);    
    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
    }
}
