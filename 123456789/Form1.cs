using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Device.Location;
namespace _123456789
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;


        }

        GMapOverlay PositionsForUser = new GMapOverlay("ПозицияпоЛКМ");
        ToolStripMenuItem ClearMap = new ToolStripMenuItem("Очистить карту");

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 50;
            gMapControl1.Zoom = 3;
            gMapControl1.ShowCenter = false;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            ClearMap.Click += button1_Click;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            PositionsForUser.Clear();
        }

        int count = 0;
        GeoCoordinate First;
        GeoCoordinate Second;
        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (count != 0)
            {
                Second = new GeoCoordinate(item.Position.Lat, item.Position.Lng);
                double distance = First.GetDistanceTo(Second);

                distance = Math.Ceiling(distance);
                double km = distance / 1000;

                label3.Text = "Растояние в метрах: " + distance + " м";
                label4.Text = "Растояние в километрах: " + km + " км";
            }
            if (count == 0)
            {
                label1.Text = "Координаты по Х: " +  item.Position.Lat.ToString();
                label2.Text = "Координаты по Y: " +  item.Position.Lng.ToString();
                First = new GeoCoordinate(item.Position.Lat, item.Position.Lng);
                count++;
            }
            
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                gMapControl1.Overlays.Add(PositionsForUser);

                // Широта - latitude - lat - с севера на юг
                double x = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
                // Долгота - longitude - lng - с запада на восток
                double y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;

                label1.Text = "Координаты по Х: " + x.ToString();
                label2.Text = "Координаты по Y: " + y.ToString();

                // Добавляем метку на слой
                GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(y, x), GMarkerGoogleType.blue_pushpin);
                MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                MarkerWithMyPosition.ToolTipText = "Метка пользователя";
                PositionsForUser.Markers.Add(MarkerWithMyPosition);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count = 0;
            label1.Text = "Координаты по Х: ";
            label2.Text = "Координаты по Y: ";
            label3.Text = "Растояние в метрах:";
            label4.Text = "Растояние в километрах:";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(comboBox1.SelectedIndex == 0)
            {
                gMapControl1.Overlays.Add(PositionsForUser);
                GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(56.140411994247444, 40.39224070242224), GMarkerGoogleType.blue_pushpin);
                MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                MarkerWithMyPosition.ToolTipText = "Владимир";
                PositionsForUser.Markers.Add(MarkerWithMyPosition);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                gMapControl1.Overlays.Add(PositionsForUser);
                GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(55.73355224284894, 37.61072673978567), GMarkerGoogleType.blue_pushpin);
                MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                MarkerWithMyPosition.ToolTipText = "Москва";
                PositionsForUser.Markers.Add(MarkerWithMyPosition);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                gMapControl1.Overlays.Add(PositionsForUser);
                GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(40.72238707770534, -74.00852560687767), GMarkerGoogleType.blue_pushpin);
                MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                MarkerWithMyPosition.ToolTipText = "Нью-Йорк";
                PositionsForUser.Markers.Add(MarkerWithMyPosition);
            }
            if (comboBox1.SelectedIndex == 3)
            {
                gMapControl1.Overlays.Add(PositionsForUser);
                GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(52.52264022293314, 13.391081573952498), GMarkerGoogleType.blue_pushpin);
                MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                MarkerWithMyPosition.ToolTipText = "Берлин";
                PositionsForUser.Markers.Add(MarkerWithMyPosition);
            }
            if (comboBox1.SelectedIndex == 4)
            {
                gMapControl1.Overlays.Add(PositionsForUser);
                GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(43.60271061808591, 39.725815261155155), GMarkerGoogleType.blue_pushpin);
                MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                MarkerWithMyPosition.ToolTipText = "Сочи";
                PositionsForUser.Markers.Add(MarkerWithMyPosition);
            }
            if (comboBox1.SelectedIndex == 5)
            {
                gMapControl1.Overlays.Add(PositionsForUser);
                GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(52.37015943092413, 4.891599624063412), GMarkerGoogleType.blue_pushpin);
                MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                MarkerWithMyPosition.ToolTipText = "Амстердам";
                PositionsForUser.Markers.Add(MarkerWithMyPosition);
            }
            if (comboBox1.SelectedIndex == 6)
            {
                gMapControl1.Overlays.Add(PositionsForUser);
                GMarkerGoogle MarkerWithMyPosition = new GMarkerGoogle(new PointLatLng(27.98812353404187, 86.92497220814975), GMarkerGoogleType.blue_pushpin);
                MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                MarkerWithMyPosition.ToolTipText = "Эверест";
                PositionsForUser.Markers.Add(MarkerWithMyPosition);
            }
        }
    }
}
