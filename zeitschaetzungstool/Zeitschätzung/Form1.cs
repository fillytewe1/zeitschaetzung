using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeitschätzung
{
    public partial class Form1 : Form
    {
         
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 

            dataGridView1.Columns[0].Width = 450;
            dataGridView1.Columns[1].Width = 137;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AutoSize = true;
            this.MinimumSize = new Size(675, 522);
            /*dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 4; */
            this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.ColumnIndex == 1)
            {
                SummeAktualisieren();
            }
        }

        public void SummeAktualisieren()
        {
            double summe = 0;

            List<string> zeiten = new List<string>(); // liste eingabe 
            for (int z = 0; z < dataGridView1.Rows.Count - 1; z++)
            {
                var aktuelleZeile = dataGridView1.Rows[z].Cells["GeschaetzteZeit"].Value;

                if (aktuelleZeile != null)
                {
                    string[] bloecke = aktuelleZeile.ToString().Split(' ');

                    foreach (string block in bloecke)
                    {
                        zeiten.Add(block.ToLower());
                    }
                }  // null ist ein nicht definiertes objekt // Funktionalität oder Eigenschaft für ein bestimmtes object
            }

            foreach (var zeit in zeiten)
            {
                try
                {
                    if (zeit.Contains("d")) // regex ist bessser string d = "d$"
                    {

                        summe += ErhalteStundenVonTag(zeit);
                    }
                    else if (zeit.Contains("h"))
                    {
                        summe += ErhalteStunden(zeit);
                    }
                    else
                    {
                        summe += ErhalteStundenVonMinuten(zeit);
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            lbnliveAusgabe.Text = String.Format(summe % 1 == 0 ? "{0:0}" : "{0:0.00}", summe) + " Stunden";
        }

        private bool SindDatenVollstaendig()
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                bool istBeschreibungVollstaendig = !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[0].Value?.ToString());
                bool istZeitVollstaendig = !String.IsNullOrWhiteSpace(dataGridView1.Rows[i].Cells[1].Value?.ToString());

                if (!istBeschreibungVollstaendig || !istZeitVollstaendig)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IstZeileUnvollstaendig(DataGridViewRow row)
        {
            bool istBeschreibungUnvollstaendig = String.IsNullOrWhiteSpace(row.Cells[0].Value?.ToString());
            bool istZeitUnvollstaendig = String.IsNullOrWhiteSpace(row.Cells[1].Value?.ToString());
            return istBeschreibungUnvollstaendig || istZeitUnvollstaendig;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            if (!SindDatenVollstaendig())
            {
                MessageBox.Show("Bitte füllen Sie alle Zellen aus ein bevor sie Kopieren.");
                return;
            }
            else
            {
                var newline = System.Environment.NewLine;
                var tab = "\t";
                var clipboard_string = "";
                var clipboard_stringToRedmineBeschreibungsWert = "";
                var clipboard_stringToRedmineZahlenWert = "";
                var namen = "||Beschreibung||Geschätzte Zeit|| \r\n";
                
                var htmlTableStart =
                  @"<figure class=""table"">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <strong>Beschreibung</strong> 
                            </td>
                            <td>
                                <strong>Geschätzte Zeit</strong> 
                            </td>
                        </tr>";
                var htmlEnd =
                    @"      </tbody>
                         </table>
                   </figure>";
                 
                var htmlTdOpenWithUserValue = "<td>"  ;
                var htmlTdClose = "</td>"  ;

                var htmlTrOpenAfterRow = "<tr>"  ;
                var htmlTrCloseAfterRow = "</tr>"  ;
                // DataGridViewCell testval;
                //DataGridViewCell dddddd = new DataGridViewCell();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {

                        if (IstZeileUnvollstaendig(row))
                        {
                            continue;
                        }
                        else if (i == (row.Cells.Count - 1))
                        {
                            //dddddd = (DataGridViewCell)row.Cells[i].Value;
                            //testval += row.Cells[i].Value;
                            clipboard_string += row.Cells[i].Value + "| " + newline;
                            clipboard_stringToRedmineZahlenWert = htmlTdOpenWithUserValue 
                                + row.Cells[i].Value   +
                                htmlTdClose 
                                + htmlTrCloseAfterRow;
                            clipboard_stringToRedmineBeschreibungsWert += clipboard_stringToRedmineZahlenWert;
                        }
                        else
                        {
                            //testval += row.Cells[i].Value;
                            clipboard_string += row.Cells[i].Value + tab;
                            var temp= htmlTrOpenAfterRow + 
                                htmlTdOpenWithUserValue + 
                                row.Cells[i].Value
                                + htmlTdClose  ;
                                
                            clipboard_stringToRedmineBeschreibungsWert += temp;
                        }
                    }
                }
                var zusammen = namen + clipboard_string;
                var summeBlock = $@"<tr><td>Summe</td><td>{lbnliveAusgabe.Text.ToString()}</td></tr>";
                var zusammenRedmine = htmlTableStart + clipboard_stringToRedmineBeschreibungsWert  + summeBlock + htmlEnd;
                var formatiertRedmine = System.Xml.Linq.XElement.Parse(zusammenRedmine).ToString();
                string[] splitClipboard = zusammen.Split('\t');
                string combine = string.Join("|", splitClipboard);
                string[] splitClipboardBuchstabeN = combine.Split('\n');
                string secondcombine = string.Join("|", splitClipboardBuchstabeN);
                string lastblock = secondcombine + " Summe " + "  | " + lbnliveAusgabe.Text.ToString() + "|";
                // Clipboard.SetText(lastblock); The old code for Jira
                //Clipboard.SetText(formatiertRedmine); // new Code for Redmine
                 
                this.dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.Rows.Add("Summe", lbnliveAusgabe.Text.ToString());
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.SelectAll();
                Clipboard.SetDataObject(
                this.dataGridView1.GetClipboardContent());
                int lastrow = dataGridView1.Rows.Count-1; 
                dataGridView1.Rows.RemoveAt(lastrow);
                dataGridView1.ClearSelection();
                dataGridView1.RowHeadersVisible = true;
                this.dataGridView1.AllowUserToAddRows = true;
                
            }

        }

        private double ErhalteStundenVonTag(string eingabe)
        {
            string regex = @"(\d+|\d+[,.]{1}\d+)d$";
            var match = Regex.Match(eingabe, regex);

            if (match.Success)
            {
                string zahl = match.Groups[1].Value.Replace(',', '.');
                return Convert.ToDouble(zahl, new NumberFormatInfo() { NumberDecimalSeparator = "." }) * 8;
            }
            throw new Exception($"Ihre Eingabe '{ eingabe }' ist falsch!!");
        }

        private double ErhalteStundenVonMinuten(string eingabe)
        {
            string regex = @"(\d+)m$|^(\d+)$";
            var match = Regex.Match(eingabe, regex);

            if (match.Success)
            {
                string match1 = match.Groups[1].Value;
                string match2 = match.Groups[2].Value;
                if (string.IsNullOrWhiteSpace(match1))
                {
                    return Convert.ToDouble(match2) / 60;
                }
                else
                {
                    return Convert.ToDouble(match1) / 60;
                }
            }
            throw new Exception($"Ihre Eingabe '{ eingabe }' ist falsch!!");
        }

        private double ErhalteStunden(string eingabe)
        {
            string regex = @"(\d+|\d+[,.]{1}\d+)h$";
            var match = Regex.Match(eingabe, regex);

            if (match.Success)
            {
                string zahl = match.Groups[1].Value.Replace(',', '.');
                return Convert.ToDouble(zahl, new NumberFormatInfo() { NumberDecimalSeparator = "." });
            }

            throw new Exception($"Ihre Eingabe '{ eingabe }' ist falsch!!");
        }

        private void btnloeschen_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            lbnVollstaendig.Text = "";
            lbnliveAusgabe.Text = "Ausgabe";
        }

        public static int totalRowcount(DataGridView dt)
        {
            int counter = 0;
            foreach (DataGridViewRow row in dt.Rows)
            {
                counter = dt.Rows.Count;
            }
            return counter;
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            bool isValid = true;

            for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count -1 && isValid; rowIndex++)
            {
                var currentRow = dataGridView1.Rows[rowIndex];

                for (int cellIndex = 0; cellIndex < dataGridView1.Rows[rowIndex].Cells.Count; cellIndex++)
                {
                    if (currentRow.Cells[cellIndex].Value == null || String.IsNullOrWhiteSpace(currentRow.Cells[cellIndex].Value.ToString()))
                    {
                        isValid = false;
                    }
                    else
                    {
                        lbnVollstaendig.Text = "";
                    }
                }
            }
            if (!isValid)
            {
                lbnVollstaendig.ForeColor = Color.Red;
                lbnVollstaendig.Text = "Unvollständig";
            }
            else
            {
                lbnVollstaendig.Text = "";
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            int indexcount = totalRowcount(dataGridView1);

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int index = row.Index + 1;
                if (indexcount == index)
                {
                    continue;
                }
                try
                { 
                    dataGridView1.Rows.Remove(row); 
                }
                catch
                {

                }
            }

            SummeAktualisieren();
            
        }
    }
}



