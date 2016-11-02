using System;
using Android.Content;
using Android.Support.V13.App;
using Android;

namespace Camera2Basic.Util
{
    internal class PositiveClickListener : Java.Lang.Object, IDialogInterfaceOnClickListener
    {
        private ConfirmationDialog confirmationDialog;

        public PositiveClickListener(ConfirmationDialog confirmationDialog)
        {
            this.confirmationDialog = confirmationDialog;
        }

        public void OnClick(IDialogInterface dialog, int which)
        {
            FragmentCompat.RequestPermissions(confirmationDialog,
                new[] { Manifest.Permission.Camera }, 
                Camera2BasicFragment.RequestCameraPermissionCode);
        }
    }
}