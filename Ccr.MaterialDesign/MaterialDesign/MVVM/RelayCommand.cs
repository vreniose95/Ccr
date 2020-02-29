using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Ccr.MaterialDesign.MVVM
{
	public class RelayCommand 
		: ICommand
	{
		public event EventHandler CanExecuteChanged;

		private bool _enabled;
		private readonly Action<object> _execute;
		private readonly Predicate<object> _canExecute;
		
		public bool IsEnabled
		{
			get => _enabled;
			set
			{
				if (_enabled != value)
				{
					_enabled = value;
					RaiseCanExecuteChanged();
				}
			}
		}

		public RelayCommand(
			Action<object> execute) 
			: this(execute, null)
		{
			_enabled = true;
		}

		public RelayCommand(
			Action<object>    execute,
			Predicate<object> canExecute)
		{
			_enabled    = true;
			_execute    = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}


		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _enabled && _canExecute(parameter);
		}


		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}
}