using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Hardware.Camera2;

namespace Camera2Basic.Listeners
{
    public class CameraCaptureSessionStateCallback : CameraCaptureSession.StateCallback
    {
        public Camera2BasicFragment Parent { get; private set; }

        public CameraCaptureSessionStateCallback(Camera2BasicFragment parent)
        {
            Parent = parent;
        }

        public override void OnConfigured(CameraCaptureSession session)
        {
            // The camera is already closed
            if (null == Parent.CameraDevice)
            {
                return;
            }

            // When the session is ready, we start displaying the preview.
           Parent.CaptureSession = session;
            try
            {
                // Auto focus should be continuous for camera preview.
                Parent.PreviewRequestBuilder.Set(CaptureRequest.ControlAfMode,(int)
                     ControlAFMode.ContinuousPicture);
                // Flash is automatically enabled when necessary.
                Parent.SetAutoFlash(Parent.PreviewRequestBuilder);

                // Finally, we start displaying the camera preview.
                Parent.mPreviewRequest = Parent.PreviewRequestBuilder.Build();
                Parent.CaptureSession.SetRepeatingRequest(Parent.mPreviewRequest,
                        Parent.CaptureCallback, Parent.BackgroundHandler);
            }
            catch (CameraAccessException e)
            {
                Parent.ShowToast("Failed");
            }
        }

        public override void OnConfigureFailed(CameraCaptureSession session)
        {
            throw new NotImplementedException();
        }
    }
}