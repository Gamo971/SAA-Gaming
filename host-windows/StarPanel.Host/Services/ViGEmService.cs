using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace StarPanel.Host.Services;

public class ViGEmService : IAsyncDisposable
{
    private ViGEmClient? _client;
    private IXbox360Controller? _controller;
    private bool _isInitialized;

    public static bool IsAvailable()
    {
        try
        {
            using var client = new ViGEmClient();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task InitializeAsync()
    {
        if (_isInitialized)
            return;

        _client = new ViGEmClient();
        _controller = _client.CreateXbox360Controller();
        _controller.Connect();

        _isInitialized = true;
        Console.WriteLine("ViGEm controller initialized.");
    }

    public void SetButton(int buttonIndex, bool pressed)
    {
        if (!_isInitialized || _controller == null)
            return;

        var button = (Xbox360Button)buttonIndex;
        if (pressed)
            _controller.SetButtonState(button, true);
        else
            _controller.SetButtonState(button, false);
    }

    public void SetAxis(string axisName, double value)
    {
        if (!_isInitialized || _controller == null)
            return;

        // Clamp value between -1.0 and 1.0
        value = Math.Clamp(value, -1.0, 1.0);

        switch (axisName.ToLower())
        {
            case "left_stick_x":
                _controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)(value * short.MaxValue));
                break;
            case "left_stick_y":
                _controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)(value * short.MaxValue));
                break;
            case "right_stick_x":
                _controller.SetAxisValue(Xbox360Axis.RightThumbX, (short)(value * short.MaxValue));
                break;
            case "right_stick_y":
                _controller.SetAxisValue(Xbox360Axis.RightThumbY, (short)(value * short.MaxValue));
                break;
            case "left_trigger":
                _controller.SetSliderValue(Xbox360Slider.LeftTrigger, (byte)((value + 1.0) / 2.0 * byte.MaxValue));
                break;
            case "right_trigger":
                _controller.SetSliderValue(Xbox360Slider.RightTrigger, (byte)((value + 1.0) / 2.0 * byte.MaxValue));
                break;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_controller != null)
        {
            _controller.Disconnect();
            _controller.Dispose();
        }

        _client?.Dispose();
        _isInitialized = false;
    }
}
