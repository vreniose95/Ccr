using System;
using System.Diagnostics;
using System.Windows.Input;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.MVVM
{
	public class Command
		: ICommand
	{
		private readonly Action<object> _execute;
		private readonly Func<object, bool> _canExecute;

		public Command(
			Action<object> execute) : this(
				execute,
				null)
		{
		}
		public Command(
			Action<object> execute,
			Func<object, bool> canExecute)
		{
			execute.IsNotNull(nameof(execute));

			_execute = execute;
			_canExecute = canExecute ?? (x => true);
		}


		public bool CanExecute(object parameter)
		{
			return _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public void Refresh()
		{
			CommandManager.InvalidateRequerySuggested();
		}
	}


	public class RelayCommand : ICommand
	{
		#region Fields

		private bool _enabled;
		private readonly Action<object> _execute;
		private readonly Predicate<object> _canExecute;

		#endregion Fields

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

		#region Constructors

		public RelayCommand(Action<object> execute) : this(execute, null)
		{
			_enabled = true;
		}

		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			_enabled = true;
			_execute = execute ?? throw new ArgumentNullException("execute");
			_canExecute = canExecute;
		}

		#endregion Constructors

		#region ICommand Members

		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _enabled; //_canExecute == null ? true : _canExecute(parameter);
		}

		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		#endregion ICommand Members

	}
}
