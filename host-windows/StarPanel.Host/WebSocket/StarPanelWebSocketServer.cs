using Fleck;
using Newtonsoft.Json;
using StarPanel.Host.Models;
using StarPanel.Host.Services;

namespace StarPanel.Host.WebSocket;

public class StarPanelWebSocketServer
{
    private readonly int _port;
    private readonly string _path;
    private readonly ViGEmService _vigemService;
    private readonly KeyboardService _keyboardService;
    private WebSocketServer? _server;
    private readonly Dictionary<string, IWebSocketConnection> _sessions = new();
    private string? _currentPairingCode;
    private readonly Dictionary<string, SessionState> _sessionStates = new();

    public StarPanelWebSocketServer(int port, string path, ViGEmService vigemService)
    {
        _port = port;
        _path = path;
        _vigemService = vigemService;
        _keyboardService = new KeyboardService();
        GeneratePairingCode();
    }

    public async Task StartAsync()
    {
        _server = new WebSocketServer($"ws://0.0.0.0:{_port}");
        _server.Start(socket =>
        {
            socket.OnOpen = () => OnClientConnected(socket);
            socket.OnClose = () => OnClientDisconnected(socket);
            socket.OnMessage = message => OnMessage(socket, message);
        });

        Console.WriteLine($"Pairing code: {_currentPairingCode}");
        await Task.CompletedTask;
    }

    public async Task StopAsync()
    {
        _server?.Dispose();
        await Task.CompletedTask;
    }

    private void OnClientConnected(IWebSocketConnection socket)
    {
        Console.WriteLine($"Client connected: {socket.ConnectionInfo.ClientIpAddress}");
    }

    private void OnClientDisconnected(IWebSocketConnection socket)
    {
        var sessionId = _sessions.FirstOrDefault(x => x.Value == socket).Key;
        if (sessionId != null)
        {
            _sessions.Remove(sessionId);
            _sessionStates.Remove(sessionId);
        }
        Console.WriteLine($"Client disconnected: {socket.ConnectionInfo.ClientIpAddress}");
    }

    private void OnMessage(IWebSocketConnection socket, string message)
    {
        try
        {
            var baseMessage = JsonConvert.DeserializeObject<BaseMessage>(message);
            if (baseMessage == null)
            {
                SendError(socket, "INVALID_MESSAGE", "Invalid message format");
                return;
            }

            switch (baseMessage.Type)
            {
                case "HELLO":
                    HandleHello(socket, message);
                    break;
                case "PAIR_REQUEST":
                    HandlePairRequest(socket, message);
                    break;
                case "EVENT_BUTTON":
                    HandleEventButton(socket, message);
                    break;
                case "EVENT_AXIS":
                    HandleEventAxis(socket, message);
                    break;
                case "RUN_MACRO":
                    HandleRunMacro(socket, message);
                    break;
                case "SWITCH_PAGE":
                    HandleSwitchPage(socket, message);
                    break;
                default:
                    SendError(socket, "UNKNOWN_MESSAGE", $"Unknown message type: {baseMessage.Type}");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing message: {ex.Message}");
            SendError(socket, "PROCESSING_ERROR", ex.Message);
        }
    }

    private void HandleHello(IWebSocketConnection socket, string message)
    {
        var hello = JsonConvert.DeserializeObject<HelloMessage>(message);
        Console.WriteLine($"Hello from: {hello?.DeviceName} (v{hello?.AppVersion})");
        
        var response = new
        {
            type = "PAIR_REQUIRED",
            pairingCode = _currentPairingCode
        };
        socket.Send(JsonConvert.SerializeObject(response));
    }

    private void HandlePairRequest(IWebSocketConnection socket, string message)
    {
        var pairRequest = JsonConvert.DeserializeObject<PairRequestMessage>(message);
        
        if (pairRequest?.Code == _currentPairingCode)
        {
            var sessionToken = Guid.NewGuid().ToString();
            _sessions[sessionToken] = socket;
            _sessionStates[sessionToken] = new SessionState();

            var response = new
            {
                type = "PAIR_OK",
                sessionToken = sessionToken,
                hostName = Environment.MachineName
            };
            socket.Send(JsonConvert.SerializeObject(response));
            Console.WriteLine($"Pairing successful: {sessionToken}");
        }
        else
        {
            var response = new
            {
                type = "PAIR_ERROR",
                reason = "INVALID_CODE"
            };
            socket.Send(JsonConvert.SerializeObject(response));
        }
    }

    private void HandleEventButton(IWebSocketConnection socket, string message)
    {
        var eventButton = JsonConvert.DeserializeObject<EventButtonMessage>(message);
        if (eventButton == null) return;

        // TODO: Vérifier le sessionToken et mapper vers les actions
        // Pour l'instant, exemple simple
        Console.WriteLine($"Button event: {eventButton.ControlId} - {eventButton.Action}");
    }

    private void HandleEventAxis(IWebSocketConnection socket, string message)
    {
        var eventAxis = JsonConvert.DeserializeObject<EventAxisMessage>(message);
        if (eventAxis == null) return;

        // TODO: Vérifier le sessionToken et mapper vers les actions
        Console.WriteLine($"Axis event: {eventAxis.ControlId} - {eventAxis.Value}");
    }

    private void HandleRunMacro(IWebSocketConnection socket, string message)
    {
        // TODO: Implémenter l'exécution de macro
        Console.WriteLine("Run macro (not implemented yet)");
    }

    private void HandleSwitchPage(IWebSocketConnection socket, string message)
    {
        var switchPage = JsonConvert.DeserializeObject<SwitchPageMessage>(message);
        if (switchPage == null) return;

        // TODO: Mettre à jour l'état de la session
        Console.WriteLine($"Switch page: {switchPage.PageId}");
    }

    private void SendError(IWebSocketConnection socket, string code, string message)
    {
        var error = new
        {
            type = "ERROR",
            code = code,
            message = message
        };
        socket.Send(JsonConvert.SerializeObject(error));
    }

    private void GeneratePairingCode()
    {
        var random = new Random();
        _currentPairingCode = random.Next(100000, 999999).ToString();
    }

    private class SessionState
    {
        public Dictionary<string, bool> Toggles { get; set; } = new();
        public Dictionary<string, double> Axes { get; set; } = new();
        public string? ActivePage { get; set; }
    }
}
