using System;
using Android.Hardware.Camera2;
using Java.Lang;
using Android.Util;

namespace Camera2Basic
{
    public class CameraCaptureSessionCaptureCallback2 : CameraCaptureSession.CaptureCallback
    {
        public Camera2BasicFragment Parent { get; private set; }

        public CameraCaptureSessionCaptureCallback2(Camera2BasicFragment parent)
        {
            Parent = parent;
        }


        public override void OnCaptureCompleted(CameraCaptureSession session, CaptureRequest request, TotalCaptureResult result)
        {
            Parent.ShowToast("Saved: " + Parent.mFile);
            Log.Debug(Camera2BasicFragment.Tag, Parent.mFile.ToString());
            Parent.UnlockFocus();
        }
    }
}