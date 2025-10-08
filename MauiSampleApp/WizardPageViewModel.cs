using System;
using System.Collections.Generic;
using System.Linq;
using System.Mvvm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiSampleApp
{
    public class WizardPageViewModel : ViewModel
    {
		private int _childCount;
        private int _position;
        private bool _enableLooping;

        public int ChildCount
		{
			get { return _childCount; }
			set { _childCount = value; NotifyPropertiesChanged(nameof(ChildCount)); }
		}

		public int Position
		{
			get { return _position; }
			set { _position = value; NotifyPropertiesChanged(nameof(Position), nameof(NextCommand), nameof(BackCommand)); }
		}

		public bool EnableLooping
		{
			get { return _enableLooping; }
			set { _enableLooping = value; NotifyPropertiesChanged(nameof(EnableLooping)); }
		}

        public ICommand NextCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        Position = Position + 1;
                    }
                    catch (Exception ex)
                    {
                        NotifyErrorOccurred(ex);
                    }
                }, (obj) =>
                {
                    var newPosition = Position + 1;

                    if (newPosition > ChildCount -1)
                    {
                        return false;
                    }

                    return true;
                });
            }

        }

        public ICommand BackCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        Position = Position - 1;
                    }
                    catch (Exception ex)
                    {

                        NotifyErrorOccurred(ex);
                    }
                }, (obj) =>
               {
                   var newPosition = Position - 1;

                   if (newPosition < 0)
                   {
                       return false;
                   }

                   return true;
               });
            }

        }

        public WizardPageViewModel()
        {
			EnableLooping = false;
        }





    }
}
