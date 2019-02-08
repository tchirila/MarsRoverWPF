using MarsRover.Data;
using MarsRover.Intefaces;
using MarsRover.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarsRoverWPF.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        IRoverControl roverControl = new RoverControl();

        private string _AvailCommandLabel;
        public string AvailCommandLabel 
        {
            get { return _AvailCommandLabel; } 
            set { _AvailCommandLabel = value;
                  onPropertyChanged("AvailCommandLabel");}
        }

        private string _ButtonLeftLabel;
        public string ButtonLeftLabel
        {
            get { return _ButtonLeftLabel; }
            set
            {
                _ButtonLeftLabel = value;
                onPropertyChanged("ButtonLeftLabel");
            }
        }

        private string _ButtonRightLabel;
        public string ButtonRightLabel
        {
            get { return _ButtonRightLabel; }
            set
            {
                _ButtonRightLabel = value;
                onPropertyChanged("ButtonRightLabel");
            }
        }

        private string _ButtonMoveLabel;
        public string ButtonMoveLabel
        {
            get { return _ButtonMoveLabel; }
            set
            {
                _ButtonMoveLabel = value;
                onPropertyChanged("ButtonMoveLabel");
            }
        }

        private string _TextBoxContent;
        public string TextBoxContent
        {
            get { return _TextBoxContent; }
            set
            {
                _TextBoxContent = value;
                onPropertyChanged("TextBoxContent");
            }
        }

        private string _TextBoxUnitLabel;
        public string TextBoxUnitLabel
        {
            get { return _TextBoxUnitLabel; }
            set
            {
                _TextBoxUnitLabel = value;
                onPropertyChanged("TextBoxUnitLabel");
            }
        }

        private string _CommandsToSendLabel;
        public string CommandsToSendLabel
        {
            get { return _CommandsToSendLabel; }
            set
            {
                _CommandsToSendLabel = value;
                onPropertyChanged("CommandsToSendLabel");
            }
        }

        private string _ButtonSubmitLabel;
        public string ButtonSubmitLabel
        {
            get { return _ButtonSubmitLabel; }
            set
            {
                _ButtonSubmitLabel = value;
                onPropertyChanged("ButtonSubmitLabel");
            }
        }

        private string _StatusLabel;
        public string StatusLabel
        {
            get { return _StatusLabel; }
            set
            {
                _StatusLabel = value;
                onPropertyChanged("StatusLabel");
            }
        }

        private string _StatusContent;
        public string StatusContent
        {
            get { return _StatusContent; }
            set
            {
                _StatusContent = value;
                onPropertyChanged("StatusContent");
            }
        }

        private ObservableCollection<string> _CommandsToSendContent;        
        public ObservableCollection<string> CommandsToSendContent
        {
            get { return _CommandsToSendContent; }
            set
            {
                _CommandsToSendContent = value;
                onPropertyChanged("CommandsToSendContent");
            }
        }

        private ICommand _Btn_Left_ClickCommand;
        public ICommand Btn_Left_ClickCommand
        {
            get
            {
                if (_Btn_Left_ClickCommand == null)
                {
                    _Btn_Left_ClickCommand = new Command(Btn_Left_Click, CanBtn_Left_Click);
                }
                return _Btn_Left_ClickCommand;
            }
            set { _Btn_Left_ClickCommand = value; }
        }

        private ICommand _Btn_Right_ClickCommand;
        public ICommand Btn_Right_ClickCommand
        {
            get
            {
                if (_Btn_Right_ClickCommand == null)
                {
                    _Btn_Right_ClickCommand = new Command(Btn_Right_Click, CanBtn_Right_Click);
                }
                return _Btn_Right_ClickCommand;
            }
            set { _Btn_Right_ClickCommand = value; }
        }

        private ICommand _Btn_Move_ClickCommand;
        public ICommand Btn_Move_ClickCommand
        {
            get
            {
                if (_Btn_Move_ClickCommand == null)
                {
                    _Btn_Move_ClickCommand = new Command(Btn_Move_Click, CanBtn_Move_Click);
                }
                return _Btn_Move_ClickCommand;
            }
            set { _Btn_Move_ClickCommand = value; }
        }

        private ICommand _Btn_Submit_ClickCommand;
        public ICommand Btn_Submit_ClickCommand
        {
            get
            {
                if (_Btn_Submit_ClickCommand == null)
                {
                    _Btn_Submit_ClickCommand = new Command(Btn_Submit_Click, CanBtn_Submit_Click);
                }
                return _Btn_Submit_ClickCommand;
            }
            set { _Btn_Submit_ClickCommand = value; }
        }

        private bool CheckCommandLimit()
        {
            int commandCount = CommandsToSendContent.Count;

            if (commandCount > 4)
            {
                return false;
            }

            return true;
        }

        private bool ValidateInput(string input)
        {
            double value;
            bool isNumeric = double.TryParse(input, out value);

            if (isNumeric == false)
            {
                return false;
            }

            return true;
        }

        private List<MarsRover.Data.Command> ConvertToCommands(ObservableCollection<string> CommandsToSendContent)
        {
            List<MarsRover.Data.Command> commands = new List<MarsRover.Data.Command>();

            foreach (var item in CommandsToSendContent)
            {
                if (item == "Left")
                {
                    commands.Add(new MarsRover.Data.Command { Distance = 0, Direction = 90 });                    
                }
                else if (item == "Right")
                {
                    commands.Add(new MarsRover.Data.Command { Distance = 0, Direction = -90 });
                }
                else
                {
                    string distanceString = item.Remove(item.Length - 1);
                    double distance;
                    double.TryParse(distanceString, out distance);
                    commands.Add(new MarsRover.Data.Command { Distance = distance, Direction = 0 });
                }               
            }

            return commands;
        }

        private void Btn_Left_Click()
        {
            string input = "Left";
            CommandsToSendContent.Add(input);
        }

        private bool CanBtn_Left_Click()
        {
            return CheckCommandLimit();
        }

        private void Btn_Right_Click()
        {
            string input = "Right";
            CommandsToSendContent.Add(input);
        }

        private bool CanBtn_Right_Click()
        {
            return CheckCommandLimit();
        }

        private void Btn_Move_Click()
        {            
            bool isValid = ValidateInput(TextBoxContent);

            if (isValid == false)
            {
                return;
            }

            string input = TextBoxContent + "m";
            CommandsToSendContent.Add(input);
            TextBoxContent = "";
        }

        private bool CanBtn_Move_Click()
        {
            return CheckCommandLimit();
        }

        private void Btn_Submit_Click()
        {
            List<MarsRover.Data.Command> commands = ConvertToCommands(CommandsToSendContent);
            CommandsToSendContent = new ObservableCollection<string>();
            StatusContent = roverControl.GetPosition(commands, currentPosition, listOfAvailableDirections);
        }

        private bool CanBtn_Submit_Click()
        {
            return true;
        }

        public ViewModel()
        {
            AvailCommandLabel = "Available Commands";
            ButtonLeftLabel = "Turn Left";
            ButtonRightLabel = "Turn Right";
            ButtonMoveLabel = "Move";
            TextBoxUnitLabel = "m";
            TextBoxContent = "";
            CommandsToSendLabel = "Commands to Send";
            ButtonSubmitLabel = "Submit";
            StatusLabel = "Status";
            StatusContent = "Rover is at 1 South";
            CommandsToSendContent = new ObservableCollection<string>();            
        }

        CurrentPosition currentPosition = new CurrentPosition()
            { 
                XCoordinate = 0.5,
                YCoordinate = 0.5,
                Angle = 270
            };

        List<Direction> listOfAvailableDirections = new List<Direction>() 
            {
                new Direction{ Name = "East", Angle = 0},
                new Direction{ Name = "Northeast", Angle = 45},
                new Direction{ Name = "North", Angle = 90},
                new Direction{ Name = "Northwest", Angle = 135},
                new Direction{ Name = "West", Angle = 180},
                new Direction{ Name = "Southwest", Angle = 225},
                new Direction{ Name = "South", Angle = 270},
                new Direction{ Name = "Southeast", Angle = 315}
            };

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
