using SuperAutoMachines.Configuration;
using SuperAutoMachines.Gui.Console.Battle;

namespace SuperAutoMachines.Gui.Factories
{
    public static class BattleGuiFactory
    {
        public static IBattleGui CreateGui()
        {
            var systemSetting = ConfigService.Configuration.GetSection("GuiSettings")
                    .GetChildren()
                    .First();

            return systemSetting.Value switch
            {
                "Console" => new BattleGuiConsole(),
                _ => throw new NotSupportedException($"System setting {systemSetting}"),
            };
        }
    }
}