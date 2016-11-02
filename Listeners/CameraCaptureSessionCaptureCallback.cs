using System;
using Android.Hardware.Camera2;
using Java.Lang;
using Camera2Basic.Util;

namespace Camera2Basic
{
	public class CameraCaptureSessionCaptureCallback : CameraCaptureSession.CaptureCallback
	{

		public Camera2BasicFragment Parent { get; private set; }

		public CameraCaptureSessionCaptureCallback(Camera2BasicFragment parent)
		{
			Parent = parent;
		}

		public override void OnCaptureProgressed(CameraCaptureSession session, CaptureRequest request, CaptureResult partialResult)
		{
            Process(partialResult);
		}

		public override void OnCaptureCompleted(CameraCaptureSession session, CaptureRequest request, TotalCaptureResult result)
        {
            Process(result);
        }

		public void Process(CaptureResult result)
		{
			switch (Parent.mState)
			{
				case CameraState.Preview:
					break;
				case CameraState.WaitingLock:
                    // https://github.com/googlesamples/android-Camera2Basic/blob/master/Application/src/main/java/com/example/android/camera2basic/Camera2BasicFragment.java#L295
                    var afState = ((Integer) result.Get(CaptureResult.ControlAfState))?.IntValue();
                    if (afState == null)
                    {
                        Parent.CaptureStillPicture();
                    }
                    else if ((int)ControlAFState.FocusedLocked == afState ||
                          (int)ControlAFState.FocusedLocked == afState)
                    {
                        // CaptureResult.ControlAeState can be null on some devices
                        var aeState1 = ((Integer)result.Get(CaptureResult.ControlAeState))?.IntValue();
                        if (aeState1 == null ||
                                aeState1 == (int)ControlAEState.Converged)
                        {
                            Parent.mState = CameraState.PictureTaken;
                            Parent.CaptureStillPicture();
                        }
                        else
                        {
                            Parent.CaptureStillPicture();
                        }
                    }
                    break;
                case CameraState.WaitingPrecapture:
                    // CaptureResult.ControlAeState can be null on some devices
                    var aeState2 = ((Integer)result.Get(CaptureResult.ControlAeState))?.IntValue();
                    if (aeState2 == null ||
                            aeState2 == (int)ControlAEState.Precapture||
                            aeState2 == (int)ControlAEState.FlashRequired)
                    {
                        Parent.mState = CameraState.WaitingNonPrecapture;
                    }
                    break;
                case CameraState.WaitingNonPrecapture:
                    // CaptureResult.ControlAeState can be null on some devices
                    var aeState3 = ((Integer)result.Get(CaptureResult.ControlAeState))?.IntValue();
                    if (aeState3 == null || aeState3 == (int)ControlAEState.Precapture)
                    {
                        Parent.mState = CameraState.PictureTaken;
                        Parent.CaptureStillPicture();
                    }
                    break;
				default:
					break;
			}
		}
	}
}
