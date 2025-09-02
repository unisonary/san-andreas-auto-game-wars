namespace GooglePlayGames.BasicApi.Video
{
	public class VideoCaptureState
	{
		private bool mIsCapturing;

		private VideoCaptureMode mCaptureMode;

		private VideoQualityLevel mQualityLevel;

		private bool mIsOverlayVisible;

		private bool mIsPaused;

		public bool IsCapturing
		{
			get
			{
				return mIsCapturing;
			}
		}

		public VideoCaptureMode CaptureMode
		{
			get
			{
				return mCaptureMode;
			}
		}

		public VideoQualityLevel QualityLevel
		{
			get
			{
				return mQualityLevel;
			}
		}

		public bool IsOverlayVisible
		{
			get
			{
				return mIsOverlayVisible;
			}
		}

		public bool IsPaused
		{
			get
			{
				return mIsPaused;
			}
		}

		internal VideoCaptureState(bool isCapturing, VideoCaptureMode captureMode, VideoQualityLevel qualityLevel, bool isOverlayVisible, bool isPaused)
		{
			mIsCapturing = isCapturing;
			mCaptureMode = captureMode;
			mQualityLevel = qualityLevel;
			mIsOverlayVisible = isOverlayVisible;
			mIsPaused = isPaused;
		}

		public override string ToString()
		{
			return string.Format("[VideoCaptureState: mIsCapturing={0}, mCaptureMode={1}, mQualityLevel={2}, mIsOverlayVisible={3}, mIsPaused={4}]", mIsCapturing, mCaptureMode.ToString(), mQualityLevel.ToString(), mIsOverlayVisible, mIsPaused);
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
