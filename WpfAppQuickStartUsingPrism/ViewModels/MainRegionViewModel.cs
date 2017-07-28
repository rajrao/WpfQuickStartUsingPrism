using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using WpfAppQuickStartUsingPrism.Events;
using WpfAppQuickStartUsingPrism.Models;

namespace WpfAppQuickStartUsingPrism.ViewModels
{
	public class MainRegionViewModel : ViewModelBase
	{
		private readonly ObservableCollection<RowDetailModel> _rows = new ObservableCollection<RowDetailModel>();
		public ICollectionView Rows { get; private set; }

		public RowDetailModel SelectedRow { get; set; }

		public List<RowDetailModel> SelectedRows { get; set; } = new List<RowDetailModel>();

		public DelegateCommand<IList> SelectionsChangedCommand { get; set; }

		public MainRegionViewModel(IUnityContainer container, IEventAggregator eventAggregator): base(container, eventAggregator)
        {
			Rows = new ListCollectionView(_rows);
			Rows.CurrentChanged += Rows_CurrentChanged;
			SelectionsChangedCommand = new DelegateCommand<IList>(ResultsSelectionChanged);

			EventAggregator.GetEvent<RowsLoadedEvent>().Subscribe(RowsLoadedEventAction, ThreadOption.UIThread);
		}

		private void ResultsSelectionChanged(IList obj)
		{
			_rows.Clear();
			foreach (object o in obj)
			{
				_rows.Add(o as RowDetailModel);
			}
			EventAggregator.GetEvent<RowsSelectedEvent>().Publish(SelectedRows);
		}

		private void Rows_CurrentChanged(object sender, EventArgs e)
		{
			var row = Rows.CurrentItem as RowDetailModel;
			EventAggregator.GetEvent<RowSelectedEvent>().Publish(row);
		}

		private void RowsLoadedEventAction(List<RowDetailModel> rows)
		{
			_rows.Clear();
			_rows.AddRange(rows);
		}
	}
}
