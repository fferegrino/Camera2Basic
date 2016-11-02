using System;
namespace Camera2Basic.Util
{
	public enum CameraState
	{
		/// <summary>
		/// Showing camera preview
		/// </summary>
		Preview = 0,
		/// <summary>
		/// Waiting for the focus to be locked
		/// </summary>
		WaitingLock = 1,
		/// <summary>
		/// Waiting for the exposure to be precapture state
		/// </summary>
		WaitingPrecapture = 2,
		/// <summary>
		/// Waiting for the exposure state to be something other than precapture
		/// </summary>
		WaitingNonPrecapture = 3,
		/// <summary>
		/// Picture was taken
		/// </summary>
		PictureTaken = 4

	}
}
