using UnityEngine;

namespace UnityStandardAssets.Water
{
	[RequireComponent(typeof(WaterBase))]
	[ExecuteInEditMode]
	public class SpecularLighting : MonoBehaviour
	{
		public Transform specularLight;

		private WaterBase m_WaterBase;

		public void Start()
		{
			m_WaterBase = (WaterBase)base.gameObject.GetComponent(typeof(WaterBase));
		}

		public void Update()
		{
			if (!m_WaterBase)
			{
				m_WaterBase = (WaterBase)base.gameObject.GetComponent(typeof(WaterBase));
			}
			if ((bool)specularLight && (bool)m_WaterBase.sharedMaterial)
			{
				m_WaterBase.sharedMaterial.SetVector("_WorldLightDir", specularLight.transform.forward);
			}
		}
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
