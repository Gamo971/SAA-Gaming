using StarPanel.Host.Services;
using StarPanel.Host.WebSocket;

namespace StarPanel.Host;

class Program
{
    private const int WebSocketPort = 8765;
    private const string WebSocketPath = "/starpanel";

    static async Task Main(string[] args)
    {
        Console.WriteLine("StarPanel Host - Starting...");

        // Vérifier ViGEmBus
        if (!ViGEmService.IsAvailable())
        {
            Console.WriteLine("ERROR: ViGEmBus is not installed or not available.");
            Console.WriteLine("Please install ViGEmBus from: https://github.com/ViGEm/ViGEmBus/releases");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("ViGEmBus detected.");

        // Initialiser le service ViGEm
        var vigemService = new ViGEmService();
        await vigemService.InitializeAsync();

        // Initialiser le serveur WebSocket
        var webSocketServer = new StarPanelWebSocketServer(WebSocketPort, WebSocketPath, vigemService);
        await webSocketServer.StartAsync();

        Console.WriteLine($"WebSocket server started on ws://0.0.0.0:{WebSocketPort}{WebSocketPath}");
        Console.WriteLine("Press 'q' to quit...");

        // Attendre la commande de sortie
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == 'q' || key.KeyChar == 'Q')
            {
                break;
            }
        }

        // Nettoyage
        await webSocketServer.StopAsync();
        await vigemService.DisposeAsync();

        Console.WriteLine("StarPanel Host - Stopped.");
    }
}
