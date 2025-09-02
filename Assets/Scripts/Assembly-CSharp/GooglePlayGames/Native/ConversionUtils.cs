using System;
using GooglePlayGames.BasicApi;
using GooglePlayGames.Native.Cwrapper;
using UnityEngine;
using Types = GooglePlayGames.Native.Cwrapper.Types;

namespace GooglePlayGames.Native
{
	internal static class ConversionUtils
	{
		internal static ResponseStatus ConvertResponseStatus(CommonErrorStatus.ResponseStatus status)
		{
			switch (status)
			{
			case CommonErrorStatus.ResponseStatus.VALID:
				return ResponseStatus.Success;
			case CommonErrorStatus.ResponseStatus.VALID_BUT_STALE:
				return ResponseStatus.SuccessWithStale;
			case CommonErrorStatus.ResponseStatus.ERROR_INTERNAL:
				return ResponseStatus.InternalError;
			case CommonErrorStatus.ResponseStatus.ERROR_LICENSE_CHECK_FAILED:
				return ResponseStatus.LicenseCheckFailed;
			case CommonErrorStatus.ResponseStatus.ERROR_NOT_AUTHORIZED:
				return ResponseStatus.NotAuthorized;
			case CommonErrorStatus.ResponseStatus.ERROR_TIMEOUT:
				return ResponseStatus.Timeout;
			case CommonErrorStatus.ResponseStatus.ERROR_VERSION_UPDATE_REQUIRED:
				return ResponseStatus.VersionUpdateRequired;
			default:
				throw new InvalidOperationException("Unknown status: " + status);
			}
		}

		internal static CommonStatusCodes ConvertResponseStatusToCommonStatus(CommonErrorStatus.ResponseStatus status)
		{
			switch (status)
			{
			case CommonErrorStatus.ResponseStatus.VALID:
				return CommonStatusCodes.Success;
			case CommonErrorStatus.ResponseStatus.VALID_BUT_STALE:
				return CommonStatusCodes.SuccessCached;
			case CommonErrorStatus.ResponseStatus.ERROR_INTERNAL:
				return CommonStatusCodes.InternalError;
			case CommonErrorStatus.ResponseStatus.ERROR_LICENSE_CHECK_FAILED:
				return CommonStatusCodes.LicenseCheckFailed;
			case CommonErrorStatus.ResponseStatus.ERROR_NOT_AUTHORIZED:
				return CommonStatusCodes.AuthApiAccessForbidden;
			case CommonErrorStatus.ResponseStatus.ERROR_TIMEOUT:
				return CommonStatusCodes.Timeout;
			case CommonErrorStatus.ResponseStatus.ERROR_VERSION_UPDATE_REQUIRED:
				return CommonStatusCodes.ServiceVersionUpdateRequired;
			default:
				Debug.LogWarning(string.Concat("Unknown ResponseStatus: ", status, ", defaulting to CommonStatusCodes.Error"));
				return CommonStatusCodes.Error;
			}
		}

		internal static UIStatus ConvertUIStatus(CommonErrorStatus.UIStatus status)
		{
			switch (status)
			{
			case CommonErrorStatus.UIStatus.VALID:
				return UIStatus.Valid;
			case CommonErrorStatus.UIStatus.ERROR_INTERNAL:
				return UIStatus.InternalError;
			case CommonErrorStatus.UIStatus.ERROR_NOT_AUTHORIZED:
				return UIStatus.NotAuthorized;
			case CommonErrorStatus.UIStatus.ERROR_TIMEOUT:
				return UIStatus.Timeout;
			case CommonErrorStatus.UIStatus.ERROR_VERSION_UPDATE_REQUIRED:
				return UIStatus.VersionUpdateRequired;
			case CommonErrorStatus.UIStatus.ERROR_CANCELED:
				return UIStatus.UserClosedUI;
			case CommonErrorStatus.UIStatus.ERROR_UI_BUSY:
				return UIStatus.UiBusy;
			default:
				throw new InvalidOperationException("Unknown status: " + status);
			}
		}

		internal static Types.DataSource AsDataSource(DataSource source)
		{
			switch (source)
			{
			case DataSource.ReadCacheOrNetwork:
				return Types.DataSource.CACHE_OR_NETWORK;
			case DataSource.ReadNetworkOnly:
				return Types.DataSource.NETWORK_ONLY;
			default:
				throw new InvalidOperationException("Found unhandled DataSource: " + source);
			}
		}

		internal static Types.VideoCaptureMode ConvertVideoCaptureMode(VideoCaptureMode captureMode)
		{
			switch (captureMode)
			{
			case VideoCaptureMode.File:
				return Types.VideoCaptureMode.FILE;
			case VideoCaptureMode.Stream:
				return Types.VideoCaptureMode.STREAM;
			case VideoCaptureMode.Unknown:
				return Types.VideoCaptureMode.UNKNOWN;
			default:
				Debug.LogWarning(string.Concat("Unknown VideoCaptureMode: ", captureMode, ", defaulting to Types.VideoCaptureMode.UNKNOWN."));
				return Types.VideoCaptureMode.UNKNOWN;
			}
		}

		internal static VideoCaptureMode ConvertNativeVideoCaptureMode(Types.VideoCaptureMode nativeCaptureMode)
		{
			switch (nativeCaptureMode)
			{
			case Types.VideoCaptureMode.FILE:
				return VideoCaptureMode.File;
			case Types.VideoCaptureMode.STREAM:
				return VideoCaptureMode.Stream;
			case Types.VideoCaptureMode.UNKNOWN:
				return VideoCaptureMode.Unknown;
			default:
				Debug.LogWarning(string.Concat("Unknown Types.VideoCaptureMode: ", nativeCaptureMode, ", defaulting to VideoCaptureMode.Unknown."));
				return VideoCaptureMode.Unknown;
			}
		}

		internal static VideoQualityLevel ConvertNativeVideoQualityLevel(Types.VideoQualityLevel nativeQualityLevel)
		{
			switch (nativeQualityLevel)
			{
			case Types.VideoQualityLevel.SD:
				return VideoQualityLevel.SD;
			case Types.VideoQualityLevel.HD:
				return VideoQualityLevel.HD;
			case Types.VideoQualityLevel.XHD:
				return VideoQualityLevel.XHD;
			case Types.VideoQualityLevel.FULLHD:
				return VideoQualityLevel.FullHD;
			case Types.VideoQualityLevel.UNKNOWN:
				return VideoQualityLevel.Unknown;
			default:
				Debug.LogWarning(string.Concat("Unknown Types.VideoQualityLevel: ", nativeQualityLevel, ", defaulting to VideoQualityLevel.Unknown."));
				return VideoQualityLevel.Unknown;
			}
		}

		internal static VideoCaptureOverlayState ConvertNativeVideoCaptureOverlayState(Types.VideoCaptureOverlayState nativeOverlayState)
		{
			switch (nativeOverlayState)
			{
			case Types.VideoCaptureOverlayState.DISMISSED:
				return VideoCaptureOverlayState.Dismissed;
			case Types.VideoCaptureOverlayState.SHOWN:
				return VideoCaptureOverlayState.Shown;
			case Types.VideoCaptureOverlayState.STARTED:
				return VideoCaptureOverlayState.Started;
			case Types.VideoCaptureOverlayState.STOPPED:
				return VideoCaptureOverlayState.Stopped;
			case Types.VideoCaptureOverlayState.UNKNOWN:
				return VideoCaptureOverlayState.Unknown;
			default:
				Debug.LogWarning(string.Concat("Unknown Types.VideoCaptureOverlayState: ", nativeOverlayState, ", defaulting to VideoCaptureOverlayState.Unknown."));
				return VideoCaptureOverlayState.Unknown;
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
