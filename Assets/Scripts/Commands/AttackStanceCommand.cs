using Command.Main;
namespace Command.Actions
{
    public class AttackStanceCommand : UnitCommand
    {
        private bool willHitTarget;
        public AttackStanceCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);
        public override void Undo()
        {
            if (willHitTarget)
            {
                targetUnit.CurrentPower -= targetUnit.CurrentPower / 10;
                actorUnit.Owner.ResetCurrentActiveUnit();
            }
        }
    }
}
