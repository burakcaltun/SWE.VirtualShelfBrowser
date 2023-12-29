using Volo.Abp.Settings;

namespace SWE.VirtualShelfBrowser.Settings;

public class VirtualShelfBrowserSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(VirtualShelfBrowserSettings.MySetting1));
    }
}
