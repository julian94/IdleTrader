namespace IdleEngine.Model;

public class BaseID
{
    public ulong ActualID { get; set; }

    public BaseID()
    {
        ActualID = 0ul;
    }
    public BaseID(ulong number)
    {
        ActualID = number;
    }
}

public class PlayerID : BaseID;
public class ShipID : BaseID;
public class WorldID : BaseID;
public class ActionID : BaseID;
public class EventID : BaseID;
