using SWE.VirtualShelfBrowser.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SWE.VirtualShelfBrowser.Permissions;

public class VirtualShelfBrowserPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VirtualShelfBrowserPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(VirtualShelfBrowserPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VirtualShelfBrowserResource>(name);
    }
}
