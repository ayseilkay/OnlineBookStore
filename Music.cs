using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnlineBookStore
{
    class Music : Product
    {
        public ArrayList allmusicrecord = new ArrayList();
        private string MusicAlbum;
        private string MusicSong;
        public SoundPlayer Song;
        public override ArrayList GetData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Windows.Forms.Application.StartupPath + @"\\MusicList.xml");
            XmlNodeList nodelist = xmlDoc.SelectNodes("/ArrayOfMusic/Music");
            foreach (XmlNode item in nodelist)
            {
                CreateProduct prdct = new CreateProduct();
                Music my_music = (Music)CreateProduct.FactoryObjeYarat("Music");
                my_music.MusicAlbum1 = item.SelectSingleNode("MusicAlbum").InnerText;
                my_music.Name1 = item.SelectSingleNode("MusicArtist").InnerText;

                my_music.MusicSong1 = item.SelectSingleNode("MusicSong").InnerText;
                my_music.Song = Properties.Resources.ResourceManager.GetObject(my_music.MusicSong1) as SoundPlayer;

                my_music.Category1 = item.SelectSingleNode("MusicCategory").InnerText;
                my_music.Price1 = float.Parse(item.SelectSingleNode("MusicPrice").InnerText);

                my_music.ImageName1 = item.SelectSingleNode("MusicImage").InnerText;
                my_music.Image = Properties.Resources.ResourceManager.GetObject(my_music.ImageName1) as Image;

                allmusicrecord.Add(my_music);
            }
            return allmusicrecord;
        }
        public string MusicAlbum1
        {
            get { return MusicAlbum; }
            set { MusicAlbum = value; }
        }
        public string MusicSong1
        {
            get { return MusicSong; }
            set { MusicSong = value; }
        }
    }
}
