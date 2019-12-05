using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace xmlHandler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XmlTextWriter w = new XmlTextWriter(@"C:/Users/Abdulqadir/Documents/note.xml", Encoding.Default);
                w.Formatting = Formatting.Indented;
                w.WriteStartDocument();
                w.WriteStartElement("worker");
                w.WriteElementString("name", textBox1.Text);
                w.WriteElementString("place:", textBox2.Text);
                w.WriteElementString("salary", textBox3.Text);
                w.WriteEndElement();
                w.WriteEndDocument();
                w.Close();

                XmlTextReader r = new XmlTextReader(@"C:/Users/Abdulqadir/Documents/note.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(r);

                listBox1.Items.Clear();
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    listBox1.Items.Add(node.Name);
                    listBox1.Items.Add(node.InnerText);

                }
                r.Close();
            

            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occured"+ex);
            }
        }
    }
}
