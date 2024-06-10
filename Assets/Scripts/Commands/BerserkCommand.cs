using Command.Main;
using UnityEngine;

namespace Command.Actions
{
    public class BerserkCommand : UnitCommand
    {
        private bool willHitTarget;
        private float hitChance = 0.2f;
        public BerserkCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => Random.Range(0f, 1f) < hitChance;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);
        
        public override void Undo()
        {
            if (willHitTarget)
            {
                targetUnit.CurrentPower -= targetUnit.CurrentPower/10;
                actorUnit.Owner.ResetCurrentActiveUnit();
            }
        }
    }
}
