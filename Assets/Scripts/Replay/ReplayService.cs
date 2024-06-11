using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Command.Replay
{
    public class ReplayService
    {
        private Stack<ICommand> replayCommandStack;
        public ReplayState ReplayState { get; private set; }

        public void SetReplayState(ReplayState stateToSet) => ReplayState = stateToSet;
        public ReplayService() => SetReplayState(ReplayState.Deactive);
        public void SetCommandStack(Stack<ICommand> commandsToStack) => replayCommandStack = new Stack<ICommand>(commandsToStack);
        public IEnumerator ExecuteNext()
        {
            yield return new WaitForSeconds(1);
            if (replayCommandStack.Count > 0)
            {
                GameService.Instance.ProcessUnitCommand(replayCommandStack.Pop());
            }
        }
       
    }
    public enum ReplayState
    {
        Deactive,
        Active
    }
}
