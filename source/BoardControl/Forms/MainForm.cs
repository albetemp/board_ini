using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlbeFly.BoardControl;

namespace AlbeFly.BoardControl
{
    public partial class MainForm : Form
    {

        public Defs.CloseAppDelegate closeAppDelegate;
        public Defs.GetBoardInfoDelegate getBoardInfoDelegate;


        private readonly object _lock;
        private readonly List<string> _log = new List<string>(); // stored all mem logs before sending to the form
        private List<string> _tmpLog = new List<string>(); // temp copy of _log (performance)

        private Logger _logger = Logger.GetInstance();

        public MainForm()
        {
            InitializeComponent();
            _lock = new object();
        }

        internal static string GetCaption()
        {
            return Defs.MAIN_FORM_CAPTION;
        }


        public void OnMemLog(object sender, MemLogEventArgs e)
        {
            lock (_lock)
            {
                _log.Add(e.Log); // store log and immediately unlock
            }
        }

        /// <summary>
        /// Timer-based log screen output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrLog_Tick(object sender, EventArgs e)
        {            

            lock (_lock)
            {
                _tmpLog = new List<string>(_log);
                _log.Clear();
            }

            tmrLog.Enabled = false;

            foreach (var logEntry in _tmpLog)
            {
                lstLog.Items.Add(logEntry);                 
            }

            _tmpLog.Clear();

            if (lstLog.Items.Count > 2)
            {
                lstLog.SelectedIndex = lstLog.Items.Count - 1;
                //lstLog.ClearSelected();
                //lstLog.Update();
            }
            tmrLog.Enabled = true;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeAppDelegate?.Invoke(); // Call close app delegate if assigned
        }

        public void FormInit()
        {
            // clear all views

            dgvControlBits.Rows.Clear();
            dgvControlBits.Refresh();

            dgvParams.Rows.Clear();
            dgvParams.Refresh();

            lstBoardSelector.Items.Clear();
        }

        public void FormAddBoard(int index)
        {
            Board board = getBoardInfoDelegate(index);

            lstBoardSelector.Items.Add(board.Name);
        }

        public void FormSelectBoard(int index)
        {
            if ((index < 0) || (index >= lstBoardSelector.Items.Count))
            {
                _logger.WriteLine(LogLevel.Error, $"Wrong board index [{index}] in FormSelectBoard delegate call; Set to the first");
                index = 0;
            }

            lstBoardSelector.SetSelected(index, true);

        }

        public void AddControlBit(ControlBitInfo cBit)
        {
            
        }

        private void lstBoardSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lstBoardSelector.SelectedIndex;
            if ((selectedIndex >= 0) && (selectedIndex <= lstBoardSelector.Items.Count))
            ShowBoardInfo(selectedIndex);
        }

        private void ShowBoardInfo(int index)
        {
            Board board = getBoardInfoDelegate(index);

            dgvControlBits.Rows.Clear();
            dgvControlBits.Refresh();

            dgvParams.Rows.Clear();
            dgvParams.Refresh();            

            for (byte loop = 0; loop < board.Params.GetNumberOfParams(board.BoardVersion); loop++)
            {
                ParamInfo paramInfo = board.Params[loop].GetParamInfo(board.BoardVersion);

                if (paramInfo == null)
                {
                    _logger.WriteLine(LogLevel.Error, $"Unable to load param bit info for bit[{loop}] and board ver[{board.BoardVersion}]");
                    return;
                }

                if (paramInfo.Visible)
                {
                    DataGridViewRow dgr = new DataGridViewRow();

                    dgr.Cells.Add(new DataGridViewTextBoxCell());
                    dgr.Cells.Add(new DataGridViewTextBoxCell());
                    dgr.Cells.Add(new DataGridViewTextBoxCell());

                    dgr.Cells[0].Value = loop;
                    dgr.Cells[1].Value = paramInfo.Description;
                    dgr.Cells[2].Value = board.Params[loop].Value;

                    dgvParams.Rows.Add(dgr);

                }

            }

            ControlBitParam controlBitParam = board.ControlParam;

            for (byte loop = 0; loop < ControlBitParam.NUMBER_OF_CONTROL_BITS; loop++)
            {                
                ControlBitInfo controlBitInfo = controlBitParam[loop].GetControlBitInfo(board.BoardVersion);
                if (controlBitInfo == null)
                {
                    _logger.WriteLine(LogLevel.Error, $"Unable to load control bit info for bit[{loop}] and board ver[{board.BoardVersion}]");
                    return;
                }
                if (controlBitInfo.Visible)
                {
                    DataGridViewRow dgr = new DataGridViewRow();                                      

                    dgr.Cells.Add(new DataGridViewTextBoxCell());
                    dgr.Cells.Add(new DataGridViewTextBoxCell());
                    dgr.Cells.Add(new DataGridViewComboBoxCell());

                    dgr.Cells[0].Value = loop;
                    dgr.Cells[1].Value = controlBitInfo.Description;

                    // fill combobox

                    DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)(dgr.Cells[2]);

                    foreach (string valueInfo in controlBitInfo.ValuesInfo)
                    {                        
                        comboBoxCell.Items.Add(valueInfo);                        
                    }
                    comboBoxCell.Value = comboBoxCell.Items[0];

                    dgvControlBits.Rows.Add(dgr);

                }
            }

        }
    }
}
