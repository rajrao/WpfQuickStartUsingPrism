using System;
using System.Collections.Generic;
using WpfAppQuickStartUsingPrism.Events;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using WpfAppQuickStartUsingPrism.Models;

namespace WpfAppQuickStartUsingPrism.ViewModels
{
	public class TopBarViewModel : ViewModelBase
	{
		private string _keyData;
		private ClearLogMessages _clearLogMessagesEvent;

		public TopBarViewModel(IUnityContainer container, IEventAggregator eventAggregator) : base(container, eventAggregator)
		{
#if DEBUG
			_keyData = "some key value!";
#endif
			_clearLogMessagesEvent = EventAggregator.GetEvent<ClearLogMessages>();

			LoadCommand = new DelegateCommand(LoadCommandExecute, LoadCommandCanExecute);
		}

		private bool LoadCommandCanExecute()
		{
			return !string.IsNullOrEmpty(KeyData);
		}

		private async void LoadCommandExecute()
		{
			_clearLogMessagesEvent.Publish();

			Logger.Publish("starting...", this);

			var rows = new List<RowDetailModel>();
			Random random = new Random();
			rows.Add(new RowDetailModel
			{
				FieldOne = Guid.NewGuid(),
				FieldTwo = random.Next(),
				FieldThreeDateTime = DateTime.Now
			});
			rows.Add(new RowDetailModel
			{
				FieldOne = Guid.NewGuid(),
				FieldTwo = random.Next(),
				FieldThreeDateTime = DateTime.Now.AddDays(100)
			});
			EventAggregator.GetEvent<RowsLoadedEvent>().Publish(rows);

			Logger.Publish("done!", this);
		}

		public string KeyData
		{
			get { return _keyData; }
			set
			{
				SetProperty(ref _keyData, value);
				LoadCommand.RaiseCanExecuteChanged();
			}
		}

		public DelegateCommand LoadCommand { get; set; }

	}
}
