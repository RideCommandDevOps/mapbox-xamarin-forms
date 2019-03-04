using System;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Com.Mapbox.Mapboxsdk.Annotations;
using Com.Mapbox.Mapboxsdk.Maps;

namespace Naxam.Controls.Mapbox.Platform.Droid
{
    public class MapViewFragment : SupportMapFragment, MapView.IOnMapChangedListener
    {
        public MapView MapView { get; private set; }

        public MapView.IOnMapChangedListener OnMapChangedListener { get; set; }

        public bool StateSaved { get; private set; }

        public MapViewFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public MapViewFragment() : base()
        {

        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            this.MapView = view as MapView;
            this.MapView?.AddOnMapChangedListener(this);
            this.MapView?.OnCreate(savedInstanceState);
            Android.Util.Log.Warn("MAP", this.GetHashCode() + " ONVIEWCREATED " + this.MapView?.GetHashCode());
        }

        public override void OnDestroyView()
        {
            this.MapView?.RemoveOnMapChangedListener(this);
            Android.Util.Log.Warn("MAP", "#" + Java.Lang.Thread.CurrentThread().Name + ": " + this.GetHashCode() + " ONDESTROYVIEW1 " + this.MapView?.GetHashCode());
            this.MapView?.OnDestroy();
            Android.Util.Log.Warn("MAP", this.GetHashCode() + " ONDESTROYVIEW2 " + this.MapView?.GetHashCode());
            this.MapView = null;
            base.OnDestroyView();
            Android.Util.Log.Warn("MAP", this.GetHashCode() + " ONDESTROYVIEW3 " + this.MapView?.GetHashCode());
        }

        public override void OnDestroy()
        {
            Android.Util.Log.Warn("MAP", this.GetHashCode() + " _ONDESTROY " + this.MapView?.GetHashCode());
            base.OnDestroy();
        }

        public void OnMapChanged(int p0)
        {
            OnMapChangedListener?.OnMapChanged(p0);
        }

        public override void OnResume()
        {
            base.OnResume();
            this.MapView?.OnResume();
            Android.Util.Log.Warn("MAP", "#" + Java.Lang.Thread.CurrentThread().Name + ": " + this.GetHashCode() + " ONRESUME " + this.MapView?.GetHashCode());
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            // This was causing crashes when minimizing app.
            base.OnSaveInstanceState(outState);
            this.MapView?.OnSaveInstanceState(outState);
            Android.Util.Log.Warn("MAP", this.GetHashCode() + " ONSAVEINSTANCESTATE " + this.MapView?.GetHashCode());
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.MapView?.OnCreate(savedInstanceState);
            Android.Util.Log.Warn("MAP", this.GetHashCode() + " ONCREATE " + this.MapView?.GetHashCode());
        }

        public override void OnStart()
        {
            base.OnStart();
            this.MapView?.OnStart();
            Android.Util.Log.Warn("MAP", this.GetHashCode() + " ONSTART " + this.MapView?.GetHashCode());
        }

        public override void OnStop()
        {
            Android.Util.Log.Warn("MAP", this.GetHashCode() + " ONSTOP " + this.MapView?.GetHashCode());
            this.MapView?.OnStop();
            base.OnStop();
        }

        public override void OnPause()
        {
            Android.Util.Log.Warn("MAP", "#" + Java.Lang.Thread.CurrentThread().Name + ": " + this.GetHashCode() + " ONPAUSE " + this.MapView?.GetHashCode());
            this.MapView?.OnPause();
            base.OnPause();
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
            this.MapView?.OnLowMemory();
            Android.Util.Log.Warn("MAP", this.GetHashCode() + " ONLOWMEMORY " + this.MapView?.GetHashCode());
        }

        protected override void Dispose(bool disposing)
        {
            Android.Util.Log.Warn("MAP", this.GetHashCode() + $" DISPOSE({disposing}) " + this.MapView?.GetHashCode());
            //this.OnPause();
            //this.OnStop();
            //this.OnDestroyView();
            //this.OnDestroy();
            base.Dispose(disposing);
        }

        internal void ToggleInfoWindow(MapboxMap mapboxMap, Marker marker)
        {
            if (marker.IsInfoWindowShown)
            {
                mapboxMap.DeselectMarker(marker);
            }
            else
            {
                mapboxMap.SelectMarker(marker);
            }
        }
    }
}
