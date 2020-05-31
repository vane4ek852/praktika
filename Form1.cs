using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSBO_01_18LebedISPraktika2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private volatile WiFiLocation[] _locations;
        private readonly GMapOverlay Objects = new GMapOverlay("objects");

        private void Form1_Load(object sender, EventArgs e)
        {
            gMap.MapProvider = GMapProviders.YandexMap;
            gMap.Position = new PointLatLng(55.755345, 37.623604); // Moscow
            gMap.MinZoom = 0;
            gMap.MaxZoom = 24;
            gMap.Zoom = 12;
            gMap.Overlays.Add(Objects);
            gMap.CanDragMap = true;
            gMap.DragButton = MouseButtons.Left; 



            lbStatus.Text = "Загрузка данных...";
            Task.Run(async () => {
                var api = new MosApi();
                _locations = await api.GetLocationData();
                Invoke((UpdateDataDelegate)UpdateData);

            });
        }

        private delegate void UpdateDataDelegate();

        private void UpdateData()
        {
            lbStatus.Text = "Данные загружены";           

            UpdateMarkers(_locations);

            var districts = _locations
                .GroupBy(x => x.Cells.District)
                .Select(d => d.Key)
                .ToArray();

            cbDistricts.Items.Add("Все районы");
            cbDistricts.Items.AddRange(districts);
            cbDistricts.Enabled = true;
        }

        private void UpdateMarkers(IEnumerable<WiFiLocation> locations)
        {
            Objects.Markers.Clear();
            var cnt = 0;
            foreach (var location in locations)
            {
                cnt++;
                //var location = _locations[0];
                var point = location.Cells.geoData;

                var marker = new GMarkerGoogle(
                    new PointLatLng(point.Latitude, point.Longitude),
                    GMarkerGoogleType.red_small);
                marker.Tag = location;
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = $"{location.Cells.Name}:{location.Cells.WiFiName}\n{location.Cells.NumberOfAccessPoints} {location.Cells.AccessFlag}";
                Objects.Markers.Add(marker);
            }

            lbCount.Text = $"Найдено {cnt} WiFi точек";

        }


        private void gMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            var wifi = (item.Tag as WiFiLocation).Cells;
            MessageBox.Show(this,
                $@"
Password: {wifi.Password}
Coverage Area:{ wifi.CoverageArea}
",
                $"{wifi.Name}:{wifi.WiFiName}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void cbDistricts_SelectedValueChanged(object sender, EventArgs e)
        {
            var district = cbDistricts.SelectedItem as string;
            
            var locations = 
                (district == "Все районы")
                ? _locations
                : _locations.Where(x => x.Cells.District == district);
            UpdateMarkers(locations);
        }
    }
}
