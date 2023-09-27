using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class ControlBind : Form
    {
        public ControlBind()
        {
            InitializeComponent();
            TPCANChannelInformation[] tPCANChannelInformation = new TPCANChannelInformation[50];

            for (int i = 0; i < tPCANChannelInformation.Length; i++)
            {
                tPCANChannelInformation[i] = new TPCANChannelInformation() { device_id = Convert.ToUInt16(i) };
            }
            //comboBox1.DataSource = System.Enum.GetNames(typeof(TPCANBaudrate));
            comboBox1.DataSource = tPCANChannelInformation.Select(t=>t.device_id);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mm=
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TPCANBaudrate testenum = (TPCANBaudrate)Enum.Parse(typeof(TPCANBaudrate), comboBox1.SelectedItem.ToString(), false);
        }
    }
    public enum TPCANBaudrate : ushort
    {
        /// <summary>
        /// 1 MBit/s
        /// </summary>
        PCAN_BAUD_1M = 0x0014,
        /// <summary>
        /// 800 KBit/s
        /// </summary>
        PCAN_BAUD_800K = 0x0016,
        /// <summary>
        /// 500 kBit/s
        /// </summary>
        PCAN_BAUD_500K = 0x001C,
        /// <summary>
        /// 250 kBit/s
        /// </summary>
        PCAN_BAUD_250K = 0x011C,
        /// <summary>
        /// 125 kBit/s
        /// </summary>
        PCAN_BAUD_125K = 0x031C,
        /// <summary>
        /// 100 kBit/s
        /// </summary>
        PCAN_BAUD_100K = 0x432F,
        /// <summary>
        /// 95,238 KBit/s
        /// </summary>
        PCAN_BAUD_95K = 0xC34E,
        /// <summary>
        /// 83,333 KBit/s
        /// </summary>
        PCAN_BAUD_83K = 0x852B,
        /// <summary>
        /// 50 kBit/s
        /// </summary>
        PCAN_BAUD_50K = 0x472F,
        /// <summary>
        /// 47,619 KBit/s
        /// </summary>
        PCAN_BAUD_47K = 0x1414,
        /// <summary>
        /// 33,333 KBit/s
        /// </summary>
        PCAN_BAUD_33K = 0x8B2F,
        /// <summary>
        /// 20 kBit/s
        /// </summary>
        PCAN_BAUD_20K = 0x532F,
        /// <summary>
        /// 10 kBit/s
        /// </summary>
        PCAN_BAUD_10K = 0x672F,
        /// <summary>
        /// 5 kBit/s
        /// </summary>
        PCAN_BAUD_5K = 0x7F7F,
    }

    public struct TPCANChannelInformation
    {

        /// <summary>
        /// CAN-Controller number
        /// </summary>
        public byte controller_number;
        /// <summary>
        /// Device capabilities flag (see FEATURE_*)
        /// </summary>
        public uint device_features;
        /// <summary>
        /// Device name
        /// </summary>

        public string device_name;
        /// <summary>
        /// Device number
        /// </summary>
        public uint device_id;
        /// <summary>
        /// Availability status of a PCAN-Channel
        /// </summary>
        public uint channel_condition;
    }
}
