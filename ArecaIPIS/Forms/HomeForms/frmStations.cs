using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.HomeForms
{
    public partial class frmStations : Form
    {
        public frmStations()
        {
            InitializeComponent();
        }

        private void frmStations_Load(object sender, EventArgs e)
        {
            fillStations();
        }

        public void fillStations()
        {
            DataTable DivertedToTerminatedStationsDt = OnlineTrainsDao.GetDivertedToTerminatedStationsNames();

            dgvStations.Rows.Clear();



            foreach (DataRow row in DivertedToTerminatedStationsDt.Rows)
            {
                int rowIndex = dgvStations.Rows.Add();

                dgvStations.Rows[rowIndex].Cells["dgvEnglishcolumn"].Value = row["stationeng"].ToString();
                dgvStations.Rows[rowIndex].Cells["dgvHindiColumn"].Value = row["stationhind"].ToString();
                dgvStations.Rows[rowIndex].Cells["dgvRegional"].Value = row["stationreg1"].ToString();                
            }

            }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStations_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStations_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> checkedRows = new List<DataGridViewRow>();
            checkedRows.Clear();
            foreach (DataGridViewRow row in dgvStations.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (Convert.ToBoolean(row.Cells["DgvSelectColumn"].EditedFormattedValue))
                    {
                        checkedRows.Add(row);
                    }
                }
            }
            if(checkedRows.Count>0)
            {
                frmOnlineTrains.ChangeCity(BaseClass.currentdatgridRow, checkedRows);
            }

        }
    }
}
