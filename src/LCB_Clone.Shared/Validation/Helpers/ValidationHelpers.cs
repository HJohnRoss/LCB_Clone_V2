using System.Net.Mail;

namespace LCB_Clone.Shared.Validation.Helpers;

public static class ValidationHelpers
{
	public static void RequireNonEmpty(
			string? value,
			string fieldName,
			List<string> errors)
	{
		if (string.IsNullOrEmpty(value))
			errors.Add($"{fieldName} is required");
	}

	public static bool IsValidEmail(string email)
	{
		try
		{
			_ = new MailAddress(email);
			return true;
		}
		catch
		{
			return false;
		}
	}
}
