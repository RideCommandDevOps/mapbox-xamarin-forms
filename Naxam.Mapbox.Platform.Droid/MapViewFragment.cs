using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Com.Mapbox.Mapboxsdk.Annotations;
using Com.Mapbox.Mapboxsdk.Maps;

namespace Naxam.Controls.Mapbox.Platform.Droid
{
    public class MapViewFragment : SupportMapFragment,
        MapView.IOnCameraDidChangeListener,
        MapView.IOnDidFinishLoadingStyleListener,
        MapView.IOnDidFinishRenderingMapListener
    {
        public MapView MapView { get; private set; }

        public MapView.IOnCameraDidChangeListener OnCameraDidChangeListener { get; set; }
        public MapView.IOnDidFinishLoadingStyleListener OnDidFinishLoadingStyleListener { get; set; }
        public MapView.IOnDidFinishRenderingMapListener OnDidFinishRenderingMapListener { get; set; }

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

            MapView = view as MapView;
            MapView?.OnCreate(savedInstanceState);
            MapView?.AddOnCameraDidChangeListener(this);
            MapView?.AddOnDidFinishLoadingStyleListener(this);
            MapView?.AddOnDidFinishRenderingMapListener(this);
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            MapView?.RemoveOnCameraDidChangeListener(this);
            MapView?.RemoveOnDidFinishLoadingStyleListener(this);
            MapView?.RemoveOnDidFinishRenderingMapListener(this);
            MapView?.OnDestroy();
        }

        public void OnCameraDidChange(bool p0)
        {
            OnCameraDidChangeListener?.OnCameraDidChange(p0);
        }

        public void OnDidFinishLoadingStyle()
        {
            OnDidFinishLoadingStyleListener?.OnDidFinishLoadingStyle();
        }

        public void OnDidFinishRenderingMap(bool p0)
        {
            OnDidFinishRenderingMapListener?.OnDidFinishRenderingMap(p0);
        }

        public override void OnResume()
        {
            base.OnResume();
            MapView?.OnResume();
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            // This was causing crashes when minimizing app.
            base.OnSaveInstanceState(outState);
            MapView?.OnSaveInstanceState(outState);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MapView?.OnCreate(savedInstanceState);
        }

        public override void OnStart()
        {
            base.OnStart();
            MapView?.OnStart();
        }

        public override void OnStop()
        {
            base.OnStop();
            MapView?.OnStop();
        }

        public override void OnPause()
        {
            base.OnPause();
            MapView?.OnPause();
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
            MapView?.OnLowMemory();
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
