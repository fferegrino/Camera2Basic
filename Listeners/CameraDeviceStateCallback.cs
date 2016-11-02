using System;
using Android.Hardware.Camera2;
using Android.Runtime;

namespace Camera2Basic
{
	public class CameraDeviceStateCallback : CameraDevice.StateCallback
	{
		public Camera2BasicFragment Parent { get; private set; }

		public CameraDeviceStateCallback(Camera2BasicFragment parent)
		{
			Parent = parent;
		}

		public override void OnDisconnected(CameraDevice camera)
		{
			Parent.mCameraOpenCloseLock.Release();
			Parent.CameraDevice.Close();
			Parent.CameraDevice = null;
		}

		public override void OnError(CameraDevice camera, [GeneratedEnum] CameraError error)
		{
			Parent.mCameraOpenCloseLock.Release();
			Parent.CameraDevice.Close();
			Parent.CameraDevice = null;
			if (Parent == null)
				return;
			var activity = Parent.Activity;
			if (activity != null)
				activity.Finish();
		}

		public override void OnOpened(CameraDevice camera)
		{
			Parent.mCameraOpenCloseLock.Release();
			Parent.CameraDevice = camera;
			Parent.CreateCameraPreviewSession();
		}
	}
}