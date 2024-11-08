using COLORS.UI.Interfaces;
namespace COLORS;

public class App(IUI _ui)
{
    public void Run()
    {
        _ui.Start();
    }
}
