using System;

using Xamarin.Forms;

namespace Kour
{
	public class ViewUtils
{
	public static void PressedEfect(Image image)
	{
		image.Opacity = 0.5;
		image.FadeTo(1);
	}

	public static void TextGeneralLimit(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		int _limit = 30;

		string _text = entry.Text;
		if (_text.Length > _limit)
		{
			_text = _text.Remove(_text.Length - 1);
			entry.Text = _text;
		}
	}

	public static void PhoneTextLimit(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		int _limit = 10;

		string _text = entry.Text;
		if (_text.Length > _limit)
		{
			_text = _text.Remove(_text.Length - 1);
			entry.Text = _text;
		}
	}

	public static void PromotionCodeTextLimit(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		int _limit = 3;

		string _text = entry.Text;
		if (_text.Length > _limit)
		{
			_text = _text.Remove(_text.Length - 1);
			entry.Text = _text;
		}
	}

	public static void PostalCodeTextLimit(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		int _limit = 5;

		string _text = entry.Text;
		if (_text.Length > _limit)
		{
			_text = _text.Remove(_text.Length - 1);
			entry.Text = _text;
		}
	}

	public static void YearTextLimit(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		int _limit = 4;

		string _text = entry.Text;
		if (_text.Length > _limit)
		{
			_text = _text.Remove(_text.Length - 1);
			entry.Text = _text;
		}
	}

	public static void CurpTextLimit(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		int _limit = 18;

		string _text = entry.Text;
		if (_text.Length > _limit)
		{
			_text = _text.Remove(_text.Length - 1);
			entry.Text = _text;
		}
	}
}
}
