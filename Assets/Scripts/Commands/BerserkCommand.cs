using Command.Main;


namespace Command.Actions
{
    public class BerserkCommand : UnitCommand
    {
        private bool willHitTarget;
        public BerserkCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}
