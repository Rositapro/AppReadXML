
using System;
using System.Windows.Forms;
using System.Xml;

namespace AppReadXML
{
    public partial class Form1 : Form
    {
        private string URLString;

        public Form1()
        {
            InitializeComponent();
            URLString = "https://www.w3schools.com/xml/cd_catalog.xml";

            LoadXmlData();
        }

        private void LoadXmlData()
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(URLString))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element: 
                                ListViewItem item = new ListViewItem(reader.Name);
                                while (reader.MoveToNextAttribute()) 
                                    item.SubItems.Add(reader.Name + ": " + reader.Value);
                                listView1.Items.Add(item);
                                break;
                            case XmlNodeType.Text: 
                                listView1.Items.Add(reader.Value);
                                break;
                            case XmlNodeType.EndElement: 
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

