using System;
using Android.Graphics;
using Android.Views;

namespace Camera2Basic
{
	public class TextureViewSurfaceTextureListener : Java.Lang.Object, TextureView.ISurfaceTextureListener
	{
		public Camera2BasicFragment Parent { get; private set; }

		public TextureViewSurfaceTextureListener(Camera2BasicFragment parent)
		{
			Parent = parent;
		}

		public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
		{
			Parent.OpenCamera(width, height);
		}

		public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
		{
			return true;
		}

		public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
		{
			Parent.ConfigureTransform(width, height);
		}

		public void OnSurfaceTextureUpdated(SurfaceTexture surface)
		{
		}
	}
}
