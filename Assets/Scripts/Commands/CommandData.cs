
    public struct CommandData
    {
        public int actorUnitID;
        public int targetUnitID;
        public int actorPlayerID;
        public int targetPlayerID;


        public CommandData(int actorUnitID, int targetUnitID, int actorPlayerID, int targetPlayerID)
        {
            this.actorUnitID = actorUnitID;
            this.targetUnitID = targetUnitID;
            this.actorPlayerID = actorPlayerID;
            this.targetPlayerID = targetPlayerID;
        }
    }

