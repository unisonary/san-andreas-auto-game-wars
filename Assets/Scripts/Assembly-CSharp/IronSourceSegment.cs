using System.Collections.Generic;
using System.Linq;

public class IronSourceSegment
{
	public int age;

	public string gender;

	public int level;

	public int isPaying;

	public long userCreationDate;

	public double iapt;

	public string segmentName;

	public Dictionary<string, string> customs;

	public IronSourceSegment()
	{
		customs = new Dictionary<string, string>();
		age = -1;
		level = -1;
		isPaying = -1;
		userCreationDate = -1L;
		iapt = 0.0;
	}

	public void setCustom(string key, string value)
	{
		customs.Add(key, value);
	}

	public Dictionary<string, string> getSegmentAsDict()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (age != -1)
		{
			dictionary.Add("age", string.Concat(age));
		}
		if (!string.IsNullOrEmpty(gender))
		{
			dictionary.Add("gender", gender);
		}
		if (level != -1)
		{
			dictionary.Add("level", string.Concat(level));
		}
		if (isPaying > -1 && isPaying < 2)
		{
			dictionary.Add("isPaying", string.Concat(isPaying));
		}
		if (userCreationDate != -1)
		{
			dictionary.Add("userCreationDate", string.Concat(userCreationDate));
		}
		if (!string.IsNullOrEmpty(segmentName))
		{
			dictionary.Add("segmentName", segmentName);
		}
		if (iapt > 0.0)
		{
			dictionary.Add("iapt", string.Concat(iapt));
		}
		return Enumerable.ToDictionary(Enumerable.GroupBy(Enumerable.Concat(dictionary, customs), (KeyValuePair<string, string> d) => d.Key), (IGrouping<string, KeyValuePair<string, string>> d) => d.Key, (IGrouping<string, KeyValuePair<string, string>> d) => Enumerable.First(d).Value);
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
