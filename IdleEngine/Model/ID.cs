namespace IdleEngine.Model;

public class BaseID
{
    public int ActualID { get; set; }

    public BaseID()
    {
        ActualID = -1;
    }
    public BaseID(int number)
    {
        ActualID = number;
    }
}

public class PlayerID : BaseID;
public class ShipID : BaseID;
public class WorldID : BaseID;
public class ActionID : BaseID;
public class EventID : BaseID;
