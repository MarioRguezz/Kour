using System;
using System.Text.RegularExpressions;

using Xamarin.Forms;

namespace Kour
{
public class Validators
{
	static Regex ValidEmailRegex = CreateValidEmailRegex();

	private static Regex CreateValidEmailRegex()
	{
		string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
			+ @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
			+ @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

		return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
	}

	internal static bool EmailIsValid(string emailAddress)
	{
		bool isValid = ValidEmailRegex.IsMatch(emailAddress);

		return isValid;
	}

	internal static bool JustLetters(string input)
	{
		return Regex.IsMatch(input, @"^[a-zA-Z]+$");
	}

	internal static bool JustNumbers(string input)
	{
		return Regex.IsMatch(input, @"^[0-9]+$");
	}

	internal static bool JustNumbersAndLetters(string text)
	{
		return Regex.IsMatch(text, @"^[a-zA-Z0-9]+$");
	}

	internal static bool Curp(string curp)
	{
		return Regex.IsMatch(curp, @"^.* (?=.{ 18})(?=.*[0 - 9])(?=.*[A - ZÑ]).*");
	}

	public static bool CurpIsValid(string text)
	{
		var isValid = false;

		if (JustNumbersAndLetters(text))
		{
			if (text.Length == 18)
			{
				isValid = true;
			}
		}

		return isValid;
	}

	public static bool NumbersLetters(string text)
	{
		return Regex.IsMatch(text.Trim(), "^[a-zA-Z0-9]+$");
	}

	public static bool Placas(string text)
	{
		return Regex.IsMatch(text.Trim(), "^([a-zA-Z]{3,4}-\\d{3,4})$");
	}
}
}
