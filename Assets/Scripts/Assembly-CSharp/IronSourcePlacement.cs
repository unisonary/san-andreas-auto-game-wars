public class IronSourcePlacement
{
	private string rewardName;

	private int rewardAmount;

	private string placementName;

	public IronSourcePlacement(string placementName, string rewardName, int rewardAmount)
	{
		this.placementName = placementName;
		this.rewardName = rewardName;
		this.rewardAmount = rewardAmount;
	}

	public string getRewardName()
	{
		return rewardName;
	}

	public int getRewardAmount()
	{
		return rewardAmount;
	}

	public string getPlacementName()
	{
		return placementName;
	}

	public override string ToString()
	{
		return placementName + " : " + rewardName + " : " + rewardAmount;
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
