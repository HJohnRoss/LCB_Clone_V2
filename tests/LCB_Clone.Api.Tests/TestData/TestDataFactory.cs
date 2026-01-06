using LCB_Clone.Api.Tests.TestData.Legislators;
using LCB_Clone.Api.Tests.TestData.Legislators.Interfaces;
using LCB_Clone.Api.Tests.TestData.LegislatorStrings;
using LCB_Clone.Api.Tests.TestData.LegislatorStrings.Interfaces;
using LCB_Clone.Api.Tests.TestData.Socials;
using LCB_Clone.Api.Tests.TestData.Socials.Interfaces;

namespace LCB_Clone.Api.Tests.TestData;

public sealed class TestDataFactory
{
	public ILegislatorTestData Legislators { get; }
	public ISocialTestData Socials { get; }
	public ILegislatorStringsTestData LegislatorStrings { get; }

	public TestDataFactory(HttpClient client)
	{
		Legislators = new LegislatorTestData(client);
		Socials = new SocialTestData(client, Legislators);
		LegislatorStrings = new LegislatorStringsTestData(client, Legislators);
	}
}
