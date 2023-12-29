namespace SWE.VirtualShelfBrowser.Permissions;

public static class VirtualShelfBrowserPermissions
{
    public const string GroupName = "VirtualShelfBrowser";

    // *** ADDED a NEW NESTED CLASS ***
    public static class Authors
    {
        public const string Default = GroupName + ".Authors";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
