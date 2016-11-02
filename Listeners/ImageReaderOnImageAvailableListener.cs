using System;
using Android.Media;
using Java.IO;
using Java.Lang;

namespace Camera2Basic
{
    public class ImageReaderOnImageAvailableListener : Java.Lang.Object, ImageReader.IOnImageAvailableListener
    {
        public File File { get; set; }
        public Camera2BasicFragment Parent { get; private set; }

        public ImageReaderOnImageAvailableListener(Camera2BasicFragment parent)
        {
            Parent = parent;
        }

        public void OnImageAvailable(ImageReader reader)
        {
            Parent.BackgroundHandler.Post(new ImageSaver(
                reader.AcquireNextImage(), File));
        }

        class ImageSaver : Java.Lang.Object, IRunnable
        {
            /// <summary>
            /// The Jpeg image
            /// </summary>
            readonly Image mImage;

            /// <summary>
            /// The file we save the image into
            /// </summary>
            readonly File mFile;

            public ImageSaver(Image image, File file)
            {
                mImage = image;
                mFile = file;
            }

            public void Run()
            {
                var buffer = mImage.GetPlanes()[0].Buffer;
                var bytes = new byte[buffer.Remaining()];
                buffer.Get(bytes);

                using (var output = new FileOutputStream(mFile))
                {
                    try
                    {

                        output.Write(bytes);
                    }
                    catch (IOException e)
                    {
                        e.PrintStackTrace();
                    }
                    finally
                    {
                        mImage.Close();
                    }
                }
            }
        }
    }
}