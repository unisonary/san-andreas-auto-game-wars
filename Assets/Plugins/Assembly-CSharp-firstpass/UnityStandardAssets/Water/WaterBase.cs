using UnityEngine;

namespace UnityStandardAssets.Water
{
	[ExecuteInEditMode]
	public class WaterBase : MonoBehaviour
	{
		public Material sharedMaterial;

		public WaterQuality waterQuality = WaterQuality.High;

		public bool edgeBlend = true;

		private void Start()
		{
		}

		private void disablewater()
		{
			GetComponent<WaterBase>().enabled = false;
		}

		public void UpdateShader()
		{
			if (waterQuality > WaterQuality.Medium)
			{
				sharedMaterial.shader.maximumLOD = 501;
			}
			else if (waterQuality > WaterQuality.Low)
			{
				sharedMaterial.shader.maximumLOD = 301;
			}
			else
			{
				sharedMaterial.shader.maximumLOD = 201;
			}
			if (!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
			{
				edgeBlend = false;
			}
			if (edgeBlend)
			{
				Shader.EnableKeyword("WATER_EDGEBLEND_ON");
				Shader.DisableKeyword("WATER_EDGEBLEND_OFF");
				if ((bool)Camera.main)
				{
					Camera.main.depthTextureMode |= DepthTextureMode.Depth;
				}
			}
			else
			{
				Shader.EnableKeyword("WATER_EDGEBLEND_OFF");
				Shader.DisableKeyword("WATER_EDGEBLEND_ON");
			}
		}

		public void WaterTileBeingRendered(Transform tr, Camera currentCam)
		{
			if ((bool)currentCam && edgeBlend)
			{
				currentCam.depthTextureMode |= DepthTextureMode.Depth;
			}
		}

		public void Update()
		{
			if ((bool)sharedMaterial)
			{
				UpdateShader();
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
