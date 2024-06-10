using Command.Main;

namespace Command.Actions
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;
        private int previousMaxHp;
        public MeditateCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;
        public override void Execute() 
        {
            previousMaxHp = targetUnit.CurrentMaxHealth;
            GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);
        }
        public override void Undo()
        {
            if (willHitTarget)
            {
                int maxHealthToDecraese = targetUnit.CurrentMaxHealth - previousMaxHp;
                targetUnit.CurrentMaxHealth = previousMaxHp;
                targetUnit.TakeDamage(maxHealthToDecraese);
            }
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
    }
}