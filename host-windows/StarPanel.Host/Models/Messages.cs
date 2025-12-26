namespace StarPanel.Host.Models;

public class BaseMessage
{
    public string Type { get; set; } = string.Empty;
    public string? SessionToken { get; set; }
}

public class HelloMessage : BaseMessage
{
    public string AppVersion { get; set; } = string.Empty;
    public string DeviceName { get; set; } = string.Empty;
}

public class PairRequestMessage : BaseMessage
{
    public string Code { get; set; } = string.Empty;
}

public class EventButtonMessage : BaseMessage
{
    public string ControlId { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty; // "down", "up", "tap"
    public long Timestamp { get; set; }
}

public class EventAxisMessage : BaseMessage
{
    public string ControlId { get; set; } = string.Empty;
    public double Value { get; set; } // -1.0 to +1.0
    public long Timestamp { get; set; }
}

public class RunMacroMessage : BaseMessage
{
    public string MacroId { get; set; } = string.Empty;
    public string Mode { get; set; } = "oneshot"; // "oneshot" or "maintain"
}

public class SwitchPageMessage : BaseMessage
{
    public string PageId { get; set; } = string.Empty;
}
