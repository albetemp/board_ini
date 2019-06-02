using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AlbeFly.BoardControl;

namespace AlbeFly.BoardControl
{
    class MainServer
    {

        public Defs.FormInitDelegate formInitDelegate;
        public Defs.FormAddBoardDelegate formAddBoardDelegate;
        public Defs.FormSelectBoardDelegate formSelectBoard;

        private readonly Logger _logger = Logger.GetInstance();
        private readonly BoardList _cbList;
        private readonly INIFile _iniFile;

        
        public MainServer()
        {
            _cbList = new BoardList();

            _logger.UseMemLog = true;
            _logger.LogMethodNames = true;
            _logger.OpenLogFile(Settings.ApplicationPath + Defs.LOG_FILE_NAME);

            _logger.WriteLine("");
            _logger.WriteLine("****************************************************************************************");
            _logger.WriteLine("*                                                                                      *");
            _logger.WriteLine("*                                 Application started                                  *");
            _logger.WriteLine("*                                    Board Control                                     *");
            _logger.WriteLine("*                                                                                      *");
            _logger.WriteLine("****************************************************************************************");
            _logger.WriteLine("");
            _logger.WriteLine("Application Name: " + AppHelper.GetApplicationName() + ".exe ver. " + AppHelper.GetApplicationVersionInfo().ProductVersion);
            _logger.WriteLine("Run Path: " + AppHelper.GetApplicationPath());
            _logger.WriteLine("");


            _iniFile = new INIFile(AppHelper.GetApplicationPath() + Defs.INI_FILE_NAME, false, true);

        }


        public void Init()
        {

            LoadSettings();

            if (!_cbList.Any())
            {
                // no board info was loaded from INI file
                // we need to add at least one board

                _logger.WriteLine(LogLevel.Info, "INI file has no info about boards, added new one");

                Board board = new Board
                {
                    Name = "Board #1",
                    IniPosition = 0,
                    IsAvailableToReuse = false,
                    IsEnabled = false,
                    BoardVersion = Defs.CB_DEFAULT_BOARD_VERSION
                };

                _cbList.Add(board);

            }

            formInitDelegate?.Invoke();

            _logger.WriteLine(LogLevel.Info, "Engine initialized");

            // fill all info about boards

            for (int loop = 0; loop < _cbList.Count; loop++)
            {
                formAddBoardDelegate.Invoke(loop);
            }

            formSelectBoard.Invoke(0);


        }

        public void CloseApp()
        {

            WriteSettings();

            _iniFile.Flush();

            _logger.WriteLine("");
            _logger.WriteLine("****************************************************************************************");
            _logger.WriteLine("*                                                                                      *");
            _logger.WriteLine("*                                Application terminated                                *");
            _logger.WriteLine("*                                                                                      *");
            _logger.WriteLine("****************************************************************************************");
            _logger.WriteLine("");
        }

        /// <summary>
        /// Load App and Counter Board settings
        /// </summary>
        private void LoadSettings()
        {

            // Let's load all available Board Versions

            List<string> boardVersions = new List<string>();

            using (INIFile iniFile = new INIFile(Settings.ApplicationPath + Defs.PARAMINFO_INI_FILE_NAME, false, true))
            {
                for (byte loop = 0; loop < Defs.MAX_BOARD_VERSIONS; loop++)
                {
                    string verName = iniFile.GetValue(Defs.PARAMINFO_INI_SECTION_PARAM_VERSIONS, Defs.PARAMINFO_INI_KEY_PARAM_VERSIONS_PREFIX + (loop + 1), "");
                    if (verName != "")
                    {
                        boardVersions.Add(verName);
                        _logger.WriteLine(LogLevel.Info, $"Added board ver.{loop + 1} [{verName}]");
                    }
                }
            }

            Settings.BoardVersions = boardVersions.ToArray();

            // Let's try to load all available counter board entries

            int boardsLoaded = 0;

            for (byte loop = 0; loop < Defs.MAX_BOARDS; loop++)
            {
                string sectionNumber = Defs.INI_SECT_CB_PREFIX_NAME + loop.ToString();
                bool isAvailable = _iniFile.GetValue(sectionNumber, Defs.INI_KEY_CB_IS_AVAILABLE_FOR_REUSE, true);

                if (!isAvailable) // ini entry exists and not available for reuse
                {

                    boardsLoaded++;

                    Board board = new Board
                    {
                        IniPosition = loop,
                        IsAvailableToReuse = false,
                        IsEnabled = _iniFile.GetValue(sectionNumber, Defs.INI_KEY_CB_IS_ENABLED, true),
                        Name = _iniFile.GetValue(sectionNumber, Defs.INI_KEY_CB_NAME, "Board #" + boardsLoaded.ToString()),
                        ComPortNumber = _iniFile.GetValue(sectionNumber, Defs.INI_KEY_CB_COMPORT_NUMBER, 0)

                    };

                    _logger.WriteLine(LogLevel.Info, $"Added info about board [{boardsLoaded}] - " + board.Name);

                    int boardVersion = _iniFile.GetValue(sectionNumber, Defs.INI_KEY_CB_FW_VERSION, 0);

                    if (boardVersion >= 0 && boardVersion < Settings.BoardVersions.Length)
                    {
                        board.BoardVersion = boardVersion;
                    }
                    else
                    {
                        _logger.WriteLine(LogLevel.Error, $"Board protocol version [{boardVersion}] is not valid; Using default version [{Defs.CB_DEFAULT_BOARD_VERSION}]");
                        board.BoardVersion = Defs.CB_DEFAULT_BOARD_VERSION;
                    }

                    _cbList.Add(board);


                }
            }

            _logger.WriteLine("Settings loaded");
        }

        private void WriteSettings()
        {

            // clear Ini file to remove all info about deleted boards
            _iniFile.Clear();
            
            if (_cbList.Count == 0)
            {
                _logger.WriteLine(LogLevel.Error, "Unable to save board settings; No board is present");
            }
            else
            {
                for (byte loop = 0; loop < _cbList.Count; loop++)
                {
                    if (!_cbList[loop].IsAvailableToReuse) // need to write info
                    {
                        string sectionNumber = Defs.INI_SECT_CB_PREFIX_NAME + loop.ToString();

                        _iniFile.SetValue(sectionNumber, Defs.INI_KEY_CB_IS_AVAILABLE_FOR_REUSE, false);
                        _iniFile.SetValue(sectionNumber, Defs.INI_KEY_CB_NAME, _cbList[loop].Name);
                        _iniFile.SetValue(sectionNumber, Defs.INI_KEY_CB_IS_ENABLED, _cbList[loop].IsEnabled);
                        _iniFile.SetValue(sectionNumber, Defs.INI_KEY_CB_COMPORT_NUMBER, _cbList[loop].ComPortNumber);
                        _iniFile.SetValue(sectionNumber, Defs.INI_KEY_CB_FW_VERSION, (int)_cbList[loop].BoardVersion);
                    }
                }
            }

            _logger.WriteLine("Settings written");
        }

        public Board GetBoardInfo(int index)
        {
            return _cbList[index];
        }

    }
}
