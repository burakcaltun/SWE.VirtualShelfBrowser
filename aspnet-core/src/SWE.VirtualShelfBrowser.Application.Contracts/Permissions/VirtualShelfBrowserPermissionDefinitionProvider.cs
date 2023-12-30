using SWE.VirtualShelfBrowser.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SWE.VirtualShelfBrowser.Permissions;

public class VirtualShelfBrowserPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var virtualShelfBrowser = context.AddGroup(VirtualShelfBrowserPermissions.GroupName, L("Permission:VirtualShelfBrowser"));

        var booksPermission = virtualShelfBrowser.AddPermission(VirtualShelfBrowserPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(VirtualShelfBrowserPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(VirtualShelfBrowserPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(VirtualShelfBrowserPermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = virtualShelfBrowser.AddPermission(
        VirtualShelfBrowserPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(
        VirtualShelfBrowserPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(
        VirtualShelfBrowserPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(
        VirtualShelfBrowserPermissions.Authors.Delete, L("Permission:Authors.Delete"));


        var lendingPermission = virtualShelfBrowser.AddPermission(VirtualShelfBrowserPermissions.Lendings.Default, L("Permission:Lendings"));
        lendingPermission.AddChild(VirtualShelfBrowserPermissions.Lendings.Create, L("Permission:Lendings.Create"));
        lendingPermission.AddChild(VirtualShelfBrowserPermissions.Lendings.Edit, L("Permission:Lendings.Edit"));
        lendingPermission.AddChild(VirtualShelfBrowserPermissions.Lendings.Delete, L("Permission:Lendings.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VirtualShelfBrowserResource>(name);
    }
}
