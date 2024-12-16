using System.Drawing.Printing;
using Application = System.Windows.Forms.Application;
namespace Generateur2Formulaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
                if (folderBrowserDialog1.SelectedPath.Length > 3) { textBox3.Text += "\\"; }
                textBox1.Text = Path.GetFileName(folderBrowserDialog1.SelectedPath);
            }
        }
        private void Form1_Load(object sender, EventArgs e) => Text = System.Windows.Forms.Application.ProductName;
        private void button3_Click(object sender, EventArgs e) => Application.Exit();
        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(textBox3.Text + textBox2.Text + ".cs");
            sw.WriteLine("using System;");
            if (checkBox1.Checked)
            {
                sw.WriteLine("using System.Drawing;");
                sw.WriteLine("using System.Drawing.Printing;");
            }
            sw.WriteLine("using Wisej.Web;");
            sw.WriteLine("namespace " + textBox1.Text);
            sw.WriteLine("{");
            sw.WriteLine("public partial class " + textBox2.Text + " : Form");
            sw.WriteLine("{");
            if (checkBox1.Checked)
            {
                sw.WriteLine("private PrintDocument printDocument;");
            }
            sw.WriteLine("public " + textBox2.Text + "()");
            sw.WriteLine("{InitializeComponent();}");
            sw.WriteLine("button1.Text=\"Impression\"");
            sw.WriteLine("private void InitFormulaire(object sender, EventArgs e){}");
            if (checkBox1.Checked)
            {
                sw.WriteLine("private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) {e.Graphics.DrawString(\"Ceci est un exemple de texte imprimé sur une feuille A4.\", new Font(\"Arial\", 12), Brushes.Black, new PointF(100, 100)); }");
                sw.WriteLine("private void button1_Click(object sender, EventArgs e){");
                sw.WriteLine("printDocument = new PrintDocument(); ");
                sw.WriteLine("printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);");
                sw.WriteLine("PrintDialog printDialog = new PrintDialog();");
                sw.WriteLine("printDialog.Document = printDocument;");
                sw.WriteLine("if (printDialog.ShowDialog() == DialogResult.OK) { printDocument.Print(); }");
                sw.WriteLine("}}}");
            }
            else
            {
                sw.WriteLine("private void button1_Click(object sender, EventArgs e){}}}");
            }
            sw.WriteLine("private void button1_Click(object sender, EventArgs e){}}}");
            sw.Close();
            sw = null;
            sw = new StreamWriter(textBox3.Text + textBox2.Text + ".Designer.cs");
            sw.WriteLine("using System;");
            sw.WriteLine("using Wisej.Web;");
            sw.WriteLine("namespace " + textBox1.Text);
            sw.WriteLine("{");
            sw.WriteLine("public partial class " + textBox2.Text + "\n{");
            sw.WriteLine("private System.ComponentModel.IContainer components = null;");
            sw.WriteLine("protected override void Dispose(bool disposing){");
            sw.WriteLine("if (disposing && (components != null)){components.Dispose();}");
            sw.WriteLine("base.Dispose(disposing);}");
            sw.WriteLine("private void InitializeComponent(){");
            sw.WriteLine("this.button1 = new Wisej.Web.Button();");
            sw.WriteLine("this.SuspendLayout();");
            sw.WriteLine("this.button1.BackColor = System.Drawing.Color.FromArgb(153, 153, 153);");
            sw.WriteLine("this.button1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 255);");
            sw.WriteLine("this.button1.Location = new System.Drawing.Point(692, 397);");
            sw.WriteLine("this.button1.Name = \"button1\";");
            sw.WriteLine("this.button1.Size = new System.Drawing.Size(100, 27);");
            sw.WriteLine("this.button1.TabIndex = 0;");
            sw.WriteLine("this.button1.Text = \"button1\";");
            sw.WriteLine("this.button1.Click += new System.EventHandler(this.button1_Click);");
            sw.WriteLine("this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);");
            sw.WriteLine("this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;");
            sw.WriteLine("this.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);");
            sw.WriteLine("this.ClientSize = new System.Drawing.Size(795, 427);");
            sw.WriteLine("this.Controls.Add(this.button1);");
            sw.WriteLine("this.ForeColor = System.Drawing.Color.FromArgb(244, 244, 244);");
            sw.WriteLine("this.FormBorderStyle = Wisej.Web.FormBorderStyle.Fixed;");
            sw.WriteLine("this.HeaderBackColor = System.Drawing.Color.FromArgb(61, 61, 61);");
            sw.WriteLine("this.HeaderForeColor = System.Drawing.Color.FromArgb(172, 248, 148);");
            sw.WriteLine("this.Icon = global::" + textBox1.Text + ".Properties.Resources.ico103;");
            sw.WriteLine("this.IconLarge = global::" + textBox1.Text + ".Properties.Resources.ico103;");
            sw.WriteLine("this.MaximizeBox = false;");
            sw.WriteLine("this.MinimizeBox = false;");
            sw.WriteLine("this.Name = \"" + textBox2.Text + "\";");
            sw.WriteLine("this.ShowInTaskbar = false;");
            sw.WriteLine("this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;");
            sw.WriteLine($"this.Text = \"{textBox1.Text}.{textBox2.Text}\";"); //simplement pour identifier la fenetre visuellement
            sw.WriteLine("this.Load += new System.EventHandler(this.InitFormulaire);");
            sw.WriteLine("this.ResumeLayout(false);}");
            sw.WriteLine("private Wisej.Web.Button button1;} }");
            sw.Close();
            sw = null;
            sw = new StreamWriter(textBox3.Text + textBox2.Text + ".resx");
            sw.WriteLine("<? xml version = \"1.0\" encoding = \"utf-8\" ?>");
            sw.WriteLine("< root >");
            sw.WriteLine("<xsd:schema id = \"root\" xmlns= \"\" xmlns:xsd= \"http://www.w3.org/2001/XMLSchema\" xmlns:msdata= \"urn:schemas-microsoft-com:xml-msdata\" >");
            sw.WriteLine("    < xsd:import namespace=\"http://www.w3.org/XML/1998/namespace\" />");
            sw.WriteLine("    <xsd:element name = \"root\" msdata:IsDataSet=\"true\">");
            sw.WriteLine("      <xsd:complexType>");
            sw.WriteLine("        <xsd:choice maxOccurs = \"unbounded\" >");
            sw.WriteLine("          < xsd:element name = \"metadata\" >");
            sw.WriteLine("            < xsd:complexType>");
            sw.WriteLine("              <xsd:sequence>");
            sw.WriteLine("                <xsd:element name = \"value\" type=\"xsd:string\" minOccurs=\"0\" />");
            sw.WriteLine("              </xsd:sequence>");
            sw.WriteLine("              <xsd:attribute name = \"name\" use=\"required\" type=\"xsd:string\" />");
            sw.WriteLine("              <xsd:attribute name = \"type\" type=\"xsd:string\" />");
            sw.WriteLine("              <xsd:attribute name = \"mimetype\" type=\"xsd:string\" />");
            sw.WriteLine("              <xsd:attribute ref=\"xml:space\" />");
            sw.WriteLine("            </xsd:complexType>");
            sw.WriteLine("          </xsd:element>");
            sw.WriteLine("          <xsd:element name = \"assembly\" >");
            sw.WriteLine("            < xsd:complexType>");
            sw.WriteLine("              <xsd:attribute name = \"alias\" type=\"xsd:string\" />");
            sw.WriteLine("              <xsd:attribute name = \"name\" type=\"xsd:string\" />");
            sw.WriteLine("            </xsd:complexType>");
            sw.WriteLine("          </xsd:element>");
            sw.WriteLine("          <xsd:element name = \"data\" >");
            sw.WriteLine("            < xsd:complexType>");
            sw.WriteLine("              <xsd:sequence>");
            sw.WriteLine("                <xsd:element name = \"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
            sw.WriteLine("                <xsd:element name = \"comment\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"2\" />");
            sw.WriteLine("              </xsd:sequence>");
            sw.WriteLine("              <xsd:attribute name = \"name\" type=\"xsd:string\" use=\"required\" msdata:Ordinal=\"1\" />");
            sw.WriteLine("              <xsd:attribute name = \"type\" type=\"xsd:string\" msdata:Ordinal=\"3\" />");
            sw.WriteLine("              <xsd:attribute name = \"mimetype\" type=\"xsd:string\" msdata:Ordinal=\"4\" />");
            sw.WriteLine("              <xsd:attribute ref=\"xml:space\" />");
            sw.WriteLine("            </xsd:complexType>");
            sw.WriteLine("          </xsd:element>");
            sw.WriteLine("          <xsd:element name = \"resheader\" >");
            sw.WriteLine("            < xsd:complexType>");
            sw.WriteLine("              <xsd:sequence>");
            sw.WriteLine("                <xsd:element name = \"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
            sw.WriteLine("              </xsd:sequence>");
            sw.WriteLine("              <xsd:attribute name = \"name\" type=\"xsd:string\" use=\"required\" />");
            sw.WriteLine("            </xsd:complexType>");
            sw.WriteLine("          </xsd:element>");
            sw.WriteLine("        </xsd:choice>");
            sw.WriteLine("      </xsd:complexType>");
            sw.WriteLine("    </xsd:element>");
            sw.WriteLine("  </xsd:schema>");
            sw.WriteLine("  <resheader name = \"resmimetype\" >");
            sw.WriteLine("    < value > text / microsoft - resx </ value >");
            sw.WriteLine("  </ resheader >");
            sw.WriteLine("  < resheader name=\"version\">");
            sw.WriteLine("    <value>2.0</value>");
            sw.WriteLine("  </resheader>");
            sw.WriteLine("  <resheader name = \"reader\" >");
            sw.WriteLine("    < value > System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
            sw.WriteLine("  </resheader>");
            sw.WriteLine("  <resheader name = \"writer\" >");
            sw.WriteLine("    < value > System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
            sw.WriteLine("  </resheader>");
            sw.WriteLine("  <metadata name = \"$this.RulerSnapLines\" mimetype=\"application/x-microsoft.net.object.binary.base64\">");
            sw.WriteLine("    <value>");
            sw.WriteLine("        AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00LjAuMC4wLCBDdWx0");
            sw.WriteLine("        dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EHAQAAAAABAAAAAAAAAAQU");
            sw.WriteLine("        U3lzdGVtLkRyYXdpbmcuUG9pbnQCAAAACw==");
            sw.WriteLine("   </value>");
            sw.WriteLine(" </metadata>");
            sw.WriteLine("</root>");
            sw.Close();
            sw = null;
        }
    }
}