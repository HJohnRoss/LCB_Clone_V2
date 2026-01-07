using LCB_Clone.Api.Infrastructure.Persistence.Entities;
using LCB_Clone.Shared.Dtos.Legislators;
using LCB_Clone.Api.Mappings.Socials;
using LCB_Clone.Api.Mappings.LegislatorStrings;
using LCB_Clone.Shared.Dtos.LegislatorStrings;
using LCB_Clone.Shared.Enums.Legislators;

namespace LCB_Clone.Api.Mappings.Legislators;

public static class ResponseDtoMappings
{
	public static LegislatorResponseDto ToResponse(this Legislator legislator)
	{
		if (legislator == null)
			return null!;

		return new LegislatorResponseDto
		{
			Id = legislator.Id,
			FirstName = legislator.FirstName,
			MiddleName = legislator.MiddleName,
			LastName = legislator.LastName,
			Party = legislator.Party,
			County = legislator.County,
			Email = legislator.Email,
			LVOffice = legislator.LVOffice,
			CCOffice = legislator.CCOffice,
			CCPhone = legislator.CCPhone,
			TermEndYear = legislator.TermEndYear,
			Socials = [.. legislator.Socials.Select(s => s.ToResponse())],
			Affiliations = [.. legislator.Affiliations.Select(a => a.ToResponse())],
			Education = [.. legislator.Education.Select(e => e.ToResponse())],
			HonorsRewards = [.. legislator.HonorsRewards.Select(h => h.ToResponse())],
			LegService = [.. legislator.LegService.Select(l => l.ToResponse())],
			MilitaryService = [.. legislator.MilitaryService.Select(m => m.ToResponse())],
			OtherAchivements = [.. legislator.OtherAchivements.Select(o => o.ToResponse())],
			OtherPublicService = [.. legislator.OtherPublicService.Select(o => o.ToResponse())],
			Personal = [.. legislator.Personal.Select(p => p.ToResponse())],
			Proffesional = [.. legislator.Proffesional.Select(p => p.ToResponse())]
		};
	}

	public static LegislatorResponseDto RawDtoToResponseDto(this LegislatorRawDto raw)
	{
		if (raw == null)
			return null!;

		var groups = raw.LegislatorStrings
			.GroupBy(x => x.Type)
			.ToDictionary(g => g.Key, g => g.ToList());

		List<LegislatorStringsResponseDto> Get(LegislatorStringType t) =>
			groups.TryGetValue(t, out var list) ? list : [];

		return new LegislatorResponseDto
		{
			Id = raw.Id,
			FirstName = raw.FirstName,
			MiddleName = raw.MiddleName,
			LastName = raw.LastName,
			Party = raw.Party,
			County = raw.County,
			Email = raw.Email,
			LVOffice = raw.LVOffice,
			CCOffice = raw.CCOffice,
			CCPhone = raw.CCPhone,
			TermEndYear = raw.TermEndYear,
			Socials = raw.Socials,

			Affiliations = Get(LegislatorStringType.Affiliations),
			Education = Get(LegislatorStringType.Education),
			HonorsRewards = Get(LegislatorStringType.HonorsRewards),
			LegService = Get(LegislatorStringType.LegService),
			MilitaryService = Get(LegislatorStringType.MilitaryService),
			OtherAchivements = Get(LegislatorStringType.OtherAchivements),
			OtherPublicService = Get(LegislatorStringType.OtherPublicService),
			Personal = Get(LegislatorStringType.Personal),
			Proffesional = Get(LegislatorStringType.Proffesional),
		};
	}
}
