public class IronSourceBannerSize
{
	private int width;

	private int height;

	private string description;

	public static IronSourceBannerSize BANNER = new IronSourceBannerSize("BANNER");

	public static IronSourceBannerSize LARGE = new IronSourceBannerSize("LARGE");

	public static IronSourceBannerSize RECTANGLE = new IronSourceBannerSize("RECTANGLE");

	public static IronSourceBannerSize SMART = new IronSourceBannerSize("SMART");

	public string Description
	{
		get
		{
			return description;
		}
	}

	public int Width
	{
		get
		{
			return width;
		}
	}

	public int Height
	{
		get
		{
			return height;
		}
	}

	private IronSourceBannerSize()
	{
	}

	public IronSourceBannerSize(int width, int height)
	{
		this.width = width;
		this.height = height;
		description = "CUSTOM";
	}

	public IronSourceBannerSize(string description)
	{
		this.description = description;
		width = 0;
		height = 0;
	}
}


//This source code is originally bought from www.codebuysell.com
// Visit www.codebuysell.com
//
//Contact us at:
//
//Email : admin@codebuysell.com
//Whatsapp: +15055090428
//Telegram: t.me/CodeBuySellLLC
//Facebook: https://www.facebook.com/CodeBuySellLLC/
//Skype: https://join.skype.com/invite/wKcWMjVYDNvk
//Twitter: https://x.com/CodeBuySellLLC
//Instagram: https://www.instagram.com/codebuysell/
//Youtube: http://www.youtube.com/@CodeBuySell
//LinkedIn: www.linkedin.com/in/CodeBuySellLLC
//Pinterest: https://www.pinterest.com/CodeBuySell/
