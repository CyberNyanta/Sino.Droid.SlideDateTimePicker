using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DateTimePicker = Sino.Droid.SlideDateTimePicker.SlideDateTimePicker;
using Android.Support.V4.App;
using Sino.Droid.SlideDateTimePicker;

namespace SlideDateTimePicker.Sample
{
    [Activity(Label = "SlideDateTimePicker.Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity , ISlideDateTimeListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                new DateTimePicker.Builder(SupportFragmentManager)
                .SetListener(this)
                .SetIs24HourTime(true)
                .SetInitialDate(DateTime.Now)
                .Build()
                .Show();
            };
        }

        #region ISlideDateTimeListener 实现

        public void OnDateTimeSet(DateTime date)
        {
            Toast.MakeText(this, date.ToString(), ToastLength.Long).Show();
        }

        public void OnDateTimeCancel()
        {
            Toast.MakeText(this, "Canceled", ToastLength.Long).Show();
        }

        #endregion
    }
}

