using SWE.VirtualShelfBrowser.Samples;
using Xunit;

namespace SWE.VirtualShelfBrowser.EntityFrameworkCore.Domains;

[Collection(VirtualShelfBrowserTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<VirtualShelfBrowserEntityFrameworkCoreTestModule>
{

}
