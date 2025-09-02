public class IronSourceError
{
	private string description;

	private int code;

	public int getErrorCode()
	{
		return code;
	}

	public string getDescription()
	{
		return description;
	}

	public int getCode()
	{
		return code;
	}

	public IronSourceError(int errorCode, string errorDescription)
	{
		code = errorCode;
		description = errorDescription;
	}

	public override string ToString()
	{
		return code + " : " + description;
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
